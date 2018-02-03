using Assets.Dragons.Damages;

namespace Assets.Dragons
{
    public class ExpelFireAction : ExpelElementAction
    {
        public ExpelFireAction(Dragon dragon) : base(dragon)
        {
        }

        public override Damage ExpelElement(Board board)
        {
            var exhaledFire = Dragon.ExhaleFire();
            board.AddFireToPool(exhaledFire);

            var fireDamage = Damage.FromValue(exhaledFire.Amount);
            return fireDamage;
        }
    }
}
