using Assets;
using Assets.ActionPicker.ElementsWheel;
using System;
using UnityEngine;

public class Element : MonoBehaviour {
    public WheelElementAction action;
    public ElementsWheel wheel;    
    public DiscStack discs;
    
    public void OnMouseDown()
    {
        wheel.RequestToDropOffDiscs(this);
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
	}
}
