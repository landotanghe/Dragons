using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using System;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public abstract class WheelElementAction : MonoBehaviour
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
            if (!dragon.MoveForwards().CanExecute())
            {
                RemoveOption(availableOptions, Option.Left);
            }

            if (!dragon.TurnRight().CanExecute())
            {
                RemoveOption(availableOptions, Option.Right);
            }

            if (!dragon.MoveForwards().CanExecute())
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
                        dragon.TurnLeft();
                        return;
                    case Option.Right:
                        dragon.TurnRight();
                        return;
                    case Option.Forward:
                        dragon.MoveForwards();
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
