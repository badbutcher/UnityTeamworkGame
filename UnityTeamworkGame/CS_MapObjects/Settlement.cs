using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityTeamworkGame.CS_Enums;
using UnityTeamworkGame.CS_Ships;

namespace UnityTeamworkGame.CS_MapObjects
{

    public abstract class Settlement : LandObject
    {
        // fields
        private List<PlayerShip> shipsOnDock = new List<PlayerShip>(); // this field remains hidden as it will be used only within methods of the class       

        // constructors
        protected Settlement(int x, int y)
            : this(1, 0, 1, x, y)
        { }

        public Settlement(int startPopulation, int initialWealth, int defence, int x, int y) 
                        : base(x, y)
        {
            this.Population = startPopulation;
            this.Wealth = initialWealth;
            this.DefencePower = defence;
        }

        // abstract methods


        // virtual methods
        /*public virtual NpcShip BuildShip(ContentManager content, string texture) // ship details to be added here
        {
            return new NpcShip(content, texture, this.LocationX, this.LocationY);
        }*/
        public virtual PlayerShip SendShip()
        {
            //this.shipsOnDock.Find();
            return null;
        }

        // properties
        public int Population { get; private set; }
        public int Wealth { get; private set; }
        public int DefencePower { get; private set; }

    }
}
