using System;
using UnityEngine;

namespace Assets.Dragons
{
    public class Head : MonoBehaviour
    {
        private const float LeftMost = -6f;
        private const float RightMost = 5.2f;
        private const float Width = RightMost - LeftMost;
        private const float TopMost = -4.9f;
        private const float BottomMost = 5.0f;
        private const float Height = BottomMost - TopMost;


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
            transform.position = new Vector3(LeftMost + Width * _x / 7.0f, TopMost + Height * _y / 7.0f, 0.0f);
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
