using Assets;
using Assets.ActionPicker.ElementsWheel;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    public WheelElementAction action;

    public int discStackSize;
    public DiscStack discs;

    public int Height
    {
        get
        {
            return discStackSize;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("mouse down");
    }
    public void AddDisc(Disc disc)
    {
        discs.Add(disc);
    }

    public DiscStack TakeAllDiscs()
    {
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
