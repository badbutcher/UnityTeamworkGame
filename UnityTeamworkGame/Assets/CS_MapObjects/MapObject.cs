using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityTeamworkGame.CS_Interfaces;

namespace UnityTeamworkGame.CS_MapObjects
{
    public abstract class MapObject
    {
        protected MapObject(int x, int y)
        {
            this.LocationX = x;
            this.LocationY = y;
        }        

        // properties
        public int LocationX { get; private set; }
        public int LocationY { get; private set; }
    }
}
