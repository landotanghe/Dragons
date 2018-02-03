using Assets.Dragons.Damages;

namespace Assets.Dragons
{
    public class ExpelWaterAction : ExpelElementAction
    {
        public ExpelWaterAction(Dragon dragon) : base(dragon)
        {
        }

        public override Damage ExpelElement(Board board)
        {
            var waterInPool = board.GetWaterInPool();
            return Damage.FromValue(waterInPool.Amount);
        }
    }
}
