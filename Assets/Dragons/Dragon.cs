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

        private void TakeDamage(Damage damage, Board board)
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

        public abstract class ExpelElementAction : DragonAction
        {
            protected Dragon _dragon;
            protected Location _fullDamageLocation;
            protected Location[] _partialDamageLocations;
            protected Location _noDistanceDamageLocation;

            public ExpelElementAction(Dragon dragon)
            {
                _dragon = dragon;
                _fullDamageLocation = _dragon.head.Location + _dragon.head.Direction;
                _partialDamageLocations = new[]
                {
                    _fullDamageLocation + _dragon.head.Direction,
                    _fullDamageLocation + _dragon.head.Direction.TurnLeft(),
                    _fullDamageLocation + _dragon.head.Direction.TurnRight(),
                };
                _noDistanceDamageLocation = _fullDamageLocation
                    + _dragon.head.Direction
                    + _dragon.head.Direction;
            }

            public bool CanExecute(Board board)
            {
                return CanReachEnemy(board);
            }

            protected Damage DistanceDamage(Board board)
            {
                var target = board.GetOpponentOf(_dragon);
                if (target.Occupies(_fullDamageLocation))
                    return Damage.FromValue(2);
                if (_partialDamageLocations.Any(location => target.Occupies(location)))
                    return Damage.FromValue(1);
                return Damage.None;
            }

            private bool CanReachEnemy(Board board)
            {
                var target = board.GetOpponentOf(_dragon);

                return target.Occupies(_fullDamageLocation) ||
                    _partialDamageLocations.Any(location => target.Occupies(location)) && board.IsFreeSpace(_fullDamageLocation) ||
                    target.Occupies(_noDistanceDamageLocation) && board.IsFreeSpace(_fullDamageLocation) && board.IsFreeSpace(_partialDamageLocations[0]);
            }

            public void Execute(Board board)
            {
                var target = board.GetOpponentOf(_dragon);
                
                var distanceDamage = DistanceDamage(board);
                var expelDamage = ExpelElement(board);

                target.TakeDamage(distanceDamage + expelDamage, board);
            }

            public abstract Damage ExpelElement(Board board);

        }

        public class ExpelWaterAction : ExpelElementAction
        {
            public ExpelWaterAction(Dragon dragon) : base(dragon)
            {
            }

            public override Damage ExpelElement(Board board)
            {
                var waterInPool = board.GetWaterInPool();
                return Damage.FromValue(waterInPool.Amount);
            }
        }

        public class ExpelFireAction : ExpelElementAction
        {
            public ExpelFireAction(Dragon dragon) : base(dragon)
            {
            }

            public override Damage ExpelElement(Board board)
            {
                var exhaledFire = _dragon.ExhaleFire();
                board.AddFireToPool(exhaledFire);

                var fireDamage = Damage.FromValue(exhaledFire.Amount);
                return fireDamage;
            }
        }

        private Fire ExhaleFire()
        {
            var fire = _consumedFire;
            _consumedFire = Fire.Depleted;

            return fire;
        }

        public class Move : DragonAction
        {
            private Dragon _dragon;
            public Direction Direction { get; private set; }
            public Location _target;

            public Move(Dragon dragon, Direction direction)
            {
                _dragon = dragon;
                Direction = direction;
                _target = _dragon.head.Location + direction;
            }

            public bool CanExecute(Board board)
            {
                return board.IsFreeSpace(_target);
            }

            public void Execute(Board board)
            {
                _dragon.MoveLastTailPartToHeadPosition(Direction);
                _dragon.head.Reposition(_target, Direction);

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

        private void MoveLastTailPartToHeadPosition(Direction direction)
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
