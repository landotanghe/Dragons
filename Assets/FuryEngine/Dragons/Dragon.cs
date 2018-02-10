using Assets.Dragons;
using Assets.Dragons.Actions;
using Assets.Dragons.Damages;
using FuryEngine;

namespace Assets.FuryEngine.DragonPackage
{
    public class DragonX
    {
        public PlayerColor Color { get; private set; }

        private BodyPart Head;
        private Tail Tail;
        private Health _tailHealth;
        private Fire _consumedFire;
        private GameEngine _gameEngine { get; set; }

        public DragonX(PlayerColor color, Location initialLocation, Direction direction, GameEngine gameEngine)
        {
            Color = color;
            _tailHealth = Health.Full;
            _consumedFire = Fire.Depleted;
            Head = new BodyPart();
            Head.Reposition(initialLocation, direction);
            Tail = new Tail();
            _gameEngine = gameEngine;
        }

        public Direction Direction
        {
            get
            {
                return Head.Direction;
            }
        }

        public Location Location { get
            {
                return Head.Location;
            }
        }


        public delegate void DragonTookDamageHandler(DragonTookDamageEvent @event);
        public static event DragonTookDamageHandler OnDragonTookDamage;

        public class DragonTookDamageEvent
        {
            public DragonTookDamageEvent(Tail tail, Health health, PlayerColor color)
            {
                TailLength = tail.Length;
                Health = health.LifePoints;
                Color = color;
            }

            public int TailLength { get; private set; }
            public int Health { get; private set; }
            public PlayerColor Color { get; private set; }
        }

        public Water TakeDamage(Damage damage)
        {
            var water = Water.Depleted;
            while(IsAlive() && damage.Value > 0)
            {
                if (_tailHealth.CanBear(Damage.One))
                {
                    water++;
                    damage--;
                }
                else
                {
                    _tailHealth = Health.Full;

                    damage = damage - _tailHealth.DamageToDestroy;
                    water -= _tailHealth.WaterNeededToHeal;
                }
            }

            OnDragonTookDamage(new DragonTookDamageEvent(Tail, _tailHealth, Color));
            return water;
        }
                
        private void LoseSegment()
        {
            Tail.RemoveSegment();
        }

        public bool IsAlive()
        {
            return Tail.Length > 0;
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

        public Fire ExhaleFire()
        {
            var fire = _consumedFire;
            _consumedFire = Fire.Depleted;

            return fire;
        }

        public class DragonMovedEvent
        {
            public Direction Direction { get; set; }
            public Location Location { get; set; }
            public PlayerColor Color { get; set; }
        }

        public delegate void DragonMovedEventHandler(DragonMovedEvent @event);
        public static event DragonMovedEventHandler MovedEventHandler;

        public void MoveTo(Location target, Direction direction)
        {
            Tail.MoveTo(Head.Location, direction);
            Head.Reposition(target, direction);

            if(MovedEventHandler != null)
            {
                MovedEventHandler(new DragonMovedEvent
                {
                    Location = target,
                    Direction = direction,
                    Color = Color
                });
            }
        }

        public bool Occupies(Location location)
        {
            return Head.Occupies(location) ||
                Tail.Occupies(location);
        }

        #region actions
        public Move TurnLeft()
        {
            var newDirection = Direction.TurnLeft();
            return new Move(this, newDirection, _gameEngine);
        }


        public Move TurnRight()
        {
            var newDirection = Direction.TurnRight();
            return new Move(this, newDirection, _gameEngine);
        }

        public Move MoveForwards()
        {
            return new Move(this, Direction, _gameEngine);
        }

        public ExpelFireAction ExpelFire()
        {
            return new ExpelFireAction(this, _gameEngine);
        }

        public ExpelWaterAction ExpelWater()
        {
            return new ExpelWaterAction(this, _gameEngine);
        }

        public ConsumeWaterAction ConsumeWater()
        {
            return new ConsumeWaterAction(this, _gameEngine);
        }

        public ConsumeFireAction ConsumeFire()
        {
            return new ConsumeFireAction(this, _gameEngine);
        }

        public DragonAction DoNothing()
        {
            return new DoNothing(this, _gameEngine);
        }


        //TODO refactor
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

        public DragonAction ChooseAdditionalSpirit()
        {
            if (_canRepeatSpirit == SpiritsConsumed.None)
            {
                _canRepeatSpirit = SpiritsConsumed.OneAdditionalAllowed;
            }
            else
            {
                _canRepeatSpirit = SpiritsConsumed.AdditionalUsedUp;
            }

            return new DoNothing(this, _gameEngine);
        }
        #endregion
    }
}
