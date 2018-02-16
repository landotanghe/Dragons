using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class EarthElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Earth;
            }
        }

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
