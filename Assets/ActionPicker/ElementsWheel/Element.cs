using System.Linq;
using Assets.FuryEngine.BaGua;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class Element : MonoBehaviour
    {
        public GameStateManager game;
        public Assets.FuryEngine.BaGua.BaGuaElementType type;
        public Assets.ActionPicker.ElementsWheel.DiscStack discs;

        //Need this property to handle initialization where event might be thrown before Start()
        private BaGuaWheel.BaGuaDiscConfigurationChangedEvent.ElementDiscs configuration;

        public void OnMouseDown()
        {
            game.RequestToDropDiscs(type);
        }
        
        // Use this for initialization
        public Element()
        {
            BaGuaWheel.DiscsDropped += OnDiscsDropped;
        }

        public void Start()
        {
            if (configuration != null)
                Apply(configuration);
        }

        private void OnDiscsDropped(BaGuaWheel.BaGuaDiscConfigurationChangedEvent @event)
        {
            configuration = @event.DiscConfiguration.Where(c => c.ElementType == type).First();
        
            if(discs != null)
                Apply(configuration);
        }

        private void Apply(BaGuaWheel.BaGuaDiscConfigurationChangedEvent.ElementDiscs configuration)
        {
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
}
