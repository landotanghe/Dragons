using Assets.Dragons.Actions;
using Assets.Dragons.Damages;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public Head head;
        public TailSegment[] tail;
        public Board board;

        public Bar fireBar;
        public Bar waterBar;

        private Health _tailHealth;
        private Fire _consumedFire;
        
        public Dragon()
        {
            _tailHealth = Health.Full;
            _consumedFire = Fire.Depleted;
        }
        
        public void Update()
        {
            fireBar.fillRate = _consumedFire.Amount;
            waterBar.fillRate = _tailHealth.LifePoints;
        }
        
        public void TakeDamage(Damage damage)
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

        public DragonAction DoNothing()
        {
            return new DoNothing(this);
        }

        public bool CanConsumeFire()
        {
            return _consumedFire.Amount < 4;
        }

        public void Consume(Fire fire)
        {
            _consumedFire = _consumedFire + fire;
        }

        public bool CanConsumeWater()
        {
            return _tailHealth.LifePoints < 4;
        }

        public void Consume(Water water)
        {
            _tailHealth = _tailHealth + water;
        }

        public void SetAttacked()
        {
            attacked = false;
        }

        public bool HasAttacked()
        {
            return attacked;
        }

        private SpiritsConsumed _canRepeatSpirit;
        private bool attacked = false;
        internal void ResetSpirits()
        {
            _canRepeatSpirit = SpiritsConsumed.None;
            attacked = false;
        }

        public bool CanPickAnotherSpirit()
        {
            return _canRepeatSpirit == SpiritsConsumed.OneAdditionalAllowed;
        }

        internal DragonAction ChooseAdditionalSpirit()
        {
            if(_canRepeatSpirit == SpiritsConsumed.None)
            {
                _canRepeatSpirit = SpiritsConsumed.OneAdditionalAllowed;
            }
            else
            {
                _canRepeatSpirit = SpiritsConsumed.AdditionalUsedUp;
            }

            return new DoNothing(this);
        }

        private void LoseSegment()
        {
            tail = tail.Take(tail.Length - 1).ToArray();
        }
        
        public bool IsAlive()
        {
            return tail.Any();
        }
        
        public Move TurnLeft()
        {
            var newDirection = head.Direction.TurnLeft();
            return new Move(this, newDirection);
        }

        public bool Occupies(Location location)
        {
            return head.Occupies(location) || 
                tail.Any(part => part.Occupies(location));
        }

        public Move TurnRight()
        {
            var newDirection = head.Direction.TurnRight();
            return new Move(this, newDirection);
        }

        public Move MoveForwards()
        {
            return new Move(this, head.Direction);
        }

        public ExpelFireAction ExpelFire()
        {
            return new ExpelFireAction(this);
        }          
        
        public ExpelWaterAction ExpelWater()
        {
            return new ExpelWaterAction(this);
        }

        public ConsumeWaterAction ConsumeWater()
        {
            return new ConsumeWaterAction(this);
        }

        public ConsumeFireAction ConsumeFire()
        {
            return new ConsumeFireAction(this);
        }

        public Fire ExhaleFire()
        {
            var fire = _consumedFire;
            _consumedFire = Fire.Depleted;

            return fire;
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