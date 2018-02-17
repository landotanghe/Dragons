using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua.Elements
{
    public class WindElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Wind;
            }
        }

        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            if (direction.IsHorizontal)
                return new AvailableOptions[0] { };

            return new[]
            {
                AvailableOptions.Are(Option.Left, Option.Right),
                AvailableOptions.Are(Option.AdditionalSpiritPhase)
            };
        }
    }
}
