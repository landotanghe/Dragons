using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons
{
    public class Move : DragonAction
    {
        public Direction Direction { get; private set; }
        public Location _target;

        public Move(DragonX dragon, Direction direction, GameEngine game) : base(dragon, game)
        {
            Direction = direction;
            _target = Dragon.Location + direction;
        }

        public override bool CanExecute()
        {
            return GameEngine.IsFreeSpace(_target);
        }

        public override void Execute()
        {
            Dragon.MoveTo(_target, Direction);
        }
    }
}
