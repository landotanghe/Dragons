using UnityEngine;

namespace Assets.Dragons
{
    public class Head : MonoBehaviour
    {
        private int _x;
        private int _y;
        private Direction _upStream;

        public void Reposition(int x, int y, Direction upStream)
        {
            _x = x;
            _y = y;
            _upStream = upStream;
        }

        public void FixedUpdate()
        {
            //TODO display rotated dragon head
            switch (_upStream)
            {
                case Direction.North:
                    return;
                case Direction.East:
                    return;
                case Direction.South:
                    return;
                case Direction.West:
                    return;
            }
        }
    }
}
