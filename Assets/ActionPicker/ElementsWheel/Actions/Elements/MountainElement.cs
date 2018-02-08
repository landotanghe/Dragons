using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class MountainElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsHorizontal)
            {
                return new[]
                {
                    AvailableOptions.AnyMove()
                };
            }
            else
            {
                return new[]
                {
                    AvailableOptions.Are(Option.NoOperation)
                };
            }
        }
    }
}
