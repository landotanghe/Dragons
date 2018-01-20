using System;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {

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
