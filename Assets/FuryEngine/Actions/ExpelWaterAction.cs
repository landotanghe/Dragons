using Assets.FuryEngine.Damages;
using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
{
    public class ExpelWaterAction : ExpelElementAction
    {
        public ExpelWaterAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override Damage ExpelElement(GameEngine board)
        {
            var waterInPool = board.GetWaterInPool();
            return Damage.FromValue(waterInPool.Amount);
        }
    }
}
