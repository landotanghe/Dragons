using Assets.Dragons;
using System;
using UnityEngine;

namespace Assets
{
    public class Board : MonoBehaviour
    {
        public Dragon whiteDragon;
        public Dragon blackDragon;

        internal bool IsFreeSpace(int x, int y)
        {
            return IsWithinBounds(x,y) && 
                !whiteDragon.Occupies(x, y) && 
                !blackDragon.Occupies(x, y);
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < 8
                && y >= 0 && y < 8;
        }
    }
}
