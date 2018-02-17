using Assets.ActionPicker.ElementsWheel.Actions.Scripts;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.FuryEngine.BaGua
{
    public class BaGuaWheel
    {
        public GameEngine game;

        private BaGuaElement[] _elements;
        private Dictionary<BaGuaElement, BaGuaElement> _counterClockWiseElements;

        public class BaGuaDiscConfigurationChangedEvent
        {
            public BaGuaElementType DiscsRemovedFrom { get; set; }

            public ElementDiscs[] DiscConfiguration { get; set; }

            public class ElementDiscs
            {
                public BaGuaElementType ElementType { get; set; }
                public PlayerColor[] Discs { get; set; }
            }
        }

        public delegate void DiscsDroppedHandler(BaGuaDiscConfigurationChangedEvent @event);
        public static event DiscsDroppedHandler DiscsDropped;
        
        // Use this for initialization
        public BaGuaWheel()
        {
            _elements = new BaGuaElement[]
            {
                new SkyElement().AddDisc(Disc.White()).AddDisc(Disc.White()),
                new LakeElement(),
                new FireElement().AddDisc(Disc.Black()).AddDisc(Disc.White()),
                new ThunderElement(),
                new EarthElement().AddDisc(Disc.Black()).AddDisc(Disc.Black()),
                new MountainElement(),
                new WaterElement().AddDisc(Disc.White()).AddDisc(Disc.Black()),
                new WindElement()
            };

            _counterClockWiseElements = new Dictionary<BaGuaElement, BaGuaElement>();

            _counterClockWiseElements.Add(_elements.Last(), _elements[0]);
            for (int i = 0; i < _elements.Length - 1; i++)
            {
                _counterClockWiseElements.Add(_elements[i], _elements[i + 1]);
            }
        }
        
        public BaGuaElement DetermineAction(BaGuaElementType type)
        {
            var element = GetElement(type);

            var dropLocation = element;
            var discCounts = element.NumberOfDiscs;
            for (int i = 0; i < discCounts; i++)
            {
                dropLocation = _counterClockWiseElements[dropLocation];
            }
            return dropLocation;
        }

        private BaGuaElement GetElement(BaGuaElementType type)
        {
            return _elements.Where(e => e.Type == type).First();
        }
        
        public void DropOffDiscs(BaGuaElementType type)
        {
            var element = GetElement(type);

            var discs = element.RemoveAllDiscs();
            var dropLocation = element;

            for (int i = 0; i < discs.Length; i++)
            {
                dropLocation = _counterClockWiseElements[dropLocation];

                var disc = discs[i];
                dropLocation.AddDisc(disc);
            }

            DiscsDropped(new BaGuaDiscConfigurationChangedEvent
            {
                DiscsRemovedFrom = element.Type,
                DiscConfiguration = _elements.Select(e => new BaGuaDiscConfigurationChangedEvent.ElementDiscs
                {
                    Discs = e.GetDiscConfiguration(),
                    ElementType = e.Type
                }).ToArray()
            });
        }
        
        public bool HasDiscsAt(BaGuaElementType type)
        {
            var element = GetElement(type);
            return element.NumberOfDiscs != 0;
        }
    }
}

