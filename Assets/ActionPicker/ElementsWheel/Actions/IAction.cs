using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using UnityEngine;

namespace Assets
{
    public abstract class IAction : MonoBehaviour
    {
        public abstract bool CanExecute(Dragon dragon, Board board);
        public abstract void Execute(Dragon dragon, Board board);
        public abstract AvailableOptions[] GetAvailableOptions();

        public AvailableOptions[] GetAvailableOptions(Dragon dragon, Board board)
        {
            var availableOptions = GetAvailableOptions();
            RemoveInvalidMoves(dragon, board, availableOptions);

            return availableOptions;
        }

        private static void RemoveInvalidMoves(Dragon dragon, Board board, AvailableOptions[] availableOptions)
        {
            if (!dragon.CanTurnLeft(board))
            {
                RemoveOption(availableOptions, Option.Left);
            }

            if (!dragon.CanTurnRight(board))
            {
                RemoveOption(availableOptions, Option.Right);
            }

            if (!dragon.CanMoveForwards(board))
            {
                RemoveOption(availableOptions, Option.Forward);
            }
        }

        private static void RemoveOption(AvailableOptions[] availableOptions, Option optionToRemove)
        {
            foreach (var optionList in availableOptions)
            {
                optionList.RemoveOption(optionToRemove);
            }
        }
    }
}
