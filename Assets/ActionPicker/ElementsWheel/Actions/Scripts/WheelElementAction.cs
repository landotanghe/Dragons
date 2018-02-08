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

            return firstMove.For(dragon).Any();
        }

        protected abstract AvailableOptions[] GetAvailableOptions(Direction direction);

        public AvailableOptions[] GetAvailableOptions(Dragon dragon, Board board)
        {
            var availableOptions = GetAvailableOptions(dragon.head.Direction);

            return availableOptions;
        }
    }
}
