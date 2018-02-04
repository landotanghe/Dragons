using System;
using System.Linq;
using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class ActionExecutor
    {
        private Dragon dragon;
        private Board board;

        private WheelElementAction _action;
        private Option nextOption;

        private AvailableOptions[] _availableOptions;

        public ActionExecutor(WheelElementAction action, Dragon dragon, Board board)
        {
            _availableOptions = _action.GetAvailableOptions(dragon, board);
            _action = action;
        }
        
        public void PickOption(string optionName)
        {
            nextOption = _availableOptions[0].For(dragon)
                .FirstOrDefault(o => o.Name == optionName);
        }

        public Option[] GetAvailableOptions()
        {
            return _availableOptions[0].For(dragon);
        }

        public bool CanExecute()
        {
            return nextOption != null && _availableOptions.First().For(dragon).Contains(nextOption);
        }

        public bool HasAdditionalMove()
        {
            return false;
        }

        public void ExecuteNextOption()
        {
            if(nextOption != null && _availableOptions.First().For(dragon).Contains(nextOption))
            {
                nextOption.Execute(dragon);

                _availableOptions = _availableOptions.Skip(1).ToArray();
                nextOption = null;
            }
        }
    }
}
