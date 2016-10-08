using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityTeamworkGame.CS_Interfaces;

namespace UnityTeamworkGame.CS_MapObjects
{
    public abstract class LandObject : MapObject
    {

        // constructors
        protected LandObject(int x, int y) : base(x, y)
        {

        }

        // properties
        public int Hitpoints { get; private set; }
        public bool IsDestroyed { get; private set; }

        // methods
        public void TakeDamage(int damageCaused)
        {
            this.Hitpoints -= damageCaused;
            this.IsDestroyed = this.Hitpoints <= 0;
        }
    }
}
