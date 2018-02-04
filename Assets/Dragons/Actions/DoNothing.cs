namespace Assets.Dragons.Actions
{
    public class DoNothing : DragonAction
    {
        public DoNothing(Dragon dragon) : base(dragon)
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
