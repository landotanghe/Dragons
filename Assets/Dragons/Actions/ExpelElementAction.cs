using Assets.Dragons.Damages;
using System.Linq;

namespace Assets.Dragons
{
    public abstract class ExpelElementAction : DragonAction
    {
        protected Location _fullDamageLocation;
        protected Location[] _partialDamageLocations;
        protected Location _noDistanceDamageLocation;

        public ExpelElementAction(Dragon dragon) : base(dragon)
        {
            _fullDamageLocation = Dragon.head.Location + Dragon.head.Direction;
            _partialDamageLocations = new[]
            {
                    _fullDamageLocation + Dragon.head.Direction,
                    _fullDamageLocation + Dragon.head.Direction.TurnLeft(),
                    _fullDamageLocation + Dragon.head.Direction.TurnRight(),
                };
            _noDistanceDamageLocation = _fullDamageLocation
                + Dragon.head.Direction
                + Dragon.head.Direction;
        }

        public override bool CanExecute()
        {
            return CanReachEnemy();
        }

        protected Damage DistanceDamage()
        {
            var target = Board.GetOpponentOf(Dragon);
            if (target.Occupies(_fullDamageLocation))
                return Damage.FromValue(2);
            if (_partialDamageLocations.Any(location => target.Occupies(location)))
                return Damage.FromValue(1);
            return Damage.None;
        }

        private bool CanReachEnemy()
        {
            var target = Board.GetOpponentOf(Dragon);

            return target.Occupies(_fullDamageLocation) ||
                _partialDamageLocations.Any(location => target.Occupies(location)) && Board.IsFreeSpace(_fullDamageLocation) ||
                target.Occupies(_noDistanceDamageLocation) && Board.IsFreeSpace(_fullDamageLocation) && Board.IsFreeSpace(_partialDamageLocations[0]);
        }

        public override void Execute()
        {
            Dragon.SetAttacked();

            var target = Board.GetOpponentOf(Dragon);

            var distanceDamage = DistanceDamage();
            var expelDamage = ExpelElement(Board);

            target.TakeDamage(distanceDamage + expelDamage);
        }

        public abstract Damage ExpelElement(Board board);

    }
}
