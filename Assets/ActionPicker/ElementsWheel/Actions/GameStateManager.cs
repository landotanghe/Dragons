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
    private KeyCode FirstElementKeyCode = KeyCode.Keypad1;

    private ActionExecutor _actionExecutor;

    private bool isSecondMove;
    private Dragon _currentPlayer;


	// Use this for initialization
	void Start () {
        _currentPlayer = whiteDragon;
        isSecondMove = false;
        _actionExecutor = null;

        whiteDragon.head.Reposition(new Location(1, 6), Direction.North);
        whiteDragon.MoveForwards(board).Execute(board);
        whiteDragon.TurnLeft(board).Execute(board);
        whiteDragon.TurnLeft(board).Execute(board);

        blackDragon.head.Reposition(new Location(5, 1), Direction.East);
        blackDragon.MoveForwards(board).Execute(board);
        blackDragon.MoveForwards(board).Execute(board);
        blackDragon.TurnRight(board).Execute(board);
        blackDragon.TurnRight(board).Execute(board);
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
        DragonAction action = null;
        if(keyPressed == KeyCode.LeftArrow)
        {
            action = _currentPlayer.TurnLeft(board);
        }else if(keyPressed == KeyCode.RightArrow)
        {
            action = _currentPlayer.TurnRight(board);
        }
        else if (keyPressed == KeyCode.UpArrow)
        {
            action = _currentPlayer.MoveForwards(board);
        }

        if(action!= null && action.CanExecute(board))
        {
            action.Execute(board);
            SwitchPlayer();
        }

        var selectedElementIndex = keyPressed - FirstElementKeyCode;

        if (_actionExecutor == null)
        {
            //Debug.Log("Selecting action " + selectedElementIndex);
            if (elementsWheel.IsValidIndex(selectedElementIndex))
            {
                TryMovingDisc(selectedElementIndex);
            }
        }
        else
        {
            //Debug.Log("Selecting options for action " + selectedElementIndex);
            if(_actionExecutor.CanExecute())
            {
                _actionExecutor.Execute();
                ChoosePlayerForNextTurn();

                _actionExecutor = null;
            }
        }
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

    private void TryMovingDisc(int selectedDiscPosition)
    {
        if (CanMoveDiscsFrom(selectedDiscPosition))
        {
           // Debug.Log("moving disc from " + selectedDiscPosition);
            var actionIndex = elementsWheel.MoveDiscsFrom(selectedDiscPosition);
            var action = elementsWheel.elements[actionIndex].action;

            _actionExecutor = new ActionExecutor(action, whiteDragon, board);
        }
        else
        {
           // Debug.Log("can't move disc from " + selectedDiscPosition);
        }
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
