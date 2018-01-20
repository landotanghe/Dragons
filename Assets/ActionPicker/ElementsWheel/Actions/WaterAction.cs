using System.Collections.Generic;
using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;

namespace Assets
{
    public class WaterAction : IAction
    {
        public override bool CanExecute(Dragon dragon, Board board)
        {
            throw new System.NotImplementedException();
        }
        
        public override void Execute(Dragon dragon, Board board)
        {
            throw new System.NotImplementedException();
        }

        public override AvailableOptions[] GetAvailableOptions()
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithWater, Option.ConsumeWater)
            };
        }

        private static AvailableOptions AnyMove()
        {
            return Are(Option.Left, Option.Right, Option.Forward);
        }
    }
}
