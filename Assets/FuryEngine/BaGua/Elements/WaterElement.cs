using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using Assets.FuryEngine.BaGua;

namespace Assets
{
    public class WaterElement : BaGuaElement
    {
        public override BaGuaElementType Type
        {
            get
            {
                return BaGuaElementType.Water;
            }
        }


        protected override AvailableOptions[] GetAvailableOptions(Direction direction)
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithWater, Option.ConsumeWater, Option.NoOperation)
            };
        }        
    }
}
