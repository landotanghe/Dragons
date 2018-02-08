﻿using System;
using System.Linq;
using Assets.Dragons;
using Assets.Dragons.Damages;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class ActionExecutor
    {
        private Dragon _dragon;
        private Board _board;

        private WheelElementAction _action;
        private int _nextOptionToPick;

        private AvailableOptions[] _availableOptions;

        public ActionExecutor(WheelElementAction action, Dragon dragon, Board board)
        {
            _action = action;
            _availableOptions = _action.GetAvailableOptions(dragon, board);
            _nextOptionToPick = 0;
            _dragon = dragon;
            _board = board;
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

            var target = _board.GetOpponentOf(_dragon);
            var damageLocation = _dragon.head.Location + _dragon.head.Direction;
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
