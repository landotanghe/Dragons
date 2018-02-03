using UnityEngine;

namespace Assets.Dragons
{
    public abstract class BodyPart : MonoBehaviour
    {
        public Location Location { get; private set; }
        public Direction Direction { get; private set; }
        public Direction DownStream { get; private set; }
        

        private const float LeftMost = -6f;
        private const float RightMost = 5.2f;
        private const float Width = RightMost - LeftMost;
        private const float TopMost = -4.9f;
        private const float BottomMost = 5.0f;
        private const float Height = BottomMost - TopMost;

        public BodyPart()
        {
            Location = new Location(0, 0);
            Direction = Direction.North;
            Direction = Direction.South;
        }
        

        public void Reposition(Location location, Direction upStream)
        {
            Location = location;
            Direction = upStream;
        }

        public void SetDownStream(Direction direction)
        {
            DownStream = direction;
        }

        private const float TileWidth = Width / 7.0f;
        private const float TileHeight = Height / 7.0f;

        public float DisplayX
        {
            get
            {
                return LeftMost + TileWidth * Location.X;
            }
        }

        public float DisplayY
        {
            get
            {
                return TopMost + TileHeight * Location.Y;
            }
        }

        public bool Occupies(Location location)
        {
            return location == Location;
        }

        public abstract float GetDisplayRotationInDegrees(Direction upstream, Direction downstream);

        public void FixedUpdate()
        {
            transform.position = new Vector3(DisplayX, DisplayY, 0.0f);
            var rotation = GetDisplayRotationInDegrees(Direction, DownStream);
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
    }
}
