using System.Collections.Generic;
using Assets.FuryEngine.Dragons;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class DiscStack : MonoBehaviour
    {
        public GameObject prefab;
        private List<GameObject> discs = new List<GameObject>();
        
        public void RemoveAll()
        {
            foreach (var child in discs)
            {
                GameObject.Destroy(child);
            }
            discs = new List<GameObject>();
        }

        public void AddDisc(PlayerColor color)
        {
            var disc = Instantiate(prefab, transform.position + new Vector3(0, 0.35f * discs.Count, 0), Quaternion.identity);
            var coloredDisc = disc.GetComponent<ColoredDisc>();
            coloredDisc.Color = color;

            discs.Add(disc);
        }
    }
}
