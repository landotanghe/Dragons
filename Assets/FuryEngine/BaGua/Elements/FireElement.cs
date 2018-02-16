using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
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
