using System;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public Head head;
        public Tail[] tail;
        
        public void FixedUpdate()
        {
        }

        public bool CanTurnRight(Board board)
        {
            return true;
        }

        public bool CanTurnLeft(Board board)
        {
            return true;
        }

        public bool CanMoveForwards(Board board)
        {
            return true;
        }

        public void TurnLeft(Board board)
        {
            if(head.Heading == Direction.East)
            {
                GoNorth();
            }else if(head.Heading == Direction.North)
            {
                GoWest();
            }else if(head.Heading == Direction.West)
            {
                GoSouth();
            }else if(head.Heading == Direction.South)
            {
                GoEast();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Heading);
        }

        public void TurnRight(Board board)
        {
            if (head.Heading == Direction.East)
            {
                GoSouth();
            }else if (head.Heading == Direction.North)
            {
                GoEast();
            }else if (head.Heading == Direction.West)
            {
                GoNorth();
            }else if (head.Heading == Direction.South)
            {
                GoWest();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Heading);
        }

        public void MoveForwards(Board board)
        {
            if (head.Heading == Direction.East)
            {
                GoEast();
            }else if (head.Heading == Direction.North)
            {
                GoNorth();
            }else if (head.Heading == Direction.West)
            {
                GoWest();
            }else if (head.Heading == Direction.South)
            {
                GoSouth();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Heading);
        }

        private void GoNorth()
        {
            head.Reposition(head.X, head.Y + 1, Direction.North);
        }

        private void GoEast()
        {
            head.Reposition(head.X + 1, head.Y, Direction.East);
        }

        private void GoSouth()
        {
            head.Reposition(head.X, head.Y - 1, Direction.South);
        }

        private void GoWest()
        {
            head.Reposition(head.X - 1, head.Y , Direction.West);
        }
    }
}
