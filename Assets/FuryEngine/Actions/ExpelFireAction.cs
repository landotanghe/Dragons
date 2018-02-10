using Assets.Dragons.Damages;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons
{
    public class ExpelFireAction : ExpelElementAction
    {
        public ExpelFireAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
        }

        public override Damage ExpelElement(GameEngine board)
        {
            var exhaledFire = Dragon.ExhaleFire();
            board.AddFireToPool(exhaledFire);

            var fireDamage = Damage.FromValue(exhaledFire.Amount);
            return fireDamage;
        }
    }
}
