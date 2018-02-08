using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;

namespace Assets
{
    public class WaterElement : WheelElementAction
    {        
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithWater, Option.ConsumeWater, Option.NoOperation)
            };
        }        
    }
}
