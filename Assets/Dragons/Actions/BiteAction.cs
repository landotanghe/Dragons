using Assets.Dragons.Damages;

namespace Assets.Dragons.Actions
{
    public class BiteAction : DragonAction
    {
        public BiteAction(Dragon dragon) : base(dragon)
        {
        }

        public override bool CanExecute()
        {
            var enemy = Board.GetOpponentOf(Dragon);
            var biteLocation = Dragon.head.Location + Dragon.head.Direction;

            return enemy.Occupies(biteLocation);
        }

        public override void Execute()
        {
            var enemy = Board.GetOpponentOf(Dragon);
            enemy.TakeDamage(Damage.One);
        }
    }
}
