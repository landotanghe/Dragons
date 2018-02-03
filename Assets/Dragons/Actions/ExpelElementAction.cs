using Assets.Dragons.Damages;
using System.Linq;

namespace Assets.Dragons
{
    public abstract class ExpelElementAction : DragonAction
    {
        protected Dragon _dragon;
        protected Location _fullDamageLocation;
        protected Location[] _partialDamageLocations;
        protected Location _noDistanceDamageLocation;

        public ExpelElementAction(Dragon dragon)
        {
            _dragon = dragon;
            _fullDamageLocation = _dragon.head.Location + _dragon.head.Direction;
            _partialDamageLocations = new[]
            {
                    _fullDamageLocation + _dragon.head.Direction,
                    _fullDamageLocation + _dragon.head.Direction.TurnLeft(),
                    _fullDamageLocation + _dragon.head.Direction.TurnRight(),
                };
            _noDistanceDamageLocation = _fullDamageLocation
                + _dragon.head.Direction
                + _dragon.head.Direction;
        }

        public bool CanExecute(Board board)
        {
            return CanReachEnemy(board);
        }

        protected Damage DistanceDamage(Board board)
        {
            var target = board.GetOpponentOf(_dragon);
            if (target.Occupies(_fullDamageLocation))
                return Damage.FromValue(2);
            if (_partialDamageLocations.Any(location => target.Occupies(location)))
                return Damage.FromValue(1);
            return Damage.None;
        }

        private bool CanReachEnemy(Board board)
        {
            var target = board.GetOpponentOf(_dragon);

            return target.Occupies(_fullDamageLocation) ||
                _partialDamageLocations.Any(location => target.Occupies(location)) && board.IsFreeSpace(_fullDamageLocation) ||
                target.Occupies(_noDistanceDamageLocation) && board.IsFreeSpace(_fullDamageLocation) && board.IsFreeSpace(_partialDamageLocations[0]);
        }

        public void Execute(Board board)
        {
            var target = board.GetOpponentOf(_dragon);

            var distanceDamage = DistanceDamage(board);
            var expelDamage = ExpelElement(board);

            target.TakeDamage(distanceDamage + expelDamage, board);
        }

        public abstract Damage ExpelElement(Board board);

    }
}
