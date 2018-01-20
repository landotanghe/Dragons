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

        public int PredictFinalDropOfLocation(int pickupLocation)
        {
            return (GetDiscsAt(pickupLocation) + pickupLocation) % elements.Length;
        }

        public int GetDiscsAt(int position)
        {
            return elements[position].Height;
        }

        public int MoveDiscsFrom(int pickupLocation)
        {
            var discsInHand = elements[pickupLocation].TakeAllDiscs();
            var dropLocation = GetDropLocationAfter(pickupLocation);

            while (discsInHand.Any())
            {
                elements[dropLocation].AddDisc();
                discsInHand.RemoveOne();

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
