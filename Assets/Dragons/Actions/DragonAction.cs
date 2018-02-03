namespace Assets.Dragons
{
    public abstract class DragonAction
    {
        protected Dragon Dragon { get; private set; }
        protected Board Board { get; private set; }

        public DragonAction(Dragon dragon)
        {
            Board = dragon.board;
            Dragon = dragon;
        }

        public abstract bool CanExecute();
        public abstract void Execute();
    }
}