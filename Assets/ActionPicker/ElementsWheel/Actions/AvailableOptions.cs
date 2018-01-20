using System.Linq;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class AvailableOptions
    {
        public Option[] Options { get; set; }

        public static AvailableOptions Are(params Option[] options)
        {
            return new AvailableOptions
            {
                Options = options
            };
        }

        public void RemoveOption(Option optionToRemove)
        {
            Options = Options.Where(o => o != Option.Left).ToArray();
        }
    }
}
