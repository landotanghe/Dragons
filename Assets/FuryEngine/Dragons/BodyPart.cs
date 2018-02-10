using System;
using Assets.Dragons;

namespace Assets.FuryEngine.DragonPackage
{
    public class BodyPart
    {
        public Location Location { get; private set; }
        public Direction Direction { get; private set; }
        public Direction DownStream { get; private set; }

        public BodyPart()
        {
            Location = new Location(0, 0);
            Direction = Direction.North;
            DownStream = Direction.South;
        }

        public void Reposition(Location location, Direction direction)
        {
            DownStream = Direction.Invert();

            Location = location;
            Direction = direction;
        }

        internal bool Occupies(Location location)
        {
            return location == Location;
        }
    }
}
