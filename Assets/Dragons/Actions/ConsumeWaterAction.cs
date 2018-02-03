using System;

namespace Assets.Dragons.Actions
{
    public class ConsumeWaterAction : DragonAction
    {
        public ConsumeWaterAction(Dragon dragon) : base(dragon)
        {
        }

        public override bool CanExecute()
        {
            return Dragon.CanConsumeFire();
        }

        public override void Execute()
        {
            var water = Board.ConsumeWater();
            Dragon.Consume(water);
        }
    }
}
