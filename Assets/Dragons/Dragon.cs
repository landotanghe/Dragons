using Assets.Dragons.Damages;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        private Health _tailHealth;
        private Fire _consumedFire;
        public Head head;
        public TailSegment[] tail;
        
        public Dragon()
        {
            _tailHealth = Health.Full;
            _consumedFire = Fire.Depleted;
        }

        public void FixedUpdate()
        {
        }

        public void TakeDamage(Damage damage, Board board)
        {
            while (!_tailHealth.CanBear(damage) && IsAlive())
            {
                LoseSegment();
                damage = damage - Damage.FullSegment;
            }

            if (IsAlive())
            {
                _tailHealth = _tailHealth - damage;
                board.AddWaterToPool(new Water(damage.Value));
            }
        }

        private void LoseSegment()
        {
            tail = tail.Take(tail.Length - 1).ToArray();
        }
        
        public bool IsAlive()
        {
            return tail.Any();
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

        public bool Occupies(Location location)
        {
            return head.Occupies(location) || 
                tail.Any(part => part.Occupies(location));
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

        public ExpelFireAction ThrowFire()
        {
            return new ExpelFireAction(this);
        }                      

        public Fire ExhaleFire()
        {
            var fire = _consumedFire;
            _consumedFire = Fire.Depleted;

            return fire;
        }                

        private Move GoNorth()
        {
            return new Move(this, Direction.North);
        }

        private Move GoEast()
        {
            return new Move(this, Direction.East);
        }

        private Move GoSouth()
        {
            return new Move(this, Direction.South);
        }

        private Move GoWest()
        {
            return new Move(this, Direction.West);
        }

        public void MoveTo(Location target, Direction direction)
        {
            MoveLastTailPartToHeadPosition(direction);
            head.Reposition(target, direction);

            head.SetDownStream(direction.Invert());
        }

        public void MoveLastTailPartToHeadPosition(Direction direction)
        {
            if (tail.Length == 0)
                return;

            MoveLastTailPartToHeadPosition();

            tail[0].Reposition(head.Location, direction);
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