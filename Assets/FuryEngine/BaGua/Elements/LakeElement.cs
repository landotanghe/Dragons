using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
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
