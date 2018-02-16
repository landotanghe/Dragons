using Assets.Dragons;
using Assets.Dragons.Damages;
using System.Linq;

namespace Assets.FuryEngine.DragonPackage
{
    public class Tail
    {
        private BodyPart[] _segments;

        public Health _tailHealth { get; private set; }

        public Tail()
        {
            _segments = new BodyPart[3];
            for(int i=0; i< 3; i++)
            {
                _segments[i] = new BodyPart();
            }
            _tailHealth = Health.Full;
        }

        public Water TakeDamage(Damage damage)
        {
            var water = Water.Depleted;

            if (_tailHealth.CanBear(Damage.One))
            {
                water++;
                damage--;
            }
            else
            {
                RemoveSegment();
                _tailHealth = Health.Full;

                damage = damage - _tailHealth.DamageToDestroy;
                water -= _tailHealth.WaterNeededToHeal;
            }

            return water;
        }

        public void Heal(Water water)
        {
            _tailHealth = _tailHealth + water;
        }

        private void RemoveSegment()
        {
            _segments = _segments.Take(_segments.Length - 1).ToArray();
        }

        public int Length
        {
            get
            {
                return _segments.Length;
            }
        }

        public void MoveTo(Location location, Direction direction)
        {
            if (_segments.Length == 0)
                return;
            
            foreach(var segment in _segments)
            {
                var previousLocation = segment.Location;
                segment.Reposition(location, direction);
                location = previousLocation;
            }
        }

        public bool Occupies(Location location)
        {
            return _segments.Any(part => part.Occupies(location));
        }
    }
}
