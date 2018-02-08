using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class EarthElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsVertical)
                return new AvailableOptions[0] {};

            return new[]
            {
                AvailableOptions.Are(Option.Forward),
                AvailableOptions.Are(Option.Forward, Option.NoOperation)
            };
        }
    }
}
