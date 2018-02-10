using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons.Actions
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
