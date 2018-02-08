using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class LakeElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsVertical)
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
