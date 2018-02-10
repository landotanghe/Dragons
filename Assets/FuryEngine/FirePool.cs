using Assets.Dragons.Damages;

namespace Assets.FuryEngine
{
    public class FirePool
    {
        public Fire Fire { get; private set; }

        private FirePool()
        {
            Fire = Fire.FullPool;
        }

        public static FirePool Instantiate()
        {
            var pool = new FirePool();
            pool.OnFireChanged();

            return pool;
        }

        public class FirePoolLevelChangedEvent
        {
            public int FireLevel { get; set; }
        }


        public delegate void FireChangedHandler(FirePoolLevelChangedEvent @event);
        public event FireChangedHandler FireEvent;


        private void OnFireChanged()
        {
            if (FireEvent != null)
            {
                FireEvent(new FirePoolLevelChangedEvent
                {
                    FireLevel = Fire.Amount
                });
            }
        }

        public Fire ConsumeFire()
        {
            if (Fire == Fire.Depleted)
                return Fire.Depleted;

            Fire = Fire - Fire.One;

            OnFireChanged();
            return Fire.One;
        }

        internal void Add(Fire fire)
        {
            Fire = Fire + fire;
            OnFireChanged();
        }
    }
}
