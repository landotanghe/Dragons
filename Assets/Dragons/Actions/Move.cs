namespace Assets.Dragons
{
    public class Move : DragonAction
    {
        private Dragon _dragon;
        public Direction Direction { get; private set; }
        public Location _target;

        public Move(Dragon dragon, Direction direction)
        {
            _dragon = dragon;
            Direction = direction;
            _target = _dragon.head.Location + direction;
        }

        public bool CanExecute(Board board)
        {
            return board.IsFreeSpace(_target);
        }

        public void Execute(Board board)
        {
            _dragon.MoveTo(_target, Direction);
        }
    }
}
