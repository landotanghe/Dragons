using System;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public Head head;
        private const float Width = 11.2f;
        private const float Height = -9.89f;

        public int x = 1;
        public int y = 1;

        private int loop = 0;

        public void FixedUpdate()
        {
            loop++;
            if(loop == 30)
            {
                x = (8-x) % 8;
                //y = (y + 4) % 8;
                transform.position = new Vector3(Width * x / 8, Height * y / 8, 0.0f);
                Debug.Log("move");
                loop = 0;
            }                
        }

        public bool CanTurnRight(Board board)
        {
            return true;
        }

        public bool CanTurnLeft(Board board)
        {
            return true;
        }

        public bool CanMoveForwards(Board board)
        {
            return true;
        }

        public void TurnLeft(Board board)
        {
            throw new NotImplementedException();
        }

        public void TurnRight(Board board)
        {
            throw new NotImplementedException();
        }

        public void MoveForwards(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
