using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using System;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public abstract class IAction : MonoBehaviour
    {
        public bool CanExecute(Dragon dragon, Board board)
        {
            var firstMove = GetAvailableOptions(dragon, board)[0];

            return firstMove.Options.Any();
        }

        protected abstract AvailableOptions[] GetAvailableOptions();

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
        
        public void Execute(Dragon dragon, Board board, Option[] options)
        {
            foreach(var option in options)
            {
                //TODO what with checking if can move right twice, right up...
                switch (option)
                {
                    case Option.NoOperation:
                        return;
                    case Option.Left:
                        dragon.TurnLeft(board);
                        return;
                    case Option.Right:
                        dragon.TurnRight(board);
                        return;
                    case Option.Forward:
                        dragon.MoveForwards(board);
                        return;
                    case Option.ConsumeFire:
                        return;
                    case Option.ConsumeWater:
                        return;
                    case Option.AttackWithFire:
                        return;
                    case Option.AttackWithWater:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException(option.ToString());
                }
            }
        }
    }
}
