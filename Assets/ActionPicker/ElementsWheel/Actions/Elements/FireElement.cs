using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class FireElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithFire, Option.ConsumeFire, Option.NoOperation)
            };
        }
    }
}
