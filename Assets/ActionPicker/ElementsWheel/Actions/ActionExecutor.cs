using Assets;
using Assets.ActionPicker.ElementsWheel;
using Assets.Dragons;
using UnityEngine;

public class ActionExecutor : MonoBehaviour
{
    public ElementsWheel elementsWheel;
    public Dragon dragon;
    public Board board;
    private IAction[] _actions;
    private KeyCode FirstElementKeyCode = KeyCode.Keypad1;


	// Use this for initialization
	void Start () {
        _actions = new IAction[]
        {
            new WaterAction(),
            new WaterAction(),
            new WaterAction(),
            new WaterAction(),

            new WaterAction(),
            new WaterAction(),
            new WaterAction(),
            new WaterAction(),
        };
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
        if (IsInValidIndexRange(selectedElementIndex))
        {
            TryMovingDisc(selectedElementIndex);
        }
    }

    private bool IsInValidIndexRange(int selectedElementIndex)
    {
        return selectedElementIndex >= 0 
            && selectedElementIndex < _actions.Length;
    }

    private void TryMovingDisc(int selectedDiscPosition)
    {
        if (CanMoveDiscOn(selectedDiscPosition))
        {
            var actionIndex = elementsWheel.MoveDiscsFrom(selectedDiscPosition);
            _actions[actionIndex].Execute(dragon, board);
        }
    }

    private bool CanMoveDiscOn(int actionIndex)
    {
        if (!elementsWheel.HasDiscsAt(actionIndex))
        {
            return false;
        }

        var predictedActionIndex = elementsWheel.PredictFinalDropOfLocation(actionIndex);

        var predictedAction = _actions[predictedActionIndex];
        return predictedAction.CanExecute(dragon, board);
    }
}
