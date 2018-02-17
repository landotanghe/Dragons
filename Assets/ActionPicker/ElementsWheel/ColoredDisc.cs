using Assets.FuryEngine.DragonPackage;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class ColoredDisc : MonoBehaviour
    {
        public PlayerColor Color;
        public GameObject white;
        public GameObject black;

        void Update()
        {
            white.SetActive(Color == PlayerColor.White);
            black.SetActive(Color == PlayerColor.Black);
        }
    }
}
