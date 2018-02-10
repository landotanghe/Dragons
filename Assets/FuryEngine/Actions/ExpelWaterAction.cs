using Assets.Dragons.Damages;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons
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
