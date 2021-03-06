﻿using System;

namespace Assets.FuryEngine.Damages
{
    public class Health
    {
        public const int Maximum = 4;
        public readonly int LifePoints;

        public static Health Full
        {
            get
            {
                return new Health(Maximum);
            }
        }
        
        private Health(int lifePoints)
        {
            LifePoints = lifePoints;
        }

        public Water WaterNeededToHeal
        {
            get
            {
                return new Water(Maximum - LifePoints);
            }
        }

        public Damage DamageToDestroy
        {
            get
            {
                return Damage.FromValue(LifePoints);
            }
        }

        public bool CanBear(Damage damage)
        {
            return damage.Value < LifePoints;
        }

        public static Health operator -(Health health, Damage damage) {
            if (!health.CanBear(damage))
                throw new Exception("damage is too high");

            return new Health(health.LifePoints - damage.Value);
        }

        public static Health operator +(Health health, Water water)
        {
            return new Health(health.LifePoints + water.Amount);
        }
    }
}
