using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua.Elements
{
    public class LakeElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Lake;
            }
        }

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
