using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.Dragons
{
    public class BodyPart
    {
        public Location.Location Location { get; private set; }
        public Direction Direction { get; private set; }
        public Direction DownStream { get; private set; }

        public BodyPart()
        {
            Location = new Location.Location(0, 0);
            Direction = Direction.North;
            DownStream = Direction.South;
        }

        public void Reposition(Location.Location location, Direction direction)
        {
            DownStream = Direction.Invert();

            Location = location;
            Direction = direction;
        }

        internal bool Occupies(Location.Location location)
        {
            return location == Location;
        }
    }
}
