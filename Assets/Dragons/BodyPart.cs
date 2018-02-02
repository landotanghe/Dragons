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

        public abstract void DisplayRotation(Direction upstream, Direction downstream);

        public void FixedUpdate()
        {
            transform.position = new Vector3(LeftMost + Width * X / 7.0f, TopMost + Height * Y / 7.0f, 0.0f);
            DisplayRotation(_upStream, _downStream);
        }
    }
}
