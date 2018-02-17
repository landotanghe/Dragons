using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
{
    public class ConsumeFireAction : DragonAction
    {
        public ConsumeFireAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override bool CanExecute()
        {
            return Dragon.CanConsumeFire();
        }

        public override void Execute()
        {
            var fire = GameEngine.ConsumeFire();
            Dragon.Consume(fire);
        }
    }
}
