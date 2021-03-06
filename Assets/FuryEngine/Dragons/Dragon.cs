﻿using Assets.FuryEngine.Damages;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.Dragons
{
    public class DragonX
    {
        public PlayerColor Color { get; private set; }

        private BodyPart Head;
        private Tail Tail;
        private Fire _consumedFire;
        private DragonActionFactory _dragonActionFactory;

        public static DragonX CreateBlack(Location.Location initialLocation, GameEngine gameEngine)
        {
            var blackDragon = new DragonX(PlayerColor.Black, initialLocation, Direction.West, gameEngine);
            blackDragon.CreateAction().TurnRight().Execute();
            blackDragon.CreateAction().TurnRight().Execute();
            blackDragon.CreateAction().TurnRight().Execute();
            blackDragon.CreateAction().TurnRight().Execute();

            return blackDragon;
        }

        public static DragonX CreateWhite(Location.Location initialLocation, GameEngine gameEngine)
        {
            var whiteDragon = new DragonX(PlayerColor.White, initialLocation, Direction.South, gameEngine);
            whiteDragon.CreateAction().TurnLeft().Execute();
            whiteDragon.CreateAction().TurnLeft().Execute();
            whiteDragon.CreateAction().TurnLeft().Execute();
            whiteDragon.CreateAction().TurnLeft().Execute();

            return whiteDragon;
        }

        private DragonX(PlayerColor color, Location.Location initialLocation, Direction direction, GameEngine gameEngine)
        {
            Color = color;
            _consumedFire = Fire.Depleted;
            Head = new BodyPart();
            Head.Reposition(initialLocation, direction);
            Tail = new Tail();
            OnDragonHealed(new DragonHealthEventData(Tail, Color));
            OnDragonConsumedFire(new DragonFireEventData(_consumedFire, Color));

            _dragonActionFactory = new DragonActionFactory(this, gameEngine);
        }

        public Direction Direction
        {
            get
            {
                return Head.Direction;
            }
        }

        public Location.Location Location { get
            {
                return Head.Location;
            }
        }

        public DragonActionFactory CreateAction()
        {
            return _dragonActionFactory;
        }


        public delegate void DragonSpitFireHandler(DragonFireEventData @event);
        public static event DragonSpitFireHandler OnDragonSpitFire;

        public delegate void DragonConsumedFireHandler(DragonFireEventData @event);
        public static event DragonConsumedFireHandler OnDragonConsumedFire;

        public class DragonFireEventData
        {
            public DragonFireEventData(Fire fire, PlayerColor color)
            {
                ConsumedFire = fire.Amount;
                Color = color;
            }

            public int ConsumedFire { get; private set; }
            public PlayerColor Color { get; private set; }
        }

        public delegate void DragonTookDamageHandler(DragonHealthEventData @event);
        public static event DragonTookDamageHandler OnDragonTookDamage;

        public delegate void DragonHealedHandler(DragonHealthEventData @event);
        public static event DragonHealedHandler OnDragonHealed;

        public class DragonHealthEventData
        {
            public DragonHealthEventData(Tail tail, PlayerColor color)
            {
                TailLength = tail.Length;
                Health = tail._tailHealth.LifePoints;
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
                water += Tail.TakeDamage(damage);
            }

            OnDragonTookDamage(new DragonHealthEventData(Tail, Color));
            return water;
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

            OnDragonSpitFire(new DragonFireEventData(_consumedFire, Color));
        }

        public bool CanConsumeWater()
        {
            return Tail._tailHealth.LifePoints < 4;
        }

        public void Consume(Water water)
        {
            Tail.Heal(water);
            OnDragonHealed(new DragonHealthEventData(Tail, Color));
        }

        public Fire ExhaleFire()
        {
            var fire = _consumedFire;
            _consumedFire = Fire.Depleted;

            OnDragonSpitFire(new DragonFireEventData(_consumedFire, Color));
            return fire;
        }

        public class DragonMovedEvent
        {
            public Direction Direction { get; set; }
            public Location.Location Location { get; set; }
            public PlayerColor Color { get; set; }
        }

        public delegate void DragonMovedEventHandler(DragonMovedEvent @event);
        public static event DragonMovedEventHandler MovedEventHandler;

        public void MoveTo(Location.Location target, Direction direction)
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

        internal bool CanPickAnotherSpirit()
        {
            return _dragonActionFactory.CanPickAnotherSpirit();
        }

        internal void ResetActions()
        {
            attacked = false;
            _dragonActionFactory.ResetSpirits();
        }

        public bool Occupies(Location.Location location)
        {
            return Head.Occupies(location) ||
                Tail.Occupies(location);
        }

        #region actions
        //TODO refactor
        private bool attacked = false;
        public void SetAttacked()
        {
            attacked = false;
        }

        public bool HasAttacked()
        {
            return attacked;
        }

        #endregion
    }
}
