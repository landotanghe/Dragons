using Assets.FuryEngine.DragonPackage;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class DiscStack : MonoBehaviour
    {
        public GameObject prefab;
        private int count;
        
        public void RemoveAll()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            count = 0;
        }

        public void AddDisc(PlayerColor color)
        {
            var disc = Instantiate(prefab, transform.position + new Vector3(0, 0.3f + 0.35f * count, 0), Quaternion.identity);
            var coloredDisc = disc.GetComponent<ColoredDisc>();
            coloredDisc.Color = color;
            count++;
        }
    }
}
