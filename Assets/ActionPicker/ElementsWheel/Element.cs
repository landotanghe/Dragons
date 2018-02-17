using Assets.FuryEngine.BaGua;
using System;
using System.Linq;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameStateManager game;
    public Assets.FuryEngine.BaGua.BaGuaElementType type;
    public Assets.ActionPicker.ElementsWheel.DiscStack discs;
    
    public void OnMouseDown()
    {
        game.RequestToDropDiscs(type);
    }
        
    // Use this for initialization
    void Start ()
    {
        BaGuaWheel.DiscsDropped += OnDiscsDropped;
    }

    private void OnDiscsDropped(BaGuaWheel.BaGuaDiscConfigurationChangedEvent @event)
    {
        var configuration = @event.DiscConfiguration.Where(c => c.ElementType == type).First();

        discs.RemoveAll();

        Debug.Log("Discs removed from " + type);
        foreach (var discColor in configuration.Discs)
        {
            Debug.Log("Disc " + discColor + " added to " + type);
            discs.AddDisc(discColor);
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
