using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class ElementsWheel : MonoBehaviour
    {
        public Element[] elements;
        
        // Use this for initialization
        void Start()
        {
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

        public int GetDiscsAt(int position)
        {
            return elements[position].Height;
        }

        public bool IsValidIndex(int selectedElementIndex)
        {
            return selectedElementIndex >= 0
                && selectedElementIndex < elements.Length;
        }

        public int MoveDiscsFrom(int pickupLocation)
        {
            var discsInHand = elements[pickupLocation].TakeAllDiscs();
            var dropLocation = GetDropLocationAfter(pickupLocation);

            while (discsInHand.Any())
            {
                var disc = discsInHand.RemoveOne();
                elements[dropLocation].AddDisc(disc);

                dropLocation = GetDropLocationAfter(dropLocation);
            }

            return dropLocation;
        }

        private int GetDropLocationAfter(int previousLocation)
        {
            var positionToDropNextDisc = (previousLocation + 1) % elements.Length;
            return positionToDropNextDisc;
        }
    }
}
