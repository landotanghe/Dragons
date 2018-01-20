using Assets;
using Assets.ActionPicker.ElementsWheel;
using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public ElementsWheel elementsWheel;
    public Dragon dragon;
    public Board board;
    private KeyCode FirstElementKeyCode = KeyCode.Keypad1;

    private ActionExecutor _actionExecutor;


	// Use this for initialization
	void Start () {
    }


	
	// Update is called once per frame
	void Update () {
        Event e = Event.current;
        if (e.isKey)
        {
            CheckInput(e.keyCode);
        }
	}

    private void CheckInput(KeyCode keyPressed)
    {
        var selectedElementIndex = keyPressed - FirstElementKeyCode;

        if (_actionExecutor == null)
        {
            if (elementsWheel.IsValidIndex(selectedElementIndex))
            {
                TryMovingDisc(selectedElementIndex);
            }
        }
        else
        {            
            if(_actionExecutor.CanExecute())
            {
                _actionExecutor.Execute();
                _actionExecutor = null;
            }
        }
    }


    private void TryMovingDisc(int selectedDiscPosition)
    {
        if (CanMoveDiscsFrom(selectedDiscPosition))
        {
            var actionIndex = elementsWheel.MoveDiscsFrom(selectedDiscPosition);
            var action = elementsWheel.elements[actionIndex].action;

            _actionExecutor = new ActionExecutor(action, dragon, board);
        }
    }

    private bool CanMoveDiscsFrom(int selectedDiscPosition)
    {
        if (!elementsWheel.HasDiscsAt(selectedDiscPosition))
        {
            return false;
        }

        var predictedAction = elementsWheel.GetActionFor(selectedDiscPosition);        
        return predictedAction.CanExecute(dragon, board);
    }
}
