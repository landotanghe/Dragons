using Assets;
using Assets.ActionPicker.ElementsWheel;
using UnityEngine;

public class Element : MonoBehaviour {
    public IAction action;

    public int discStackSize;

    public int Height
    {
        get
        {
            return discStackSize;
        }
    }

    public void AddDisc()
    {

    }

    public Discs TakeAllDiscs()
    {
        var discs = new Discs(discStackSize);
        discStackSize = 0;
        return discs;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
