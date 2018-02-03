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
            if(head.Direction == Direction.East)
            {
                GoNorth();
            }else if(head.Direction == Direction.North)
            {
                GoWest();
            }else if(head.Direction == Direction.West)
            {
                GoSouth();
            }else if(head.Direction == Direction.South)
            {
                GoEast();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Direction);
        }

        public void TurnRight(Board board)
        {
            if (head.Direction == Direction.East)
            {
                GoSouth();
            }else if (head.Direction == Direction.North)
            {
                GoEast();
            }else if (head.Direction == Direction.West)
            {
                GoNorth();
            }else if (head.Direction == Direction.South)
            {
                GoWest();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Direction);
        }

        public void MoveForwards(Board board)
        {
            if (head.Direction == Direction.East)
            {
                GoEast();
            }else if (head.Direction == Direction.North)
            {
                GoNorth();
            }else if (head.Direction == Direction.West)
            {
                GoWest();
            }else if (head.Direction == Direction.South)
            {
                GoSouth();
            }
            Debug.Log("(" + head.X + ", " + head.Y + ")" + head.Direction);
        }

        private void GoNorth()
        {
            MoveLastTailPartToHeadPosition(Direction.North);
            head.Reposition(head.X, head.Y + 1, Direction.North);
            head.SetDownStream(Direction.South);
        }


        private void GoEast()
        {
            MoveLastTailPartToHeadPosition(Direction.East);
            head.Reposition(head.X + 1, head.Y, Direction.East);
            head.SetDownStream(Direction.West);
        }

        private void GoSouth()
        {
            MoveLastTailPartToHeadPosition(Direction.South);
            head.Reposition(head.X, head.Y - 1, Direction.South);
            head.SetDownStream(Direction.North);
        }

        private void GoWest()
        {
            MoveLastTailPartToHeadPosition(Direction.West);
            head.Reposition(head.X - 1, head.Y , Direction.West);
            head.SetDownStream(Direction.East);
        }

        private void MoveLastTailPartToHeadPosition(Direction direction)
        {
            if (tail.Length == 0)
                return;

            MoveLastTailPartToHeadPosition();

            tail[0].Reposition(head.X, head.Y, direction);
            tail[0].SetDownStream(head.DownStream);
        }

        private void MoveLastTailPartToHeadPosition()
        {
            var lastTailPart = tail[tail.Length - 1];

            for (int i = tail.Length - 1; i > 0; i--)
            {
                tail[i] = tail[i - 1];
            }
            tail[0] = lastTailPart;
        }
    }
}
