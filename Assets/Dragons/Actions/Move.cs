namespace Assets.Dragons
{
    public class Move : DragonAction
    {
        public Direction Direction { get; private set; }
        public Location _target;

        public Move(Dragon dragon, Direction direction) : base(dragon)
        {
            Direction = direction;
            _target = Dragon.head.Location + direction;
        }

        public override bool CanExecute()
        {
            return Board.IsFreeSpace(_target);
        }

        public override void Execute()
        {
            Dragon.MoveTo(_target, Direction);
        }
    }
}
