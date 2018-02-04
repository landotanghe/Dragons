using System;
using Assets.Dragons;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class ActionExecutor
    {
        private Dragon dragon;
        private Board board;

        private WheelElementAction _action;
        private Option[] _options;
        private int nextOptionToChoose = 0;
        private AvailableOptions[] _availableOptions;

        public ActionExecutor(WheelElementAction action, Dragon dragon, Board board)
        {
            _availableOptions = _action.GetAvailableOptions(dragon, board);

            _action = action;
            _options = new Option[_availableOptions.Length];
        }

        public bool IsValidOption(int optionIndex)
        {
            return optionIndex >= 0
                && nextOptionToChoose < _availableOptions.Length
                && optionIndex < _availableOptions[nextOptionToChoose].Options.Length;
        }

        public void PickOption(int optionToPick)
        {
            _options[nextOptionToChoose] = _availableOptions[nextOptionToChoose].Options[optionToPick];
            nextOptionToChoose++;
        }

        public Option[] GetAvailableOptions()
        {
            return _availableOptions[nextOptionToChoose].Options;
        }

        public bool CanExecute()
        {
            return nextOptionToChoose == _options.Length;
        }

        public bool HasAdditionalMove()
        {
            return false;
        }

        public void Execute()
        {
            _action.Execute(dragon, board, _options);
        }
    }
}
