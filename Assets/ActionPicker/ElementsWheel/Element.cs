using Assets.FuryEngine.BaGua;
using System;
using System.Linq;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameStateManager game { get; set; }
    public Assets.FuryEngine.BaGua.BaGuaElementType type { get; set; }
    public Assets.ActionPicker.ElementsWheel.DiscStack discs;
    
    public void OnMouseDown()
    {
        game.RequestToDropDiscs(type);
    }

    public void AddDisc(Assets.ActionPicker.ElementsWheel.Disc disc)
    {
        if (disc == null)
            throw new ArgumentNullException();

        discs.Add(disc);
    }
    
    // Use this for initialization
    void Start ()
    {
        BaGuaWheel.DiscsDropped += OnDiscsDropped;
    }

    private void OnDiscsDropped(BaGuaWheel.BaGuaDiscConfigurationChangedEvent @event)
    {
        var configuration = @event.DiscConfiguration.Where(c => c.ElementType == type).First();

        //element.//TODO update disc stack
    }

    // Update is called once per frame
    void Update () {
	}
}
