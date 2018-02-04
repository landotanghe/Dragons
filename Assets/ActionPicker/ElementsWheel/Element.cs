using Assets;
using Assets.ActionPicker.ElementsWheel;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    public WheelElementAction action;
    public ElementsWheel wheel;    
    public DiscStack discs;
    
    public void OnMouseDown()
    {
        wheel.DropOff(this);
    }

    public void AddDisc(Disc disc)
    {
        if (disc == null)
            throw new ArgumentNullException();

        discs.Add(disc);
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
        countDisplayText.text = "" + discs.Count;
	}
}
