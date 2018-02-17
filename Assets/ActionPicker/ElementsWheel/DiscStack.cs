using Assets.FuryEngine.DragonPackage;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class DiscStack : MonoBehaviour
    {
        public Transform prefab;
        public Disc[] discs;
        //TODO use prefab to instantiate discs
        public int Count
        {
            get
            {
                return discs.Length;
            }
        }
        
        public Disc[] RemoveAll()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            var removed = discs;
            discs = new Disc[0];

            return removed;
        }

        public void AddDisc(PlayerColor color)
        {

        }

        private void Add(Disc disc)
        {
            disc.transform.SetParent(transform);
            disc.transform.position = transform.position + new Vector3(0, 0.3f + 0.35f * Count, 0);

            var changedDiscs = discs.ToList();
            changedDiscs.Add(disc);
            discs = changedDiscs.ToArray();
        }

        public bool Any()
        {
            return Count > 0;
        }
    }
}
