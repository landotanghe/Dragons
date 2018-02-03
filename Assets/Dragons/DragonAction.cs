namespace Assets.Dragons
{
    public interface DragonAction
    {
        bool CanExecute(Board board);
        void Execute(Board board);
    }
}