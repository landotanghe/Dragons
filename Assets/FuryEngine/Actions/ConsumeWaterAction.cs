using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
{
    public class ConsumeWaterAction : DragonAction
    {
        public ConsumeWaterAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override bool CanExecute()
        {
            return Dragon.CanConsumeFire();
        }

        public override void Execute()
        {
            var water = GameEngine.ConsumeWater();
            Dragon.Consume(water);
        }
    }
}
