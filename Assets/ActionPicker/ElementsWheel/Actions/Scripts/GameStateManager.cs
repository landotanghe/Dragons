using Assets;
using Assets.ActionPicker.ElementsWheel;
using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using FuryEngine;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public ElementsWheel elementsWheel;
    public Dragon whiteDragon;
    public Dragon blackDragon;
    public Board board;
    
    public GameEngine GameEngine;
    public GameStateManager()
    {
    }

	// Use this for initialization
	void Start ()
    {
        GameEngine = GameEngine.Instantiate();
        GameEngine.elementsWheel = elementsWheel;//TODO refactor
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
        if(GameEngine._actionExecutor != null)//TODO refactor
        {
            var option = SelectOption(keyPressed);
            GameEngine.Play(option);
        }
    }

    private static Option SelectOption(KeyCode keyPressed)
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
        else if (keyPressed == KeyCode.R)
        {
            option = Option.AdditionalSpiritPhase;
        }

        return option;
    }

    internal void SelectAction(WheelElementAction action)
    {
        GameEngine.SelectAction(action);
    }

    internal bool IsAllowedAction(WheelElementAction action)
    {
        return GameEngine.IsAllowedAction(action);
    }
}
