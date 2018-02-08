using System;
using System.Linq;
using Assets;
using Assets.ActionPicker.ElementsWheel;
using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public ElementsWheel elementsWheel;
    public Dragon whiteDragon;
    public Dragon blackDragon;
    public Board board;

    private ActionExecutor _actionExecutor;

    private bool isSecondMove;
    private Dragon _currentPlayer;


	// Use this for initialization
	void Start () {
        _currentPlayer = whiteDragon;
        isSecondMove = false;
        _actionExecutor = null;

        whiteDragon.head.Reposition(new Location(1, 6), Direction.North);
        whiteDragon.MoveForwards().Execute();
        whiteDragon.TurnLeft().Execute();
        whiteDragon.TurnLeft().Execute();

        blackDragon.head.Reposition(new Location(5, 1), Direction.East);
        blackDragon.MoveForwards().Execute();
        blackDragon.MoveForwards().Execute();
        blackDragon.TurnRight().Execute();
        blackDragon.TurnRight().Execute();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnGUI()
    {
        Event e = Event.current;
        if (e != null && e.type.Equals(EventType.KeyUp))
        {
            CheckInput(e.keyCode);
        }
    }

    private void CheckInput(KeyCode keyPressed)
    {
        if(_actionExecutor != null)
        {
            Option option = null;
            if (keyPressed == KeyCode.LeftArrow)
            {
                option = Option.Left;
            }
            else if (keyPressed == KeyCode.RightArrow)
            {
                option = Option.Right;
            }
            else if (keyPressed == KeyCode.UpArrow)
            {
                option = Option.Forward;
            }
            else if (keyPressed == KeyCode.Space)
            {
                option = Option.NoOperation;
            }
            else if (keyPressed == KeyCode.F)
            {
                option = Option.AttackWithFire;
            }
            else if (keyPressed == KeyCode.S)
            {
                option = Option.AttackWithWater;
            }
            else if (keyPressed == KeyCode.D)
            {
                option = Option.ConsumeWater;
            }
            else if (keyPressed == KeyCode.E)
            {
                option = Option.ConsumeFire;
            }

            if (option != null && option.CanExecute(_currentPlayer))
            {
                if(_actionExecutor.CanPlay(option)){
                    _actionExecutor.Play(option);
                }
                ChoosePlayerForNextTurn();
            }
            else
            {
                LogCurrentPlayer();
                Debug.Log("available options are: " + string.Join("\r\n", _actionExecutor.OptionsThatAreAllowed().Select(o => o.Name).ToArray()));
            }
        }
    }

    public bool IsAllowedAction(WheelElementAction action)
    {
        if (_actionExecutor != null)
            return false;

        return action.GetAvailableOptions(_currentPlayer, board).Any();
    }

    internal void SelectAction(WheelElementAction action)
    {
        if (!IsAllowedAction(action))
            throw new InvalidOperationException("Can't select this action now");

        _actionExecutor = new ActionExecutor(action, _currentPlayer, board);
    }

    private void ChoosePlayerForNextTurn()
    {
        if (_actionExecutor.HasToPickAnotherOption())
            return;

        if (!_currentPlayer.CanPickAnotherSpirit())
        {
            SwitchPlayer();
        }
    }

    private void SwitchPlayer()
    {
        _currentPlayer.ResetSpirits();
        _currentPlayer = _currentPlayer == whiteDragon ? blackDragon : whiteDragon;
        LogCurrentPlayer();
        _actionExecutor = null;
    }

    private void LogCurrentPlayer()
    {
        Debug.Log("current player is : " + (_currentPlayer == whiteDragon ? "white" : "black"));
    }

    private bool CanMoveDiscsFrom(int selectedDiscPosition)
    {
        if (!elementsWheel.HasDiscsAt(selectedDiscPosition))
        {
            return false;
        }

        var predictedAction = elementsWheel.GetActionFor(selectedDiscPosition);        
        return predictedAction.CanExecute(whiteDragon, board);
    }
}
