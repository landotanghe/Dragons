using System.Linq;
using Assets.FuryEngine.Damages;
using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions.ActionPicker
{
    public class ActionExecutor
    {
        private readonly DragonX _dragon;
        private readonly GameEngine _game;
        private readonly AvailableOptions[] _availableOptions;

        private int _nextOptionToPick;


        public ActionExecutor(AvailableOptions[] availableOptions, DragonX dragon, GameEngine game)
        {
            _availableOptions = availableOptions;
            _dragon = dragon;
            _game = game;

            _nextOptionToPick = 0;
        }

        public bool CanPlay(Option option)
        {
            return HasToPickAnotherOption() 
                && OptionsThatAreAllowed().Contains(option);
        } 

        public Option[] OptionsThatAreAllowed()
        {
            return _availableOptions[_nextOptionToPick].For(_dragon);
        }

        public void Play(Option option)
        {
            option.Execute(_dragon);
            _nextOptionToPick++;
        }

        public bool HasToPickAnotherOption()
        {
            return _nextOptionToPick < _availableOptions.Count();
        }

        internal void ApplyBite()
        {
            if (_dragon.HasAttacked())
                return;

            var target = _game.GetOpponentOf(_dragon);
            var damageLocation = _dragon.Location + _dragon.Direction;
            if (target.Occupies(damageLocation))
            {
                _dragon.SetAttacked();
                target.TakeDamage(Damage.One);
            }
        }

        //public void PickOption(string optionName)
        //{
        //    nextOption = _availableOptions[0].For(dragon)
        //        .FirstOrDefault(o => o.Name == optionName);
        //}

        //public Option[] GetAvailableOptions()
        //{
        //    return _availableOptions[0].For(dragon);
        //}

        //public bool CanExecute()
        //{
        //    return nextOption != null && _availableOptions.First().For(dragon).Contains(nextOption);
        //}

        //public bool HasAdditionalMove()
        //{
        //    return false;
        //}

        //public void ExecuteNextOption()
        //{
        //    if(nextOption != null && _availableOptions.First().For(dragon).Contains(nextOption))
        //    {
        //        nextOption.Execute(dragon);

        //        _availableOptions = _availableOptions.Skip(1).ToArray();
        //        nextOption = null;
        //    }
        //}
    }
}
