using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTeamworkGame.CS_Common
{
    class Map:MonoBehaviour
    {
        public const int MAP_WIDTH = 350;
        public const int MAP_HEIGHT = 350;
        public const float MAP_RATIO = 10;
        public const float UNITY_COORDS_CONV = 17.5f;
        public const float DETECT_RANGE = 10f;
        private const string MAP_FILE_NAME = "map";

        private static int[,,] mapFields;
        private static bool[,] obstacles;

        void Start()
        {
            Map.mapFields = new int[MAP_WIDTH, MAP_HEIGHT, 6]; //[0] = 0 - doesn't belong to list; 1 - belongs to the open list; 2 - belongs to teh closed list
                                                                //[1] - G (movement cost from start); [2] - H (estimated moevement cost to target); [3] F = G+H; [4] - Parent X; [5]  -Parent Y            
            Map.obstacles = Map.LoadMapFromFile();
        }
        /*public Map()
        {
            this.mapFields = new int[MAP_WIDTH, MAP_HEIGHT, 6]; //[0] = 0 - doesn't belong to list; 1 - belongs to the open list; 2 - belongs to teh closed list
            //[1] - G (movement cost from start); [2] - H (estimated moevement cost to target); [3] F = G+H; [4] - Parent X; [5]  -Parent Y            
        }

        static Map()
        {
            Map.obstacles = Map.LoadMapFromFile();
        }*/

        public static void GetPathToTarget(int[] start, int[] target, out List<float[]> path)  //return list with consequative coordinates
        {

            List<int[]> openList = new List<int[]>(); //sorted list!

            // reset map
            for (int i = 0; i < MAP_WIDTH; i++)
            {
                for (int j = 0; j < MAP_HEIGHT; j++)
                {
                    Map.mapFields[i, j, 0] = 0;
                    Map.mapFields[i, j, 1] = int.MaxValue;
                    Map.mapFields[i, j, 2] = int.MaxValue;
                    Map.mapFields[i, j, 3] = int.MaxValue;
                    Map.mapFields[i, j, 4] = 0;
                    Map.mapFields[i, j, 5] = 0;
                }   
            }

            // add start position to the open list
            int[] currentPos = new int[4];   //x, y, G, F                                                                          
            currentPos[0] = start[0];
            currentPos[1] = start[1];
            currentPos[2] = 0;
            currentPos[3] = Math.Abs(start[0] - target[0]) + Math.Abs(start[1] - target[1]);

            openList.Add(currentPos);
            mapFields[currentPos[0], currentPos[1], 0] = 1;

            //main loop of the algorithm
            int insertAtIndex, removeAtIndex;

            int minX, maxX, minY, maxY;
            while ((currentPos[0] != target[0] || currentPos[1] != target[1]) && openList.Count > 0)
            {
                currentPos = openList[0]; // bet the smallest element from teh sorted open list
                mapFields[currentPos[0], currentPos[1], 0] = 2; // add to "closed list"
                openList.RemoveAt(0); // remove from the open list
                minX = Math.Max(currentPos[0] - 1, 0);
                maxX = Math.Min(currentPos[0] + 1, MAP_WIDTH - 1);
                minY = Math.Max(currentPos[1] - 1, 0);
                maxY = Math.Min(currentPos[1] + 1, MAP_HEIGHT - 1);
                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = minY; y <= maxY; y++)
                    {
                        if (mapFields[x, y, 0] != 2 && !obstacles[x, y])
                        // doesn't belong to the closed list and is not an obstacle
                        {
                            if (mapFields[x, y, 0] == 0)
                            {
                                // add to the open list
                                int[] newPos = new int[4];
                                newPos[0] = x;
                                newPos[1] = y;
                                newPos[2] = (x == currentPos[0] || y == currentPos[1]) ? currentPos[2] + 10 : currentPos[2] + 14;
                                newPos[3] = newPos[2] + (Math.Abs(x - target[0]) + Math.Abs(y - target[1])) * 10;
                                insertAtIndex = openList.FindIndex(el => el[3] > newPos[3]);
                                if (insertAtIndex < 0)
                                    insertAtIndex = Math.Max(openList.Count - 1, 0);
                                openList.Insert(insertAtIndex, newPos);
                                mapFields[x, y, 0] = 1;
                                mapFields[x, y, 1] = newPos[2];
                                mapFields[x, y, 2] = (Math.Abs(x - target[0]) + Math.Abs(y - target[1])) * 10;
                                mapFields[x, y, 3] = mapFields[x, y, 1] + mapFields[x, y, 2];
                                // set parent
                                mapFields[x, y, 4] = currentPos[0];
                                mapFields[x, y, 5] = currentPos[1];
                            }
                            else
                            {
                                if (currentPos[2] + 1 < mapFields[x, y, 1])
                                {
                                    // change parrent
                                    mapFields[x, y, 4] = currentPos[0];
                                    mapFields[x, y, 5] = currentPos[1];
                                    // recalculate G, H and F
                                    mapFields[x, y, 1] = (x == currentPos[0] || y == currentPos[1]) ? currentPos[2] + 10 : currentPos[2] + 14;
                                    mapFields[x, y, 2] = (Math.Abs(x - target[0]) + Math.Abs(y - target[1])) * 10;
                                    mapFields[x, y, 3] = mapFields[x, y, 1] + mapFields[x, y, 2];
                                    // resort the open list
                                    removeAtIndex = openList.FindIndex(el => el[0] == x && el[1] == y);
                                    openList.RemoveAt(removeAtIndex);
                                    int[] newPos = new int[4];
                                    newPos[0] = x;
                                    newPos[1] = y;
                                    newPos[2] = mapFields[x, y, 1];
                                    newPos[3] = mapFields[x, y, 3];
                                    insertAtIndex = openList.FindIndex(el => el[3] > newPos[3]);
                                    if (insertAtIndex < 0)
                                        insertAtIndex = Math.Max(openList.Count - 1, 0);
                                    openList.Insert(insertAtIndex, newPos);
                                }
                            }
                        }
                    }
                }
            }
            path = new List<float[]>();
            if (currentPos[0] == target[0] && currentPos[1] == target[1])
            {
                int currentX = target[0], currentY = target[1];
                while (currentX != start[0] || currentY != start[1])
                {
                    float[] pathNode = new float[2];
                    pathNode[0] = currentX;
                    pathNode[1] = currentY;
                    path.Add(pathNode);
                    currentX = mapFields[currentX, currentY, 4];
                    currentY = mapFields[currentX, currentY, 5];
                }
            }
        }

        private static bool[,] LoadMapFromFile()
        {
            String input = File.ReadAllText(@"..\..\CS_Resources\" + MAP_FILE_NAME + ".txt");

            byte x = 0, y = 0;
            bool[,] map = new bool[MAP_WIDTH, MAP_HEIGHT];
            foreach (var row in input.Split('\n'))
            {
                x = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    map[x++, y] = byte.Parse(col.Trim()) == 1;
                }
                y++;
            }
            return map;
        }


        public static int[] ConvertLocationToCoord(float[] location)
        {
            int[] coord = new int[2];
            coord[0] = (int)Math.Round((location[0] + UNITY_COORDS_CONV) * MAP_RATIO);
            coord[1] = (int)Math.Round((location[1] + UNITY_COORDS_CONV) * MAP_RATIO);
            return coord;
        }

        public static float[] ConvertCoordToLocation(int[] coord)
        {
            float[] location = new float[2];
            location[0] = (float)(coord[0] / MAP_RATIO - UNITY_COORDS_CONV);
            location[1] = (float)(coord[1] / MAP_RATIO - UNITY_COORDS_CONV);
            return location;
        }
    }
}
