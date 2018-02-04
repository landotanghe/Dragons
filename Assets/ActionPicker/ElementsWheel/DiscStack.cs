using System;
using System.Linq;
using UnityEngine;

namespace Assets.ActionPicker.ElementsWheel
{
    public class DiscStack : MonoBehaviour
    {
        public Disc[] discs;

        public int Count
        {
            get
            {
                return discs.Length;
            }
        }
        
        public Disc RemoveOne()
        {
            var removed = discs.Last();
            discs = discs.Take(discs.Length - 1).ToArray();

            return removed;
        }

        public void Add(Disc disc)
        {
            disc.transform.SetParent(transform);
            disc.transform.position = transform.position + new Vector3(0, 0.35f * Count, 0);

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
