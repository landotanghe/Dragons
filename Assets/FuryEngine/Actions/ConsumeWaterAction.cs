using Assets.FuryEngine.DragonPackage;
using FuryEngine;
using System;

namespace Assets.Dragons.Actions
{
    public class ConsumeWaterAction : DragonAction
    {
        public ConsumeWaterAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override bool CanExecute()
        {
            return Dragon.CanConsumeFire();
        }

        public override void Execute()
        {
            var water = GameEngine.ConsumeWater();
            Dragon.Consume(water);
        }
    }
}
