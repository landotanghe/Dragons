using System;
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
                option.Execute(_currentPlayer);
                SwitchPlayer();
            }
        }
    }

    internal void SelectAction(WheelElementAction action)
    {
        _actionExecutor = new ActionExecutor(action, _currentPlayer, board);
    }

    private void ChoosePlayerForNextTurn()
    {
        if (!isSecondMove && _actionExecutor.HasAdditionalMove())
        {
            isSecondMove = true;
        }
        else
        {
            SwitchPlayer();
            isSecondMove = false;
        }
    }

    private void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer == whiteDragon ? blackDragon : whiteDragon;
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
