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
        
        public Move TurnLeft(Board board)
        {
            if(head.Direction == Direction.East)
            {
                return GoNorth();
            }else if(head.Direction == Direction.North)
            {
                return GoWest();
            }else if(head.Direction == Direction.West)
            {
                return GoSouth();
            }else if(head.Direction == Direction.South)
            {
                return GoEast();
            }
            throw new NotImplementedException();
        }

        public Move TurnRight(Board board)
        {
            if (head.Direction == Direction.East)
            {
                return GoSouth();
            }else if (head.Direction == Direction.North)
            {
                return GoEast();
            }else if (head.Direction == Direction.West)
            {
                return GoNorth();
            }else if (head.Direction == Direction.South)
            {
                return GoWest();
            }
            throw new NotImplementedException();
        }

        public Move MoveForwards(Board board)
        {
            if (head.Direction == Direction.East)
            {
                return GoEast();
            }else if (head.Direction == Direction.North)
            {
                return GoNorth();
            }else if (head.Direction == Direction.West)
            {
                return GoWest();
            }else if (head.Direction == Direction.South)
            {
                return GoSouth();
            }
            throw new NotImplementedException();
        }


        public class Move
        {
            private Dragon _dragon;
            public Direction Direction { get; private set; }
            public int X { get; private set; }
            public int Y { get; private set; }

            public Move(Dragon dragon, Direction direction, int x, int y)
            {
                _dragon = dragon;
                Direction = direction;
                X = x;
                Y = y;
            }

            public bool CanExecute(Board board)
            {
                return true;
            }

            public void Execute()
            {
                _dragon.MoveLastTailPartToHeadPosition(Direction);
                _dragon.head.Reposition(X, Y, Direction);

                Direction oppositeDirection = OppositeOf(Direction);
                _dragon.head.SetDownStream(oppositeDirection);
            }

            private Direction OppositeOf(Direction direction)
            {
                if (direction == Direction.North)
                    return Direction.South;
                if (direction == Direction.South)
                    return Direction.North;
                if (direction == Direction.East)
                    return Direction.West;
                return Direction.East;
            }
        }

        private Move GoNorth()
        {
            return new Move(this, Direction.North, head.X, head.Y + 1);
        }



        private Move GoEast()
        {
            return new Move(this, Direction.East, head.X + 1, head.Y);
        }

        private Move GoSouth()
        {
            return new Move(this, Direction.South, head.X, head.Y - 1);
        }

        private Move GoWest()
        {
            return new Move(this, Direction.West, head.X - 1, head.Y);
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
