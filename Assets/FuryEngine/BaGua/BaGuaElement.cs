using System;
using System.Linq;
using Assets.FuryEngine.Actions.ActionPicker;
using Assets.FuryEngine.Dragons;
using Assets.FuryEngine.Location;

namespace Assets.FuryEngine.BaGua
{
    public abstract class BaGuaElement {
        private DiscStack _discs;

        public BaGuaElement()
        {
            _discs = new DiscStack();
        }

        public BaGuaElement AddDisc(Disc disc)
        {
            if (disc == null)
                throw new ArgumentNullException("disc");

            _discs.Add(disc);
            return this;
        }

        public abstract BaGuaElementType Type { get; }

        public Disc[] RemoveAllDiscs()
        {
            return _discs.RemoveAll();
        }

        public int NumberOfDiscs{
            get
            {
                return _discs.Count;
            }
        }

        public bool CanExecuteAction(DragonX dragon, GameEngine board)
        {
            var firstMove = GetAvailableOptions(dragon, board)[0];

            return firstMove.For(dragon).Any();
        }

        protected abstract AvailableOptions[] GetAvailableOptions(Direction direction);

        public AvailableOptions[] GetAvailableOptions(DragonX dragon, GameEngine game)
        {
            var availableOptions = GetAvailableOptions(dragon.Direction);

            return availableOptions;
        }

        public PlayerColor[] GetDiscConfiguration()
        {
            return _discs.GetDiscConfiguration();
        }
    }
}
