using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class ThunderElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsVertical)
                return new AvailableOptions[0] { };

            return new[]
            {
                AvailableOptions.Are(Option.Left, Option.Right),
                AvailableOptions.Are(Option.AdditionalSpiritPhase)
            };
        }
    }
}
