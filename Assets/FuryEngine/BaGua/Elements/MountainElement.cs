using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua.Elements
{
    public class MountainElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Mountain;
            }
        }


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
