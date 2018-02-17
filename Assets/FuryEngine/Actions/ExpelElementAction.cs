using System.Linq;
using Assets.FuryEngine.Damages;
using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
{
    public abstract class ExpelElementAction : DragonAction
    {
        protected Location.Location _fullDamageLocation;
        protected Location.Location[] _partialDamageLocations;
        protected Location.Location _noDistanceDamageLocation;

        public ExpelElementAction(DragonX dragon, GameEngine game) : base(dragon, game)
        {
            _fullDamageLocation = Dragon.Location + Dragon.Direction;
            _partialDamageLocations = new[]
            {
                    _fullDamageLocation + Dragon.Direction,
                    _fullDamageLocation + Dragon.Direction.TurnLeft(),
                    _fullDamageLocation + Dragon.Direction.TurnRight(),
                };
            _noDistanceDamageLocation = _fullDamageLocation
                + Dragon.Direction
                + Dragon.Direction;
        }

        public override bool CanExecute()
        {
            return CanReachEnemy();
        }

        protected Damage DistanceDamage()
        {
            var target = GameEngine.GetOpponentOf(Dragon);
            if (target.Occupies(_fullDamageLocation))
                return Damage.FromValue(2);
            if (_partialDamageLocations.Any(location => target.Occupies(location)))
                return Damage.FromValue(1);
            return Damage.None;
        }

        private bool CanReachEnemy()
        {
            var target = GameEngine.GetOpponentOf(Dragon);

            return target.Occupies(_fullDamageLocation) ||
                _partialDamageLocations.Any(location => target.Occupies(location)) && GameEngine.IsFreeSpace(_fullDamageLocation) ||
                target.Occupies(_noDistanceDamageLocation) && GameEngine.IsFreeSpace(_fullDamageLocation) && GameEngine.IsFreeSpace(_partialDamageLocations[0]);
        }

        public override void Execute()
        {
            Dragon.SetAttacked();

            var target = GameEngine.GetOpponentOf(Dragon);

            var distanceDamage = DistanceDamage();
            var expelDamage = ExpelElement(GameEngine);

            target.TakeDamage(distanceDamage + expelDamage);
        }

        public abstract Damage ExpelElement(GameEngine board);

    }
}
