using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;

namespace Assets
{
    public class WaterAction : IAction
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
