using Assets.ActionPicker.ElementsWheel.Actions;

namespace Assets
{
    public class WaterElement : WheelElementAction
    {        
        protected override AvailableOptions[] GetAvailableOptions()
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithWater, Option.ConsumeWater)
            };
        }        
    }
}
