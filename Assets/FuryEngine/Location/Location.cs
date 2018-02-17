using System.Collections.Generic;
using Assets.FuryEngine.SeedWork;

namespace Assets.FuryEngine.Location
{
    public class Location : ValueObject
    {
        public readonly int X;
        public readonly int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Location operator +(Location location, Direction direction)
        {
            if(direction == Direction.North)
            {
                return new Location(location.X, location.Y + 1);
            }else if(direction == Direction.South)
            {
                return new Location(location.X, location.Y - 1);
            }else if (direction == Direction.East)
            {
                return new Location(location.X + 1, location.Y);
            }    
            return new Location(location.X - 1, location.Y);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { X, Y };
        }
    }
}
