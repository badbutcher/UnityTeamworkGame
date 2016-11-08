using System;
using System.Collections.Generic;
using System.Linq;
using UnityTeamworkGame;
using UnityTeamworkGame.CS_Enums;
using UnityTeamworkGame.CS_Interfaces;
using UnityTeamworkGame.CS_Ships;
using UnityTeamworkGame.CS_Common;

namespace UnityTeamworkGame.CS_Ships
{
    public class NpcShip : Ship, IDestroyable
    {
        private const int DETECT_RANGE = 50;
        //private double time;
        private int[] destination;
        private List<int[]> path;
        private float speed;
        //private bool reached;
        private bool isInRange;

        public NpcShip(int x, int y) : base(x, y)
        {
            //this.time = 0;
            this.IsInCombat = false;
            this.path = new List<int[]>();
            this.isInRange = false;
        }        

        public NpcShip(int x, int y, int destinationX, int destinationY)
            : this(x, y)
        {
            //this.time = 0;
            this.IsInCombat = false;
            this.Hull = Hull.Steel;
            this.Weapons = Weapons.Shredder;
            this.speed = 1.5f;
            this.destination = new int[2];
            this.destination[0] = destinationX;
            this.destination[1] = destinationY;
        }
        

        public bool IsInCombat { get; set; }        
        
        private void Movement(Ship playership, Map map, out int[] nextPositionCoords)
        {
            nextPositionCoords = new int[2];
            int[] target = new int[2];
            bool wasInRange = this.isInRange;
            CheckInRange(playership.X, playership.Y);
            if (this.isInRange)
            {
                target[0] = playership.X;
                target[1] = playership.Y;
                if (playership.IsMoved || this.path.Count == 0)
                {
                    int[] start = new int[2];
                    start[0] = (int)this.X;
                    start[1] = (int)this.Y;
                    map.GetPathToTarget(start, target, this.path);
                }
            }
            else if (wasInRange || this.path.Count == 0)
            {
                target[0] = this.destination[0];
                target[1] = this.destination[1];
                int[] start = new int[2];
                start[0] = (int)this.X;
                start[1] = (int)this.Y;
                map.GetPathToTarget(start, target, this.path);
            }
            if (this.path.Count > 0 )
            {
                nextPositionCoords[0] = this.path[0][0];
                nextPositionCoords[1] = this.path[0][1];
                this.path.RemoveAt(0);
            }
            else
            {
                nextPositionCoords[0] = this.X;
                nextPositionCoords[1] = this.Y;
            }         
        }    
        
        private void CheckInRange(double PlayerShipPositionX, double PlayerShipPositionY)
        {
            int distance = (int)Math.Sqrt(Math.Pow((PlayerShipPositionX - this.x), 2) + Math.Pow((PlayerShipPositionY - this.y), 2));
            this.isInRange = distance <= DETECT_RANGE;
        }  
    }
}