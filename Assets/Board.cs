using Assets.Dragons;
using Assets.FuryEngine.Damages;
using UnityEngine;

namespace Assets
{
    public class Board : MonoBehaviour
    {
        private Water _waterPool;
        private Fire _firePool;

        public Dragon whiteDragon;
        public Dragon blackDragon;

        public ElementsPool elementsPool;

        public Board()
        {
            _waterPool = Water.Depleted;
            _firePool = Fire.FullPool;
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
            elementsPool.RemoveWater();
            return Water.One;
        }

        public void AddWaterToPool(Water water)
        {
            _waterPool = _waterPool + water;
            elementsPool.AddWater(water.Amount);
        }

        public Fire ConsumeFire()
        {
            if (_firePool == Fire.Depleted)
                return Fire.Depleted;

            _firePool = _firePool - Fire.One;
            elementsPool.RemoveFire();
            return Fire.One;
        }

        public void AddFireToPool(Fire exhaledFire)
        {
            _firePool = _firePool + exhaledFire;
            elementsPool.AddFire(exhaledFire.Amount);
        }
    }
}
