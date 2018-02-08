using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class ElementsWheel : MonoBehaviour
    {
        public Element[] elements;
        public GameStateManager game;

        private Dictionary<Element, Element> _counterClockWiseElements;
        
        // Use this for initialization
        void Start()
        {
            _counterClockWiseElements = new Dictionary<Element, Element>();

            _counterClockWiseElements.Add(elements.Last(), elements[0]);
            for(int i=0; i < elements.Length - 1; i++)
            {
                _counterClockWiseElements.Add(elements[i], elements[i + 1]);
            }
        }

        public WheelElementAction PredictDropOffAction(Element element)
        {
            var discs = element.discs.Count;
            var dropLocation = element;

            while (discs > 0)
            {
                dropLocation = _counterClockWiseElements[dropLocation];
                discs--;
            }
            return dropLocation.action;
        }

        public void DropDiscs(Element element)
        {
            DebugWheel();

            var discs = element.discs.RemoveAll();
            var dropLocation = element;

            Debug.Log("moving discs");
            for (int i = 0; i < discs.Length; i++)
            {
                dropLocation = _counterClockWiseElements[dropLocation];

                var disc = discs[i];
                dropLocation.AddDisc(disc);
            }
            game.SelectAction(dropLocation.action);
        }
        


        // Update is called once per frame
        void Update()
        {
        }



        public bool HasDiscsAt(int position)
        {
            return GetDiscsAt(position) != 0;
        }

        public WheelElementAction GetActionFor(int pickupLocation)
        {
            var actionPosition = (GetDiscsAt(pickupLocation) + pickupLocation) % elements.Length;
            return elements[actionPosition].action;
        }

        private void DebugWheel()
        {
            foreach(var el in elements)
            {
                Debug.Log("elemnt contains " + el.discs.Count + "discs");
            }
        }

        public int GetDiscsAt(int position)
        {
            return elements[position].discs.Count;
        }

        public bool IsValidIndex(int selectedElementIndex)
        {
            return selectedElementIndex >= 0
                && selectedElementIndex < elements.Length;
        }
        
        private int GetDropLocationAfter(int previousLocation)
        {
            var positionToDropNextDisc = (previousLocation + 1) % elements.Length;
            return positionToDropNextDisc;
        }
    }
}
