using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;
using System;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public abstract class WheelElementAction : MonoBehaviour
    {
        public bool CanExecute(DragonX dragon, GameEngine board)
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
    }
}
