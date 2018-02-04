using Assets.Dragons;
using System;
using System.Linq;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class AvailableOptions
    {
        private Option[] _options;

        public static AvailableOptions Are(params Option[] options)
        {
            return new AvailableOptions
            {
                _options = options
            };
        }
        
        internal static AvailableOptions AnyMove()
        {
            return AvailableOptions.Are(Option.Left, Option.Right, Option.Forward);
        }

        public Option[] For(Dragon dragon)
        {
            return _options.Where(o => o.CanExecute(dragon)).ToArray();
        }
    }
}
