namespace Assets.Dragons.Actions
{
    public class ConsumeFireAction : DragonAction
    {
        public ConsumeFireAction(Dragon dragon) : base(dragon)
        {
        }

        public override bool CanExecute()
        {
            return Dragon.CanConsumeFire();
        }

        public override void Execute()
        {
            var fire = Board.ConsumeFire();
            Dragon.Consume(fire);
        }
    }
}
