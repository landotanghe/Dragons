using Assets.Dragons.Damages;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons.Actions
{
    public class BiteAction : DragonAction
    {
        public BiteAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override bool CanExecute()
        {
            var enemy = GameEngine.GetOpponentOf(Dragon);
            var biteLocation = Dragon.Location + Dragon.Direction;

            return enemy.Occupies(biteLocation);
        }

        public override void Execute()
        {
            var enemy = GameEngine.GetOpponentOf(Dragon);
            enemy.TakeDamage(Damage.One);
        }
    }
}
