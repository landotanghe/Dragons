using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
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
