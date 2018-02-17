using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua.Elements
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
