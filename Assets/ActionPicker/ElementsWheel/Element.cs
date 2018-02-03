using Assets;
using Assets.ActionPicker.ElementsWheel;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    public WheelElementAction action;

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
        var countDisplay = transform.Find("DiscCountDisplay");

        if (countDisplay == null)
            return;

        var countDisplayText = countDisplay.GetComponent<Text>();

        if (countDisplayText == null)
            return; 
        countDisplayText.text = "" + discStackSize;
	}
}
