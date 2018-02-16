using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class SkyElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Sky;
            }
        }


        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsHorizontal)
                return new AvailableOptions[0] { };

            return new[]
            {
                AvailableOptions.Are(Option.Forward),
                AvailableOptions.Are(Option.Forward, Option.NoOperation)
            };
        }
    }
}
