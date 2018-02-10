using System;
using Assets.Dragons.Damages;
namespace Assets.FuryEngine
{
    public class WaterPool
    {
        public Water Water { get; private set; }

        private WaterPool()
        {
            Water = Water.Depleted;
        }

        public static WaterPool Instantiate()
        {
            var pool = new WaterPool();
            pool.OnWaterChanged();
            return pool;
        }

        public class WaterPoolLevelChangedEvent
        {
            public int WaterLevel { get; set; }
        }

        public delegate void WaterChangedHandler(WaterPoolLevelChangedEvent @event);
        public event WaterChangedHandler WaterEvent;

        private void OnWaterChanged()
        {
            if (WaterEvent != null)
            {
                WaterEvent(new WaterPoolLevelChangedEvent
                {
                    WaterLevel = Water.Amount
                });
            }
        }

        public Water Consume()
        {
            if (Water == Water.Depleted)
                return Water.Depleted;

            Water = Water - Water.One;

            OnWaterChanged();
            return Water.One;
        }

        public void Add(Water water)
        {
            Water = Water + water;
            OnWaterChanged();
        }

    }
}
