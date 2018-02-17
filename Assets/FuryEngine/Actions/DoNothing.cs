using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
{
    public class DoNothing : DragonAction
    {
        public DoNothing(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
        }
    }
}
