using System;
using System.Linq;
using Assets;
using Assets.ActionPicker.ElementsWheel;
using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using Assets.Dragons.Damages;
using Assets.FuryEngine;
using Assets.FuryEngine.DragonPackage;

namespace FuryEngine
{
    public class GameEngine
    {
        private DragonX _whiteDragon;
        private DragonX _blackDragon;

        private WaterPool _waterPool;
        private FirePool _firePool;

        private DragonX _currentPlayer;
        public ElementsWheel elementsWheel;

        public static GameEngine Instantiate()
        {
            var engine = new GameEngine();
            engine.Reset();
            return engine;
        }

        private GameEngine()
        {
        }

        public void Reset()
        {
            _whiteDragon = new DragonX(PlayerColor.White, new Location(1, 6), Direction.North, this);
            _whiteDragon.MoveForwards().Execute();
            _whiteDragon.TurnLeft().Execute();
            _whiteDragon.TurnLeft().Execute();

            _blackDragon = new DragonX(PlayerColor.Black, new Location(5, 1), Direction.East, this);
            _blackDragon.MoveForwards().Execute();
            _blackDragon.MoveForwards().Execute();
            _blackDragon.TurnRight().Execute();
            _blackDragon.TurnRight().Execute();

            _firePool = FirePool.Instantiate();
            _waterPool = WaterPool.Instantiate();

            _actionExecutor = null;
            _currentPlayer = _whiteDragon;
        }

        public Water GetWaterInPool()
        {
            return _waterPool.Water;
        }
        
        public Water ConsumeWater()
        {
            return _waterPool.Consume();
        }

        public void AddWaterToPool(Water water)
        {
            _waterPool.Add(water);
        }

        public Fire ConsumeFire()
        {
            return _firePool.ConsumeFire();
        }

        public void AddFireToPool(Fire exhaledFire)
        {
            _firePool.Add(exhaledFire);
        }





        public DragonX GetOpponentOf(DragonX dragon)
        {
            return dragon == _whiteDragon
                ? _blackDragon
                : _whiteDragon;
        }

        public void DeliverDamage(Damage damage, DragonX dragon)
        {
            var waterChange = dragon.TakeDamage(damage);
            _waterPool.Add(waterChange);
        }
        
        public bool IsFreeSpace(Location location)
        {
            return IsWithinBounds(location.X, location.Y) &&
                !_whiteDragon.Occupies(location) &&
                !_blackDragon.Occupies(location);
        }
        
        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < 8
                && y >= 0 && y < 8;
        }

        public ActionExecutor _actionExecutor;
        public void Play(Option option)
        {
            if (option != null && option.CanExecute(_currentPlayer))
            {
                if (_actionExecutor.CanPlay(option))
                {
                    _actionExecutor.Play(option);
                }
                ChoosePlayerForNextTurn();
            }
            else
            {
                LogCurrentPlayer();
                //Debug.Log("available options are: " + string.Join("\r\n", _actionExecutor.OptionsThatAreAllowed().Select(o => o.Name).ToArray()));
            }
        }

        public bool IsAllowedAction(WheelElementAction action)
        {
            if (_actionExecutor != null)
                return false;

            return action.GetAvailableOptions(_currentPlayer, this).Any();
        }

        internal void SelectAction(WheelElementAction action)
        {
            if (!IsAllowedAction(action))
                throw new InvalidOperationException("Can't select this action now");

            _actionExecutor = new ActionExecutor(action, _currentPlayer, this);
        }

        private void ChoosePlayerForNextTurn()
        {
            if (_actionExecutor.HasToPickAnotherOption())
                return;

            if (!_currentPlayer.CanPickAnotherSpirit())
            {
                _actionExecutor.ApplyBite();
                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            _currentPlayer.ResetSpirits();
            _currentPlayer = GetOpponentOf(_currentPlayer);
            LogCurrentPlayer();
            _actionExecutor = null;
        }

        private void LogCurrentPlayer()
        {
           // Debug.Log("current player is : " + (_currentPlayer == whiteDragon ? "white" : "black"));
        }

        private bool CanMoveDiscsFrom(int selectedDiscPosition)
        {
            if (!elementsWheel.HasDiscsAt(selectedDiscPosition))
            {
                return false;
            }

            var predictedAction = elementsWheel.GetActionFor(selectedDiscPosition);
            return predictedAction.CanExecute(_whiteDragon, this);
        }

    }
}
