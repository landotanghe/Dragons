using Assets.Dragons;
using Assets.Dragons.Damages;
using System;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public class Board : MonoBehaviour
    {
        private Water _waterPool;
        private Fire _firePool;

        public Dragon whiteDragon;
        public Dragon blackDragon;

        public Board()
        {
            _waterPool = Water.Depleted;
            _firePool = Fire.FullPool;
        }

        internal bool IsFreeSpace(Location location)
        {
            return IsWithinBounds(location.X, location.Y) && 
                !whiteDragon.Occupies(location) && 
                !blackDragon.Occupies(location);
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < 8
                && y >= 0 && y < 8;
        }

        public Dragon GetOpponentOf(Dragon dragon)
        {
            return dragon == whiteDragon 
                ? blackDragon 
                : whiteDragon;
        }

        public Water GetWaterInPool()
        {
            return _waterPool;
        }

        public Water ConsumeWater()
        {
            if (_waterPool == Water.Depleted)
                return Water.Depleted;

            _waterPool = _waterPool - Water.One;
            return Water.One;
        }

        internal void AddWaterToPool(Water water)
        {
            _waterPool = _waterPool + water;
        }

        public Fire ConsumeFire()
        {
            if (_firePool == Fire.Depleted)
                return Fire.Depleted;

            _firePool = _firePool - Fire.One;
            return Fire.One;
        }

        internal void AddFireToPool(Fire exhaledFire)
        {
            _firePool = _firePool + exhaledFire;
        }
    }
}
