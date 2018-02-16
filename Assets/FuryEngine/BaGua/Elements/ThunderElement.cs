using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class ThunderElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Thunder;
            }
        }

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
