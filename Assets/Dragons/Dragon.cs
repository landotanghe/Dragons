using System;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public int x = 0;
        public int y = 0;

        private int loop = 0;

        public void FixedUpdate()
        {
            loop++;
            if(loop == 10)
            {
                transform.position = new Vector3(transform.position.x + 1 / 8.0f, transform.position.y, transform.position.z);
                Debug.Log("move");
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
