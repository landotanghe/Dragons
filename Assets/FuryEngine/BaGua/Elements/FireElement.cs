using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua.Elements
{
    public class FireElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Fire;
            }
        }

        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithFire, Option.ConsumeFire, Option.NoOperation)
            };
        }
    }
}
