using System;
using System.Linq;
using UnityTeamworkGame.CS_Interfaces;
using UnityTeamworkGame.CS_Ships;

namespace UnityTeamworkGame.CS_Ships
{
    public class Projectile
    {
        private Ship ship;

        public Projectile(Ship ship)
        {
            this.ship = ship;
            this.Hit = false;
        }

        public bool Hit { get; set; }

    }
}