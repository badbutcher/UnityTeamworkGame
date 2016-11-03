using System;
using System.Collections.Generic;
using System.Linq;
using UnityTeamworkGame;
using UnityTeamworkGame.CS_Enums;
using UnityTeamworkGame.CS_Interfaces;
using UnityTeamworkGame.CS_Common;

namespace UnityTeamworkGame.CS_Ships
{
    public abstract class Ship : IDestroyable
    {
        protected const int MaxHitpoints = 200;
        protected const int InitialDamage = 40;        

        protected int x, y;

        protected double fireTime;
        protected bool isMoved;

        protected Ship(int x, int y)
        {
            this.Weapons = Weapons.Basic;
            this.Hull = Hull.Basic;
            this.IsDestroyed = false;
            this.Hitpoints = MaxHitpoints * (int)this.Hull;
            this.Damage = InitialDamage * (int)this.Weapons;
            this.Shells = new List<Projectile>();
            this.fireTime = 0;
            this.x = x;
            this.y = y;
            this.isMoved = false;
        }

        public List<Projectile> Shells { get; set; }

        public int Damage { get; private set; }

        public Weapons Weapons { get; set; }

        public Hull Hull { get; set; }

        public void ResetHitpoints()
        {
            this.Hitpoints = MaxHitpoints;
        }


        public int Hitpoints { get; protected set; }

        public bool IsDestroyed { get; private set; }

        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public bool IsMoved { get { return this.isMoved; } }

        public virtual void Move()
        {
           // TODO
        }

        public void TakeDamage(int damageCaused)
        {
            this.Hitpoints -= damageCaused / (int)this.Hull;
            this.IsDestroyed = this.Hitpoints <= 0;
        }

        public void Fire()
        {
            // TODO
        }    

        public virtual void Update(Ship target, ref GameState gameState)
        {
            if (gameState == GameState.Combat)
            {
                for (int i = this.Shells.Count - 1; i >= 0; i--)
                {
                    if (this.Shells[i].Hit)
                    {
                        target.TakeDamage(this.Damage);
                        if (target.IsDestroyed)
                        {                           
                            this.Shells.Clear();
                            gameState = GameState.FreeRoam;
                            return;
                        }
                        this.Shells.RemoveAt(i);
                    }
                }
                foreach (var item in this.Shells)
                {
                    // TODO
                }
            }
        }

        public void AdjustPosition(double xMap, double yMap)
        {
            this.x = (int)Math.Round(xMap * Map.MAP_RATIO);
            this.y = (int)Math.Round(yMap * Map.MAP_RATIO);
        }
    }
}