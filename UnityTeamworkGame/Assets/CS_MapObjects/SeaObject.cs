using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityTeamworkGame.CS_MapObjects
{
    public abstract class SeaObject : MapObject
    {
        public SeaObject(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }
    }
}
