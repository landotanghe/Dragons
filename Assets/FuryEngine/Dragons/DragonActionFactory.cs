using Assets.Dragons;
using Assets.FuryEngine.Actions;

namespace Assets.FuryEngine.Dragons
{
    public class DragonActionFactory
    {
        private SpiritsConsumed ConsumedSpirits;

        private DragonX _dragon;
        private GameEngine _gameEngine;

        public DragonActionFactory(DragonX dragon, GameEngine gameEngine)
        {
            _dragon = dragon;
            _gameEngine = gameEngine;
        }

        public Move TurnLeft()
        {
            var newDirection = _dragon.Direction.TurnLeft();
            return new Move(_dragon, newDirection, _gameEngine);
        }

        public Move TurnRight()
        {
            var newDirection = _dragon.Direction.TurnRight();
            return new Move(_dragon, newDirection, _gameEngine);
        }

        public Move MoveForwards()
        {
            return new Move(_dragon, _dragon.Direction, _gameEngine);
        }

        public ExpelFireAction ExpelFire()
        {
            return new ExpelFireAction(_dragon, _gameEngine);
        }

        public ExpelWaterAction ExpelWater()
        {
            return new ExpelWaterAction(_dragon, _gameEngine);
        }

        public ConsumeWaterAction ConsumeWater()
        {
            return new ConsumeWaterAction(_dragon, _gameEngine);
        }

        public ConsumeFireAction ConsumeFire()
        {
            return new ConsumeFireAction(_dragon, _gameEngine);
        }

        public DragonAction DoNothing()
        {
            return new DoNothing(_dragon, _gameEngine);
        }



        internal void ResetSpirits()
        {
            ConsumedSpirits = SpiritsConsumed.None;
        }

        public bool CanPickAnotherSpirit()
        {
            return ConsumedSpirits == SpiritsConsumed.OneAdditionalAllowed;
        }

        public DragonAction ChooseAdditionalSpirit()
        {
            if (ConsumedSpirits == SpiritsConsumed.None)
            {
                ConsumedSpirits = SpiritsConsumed.OneAdditionalAllowed;
            }
            else
            {
                ConsumedSpirits = SpiritsConsumed.AdditionalUsedUp;
            }

            return new DoNothing(_dragon, _gameEngine);
        }
    }
}
