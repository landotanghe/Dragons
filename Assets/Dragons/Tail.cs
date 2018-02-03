using UnityEngine;

namespace Assets.Dragons
{
    public class Tail : BodyPart
    {
        public GameObject straight;
        public GameObject curved;

        public override float GetDisplayRotationInDegrees(Direction upstream, Direction downstream)
        {
            if((upstream - downstream) % 2 == 0)
            {
                straight.SetActive(true);
                curved.SetActive(false);
            }
            else
            {
                straight.SetActive(false);
                curved.SetActive(true);
            }
            return 0;
        }
    }
}
