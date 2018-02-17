using Assets.FuryEngine.Damages;
using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
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
