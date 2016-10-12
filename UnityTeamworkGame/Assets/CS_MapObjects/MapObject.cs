using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityTeamworkGame.CS_Interfaces;

namespace UnityTeamworkGame.CS_MapObjects
{
    public abstract class MapObject
    {
        protected int[,] vertexes; 

        protected MapObject(int x, int y, int width, int height)
        {
            this.LocationX = x; // coordinates of the bottom left corner
            this.LocationY = y;
            this.Width = width; // weight and height of the rectangle containing the map object
            this.Height = height;
            vertexes[0, 0] = x; // corrdinates of the vertexes of this rectangle, counterclockwise
            vertexes[0, 1] = y;
            vertexes[1, 0] = x+width;
            vertexes[1, 1] = y;
            vertexes[2, 0] = x+width;
            vertexes[2, 1] = y+height;
            vertexes[3, 0] = x;
            vertexes[3, 1] = y+height;
        }        

        // properties
        public int LocationX { get; private set; }
        public int LocationY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
