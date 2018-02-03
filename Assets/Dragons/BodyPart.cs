using UnityEngine;

namespace Assets.Dragons
{
    public abstract class BodyPart : MonoBehaviour
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Direction _upStream;
        private Direction _downStream;

        public Direction Heading
        {
            get
            {
                return _upStream;
            }
        }

        private const float LeftMost = -6f;
        private const float RightMost = 5.2f;
        private const float Width = RightMost - LeftMost;
        private const float TopMost = -4.9f;
        private const float BottomMost = 5.0f;
        private const float Height = BottomMost - TopMost;
        

        public void Reposition(int x, int y, Direction upStream)
        {
            X = x;
            Y = y;
            _upStream = upStream;
        }

        private const float TileWidth = Width / 7.0f;
        private const float TileHeight = Height / 7.0f;

        public float DisplayX
        {
            get
            {
                return LeftMost + TileWidth * X;
            }
        }

        public float DisplayY
        {
            get
            {
                return TopMost + TileHeight * Y;
            }
        }

        public abstract float GetDisplayRotationInDegrees(Direction upstream, Direction downstream);

        public void FixedUpdate()
        {
            transform.position = new Vector3(DisplayX, DisplayY, 0.0f);
            var rotation = GetDisplayRotationInDegrees(_upStream, _downStream);
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
    }
}
