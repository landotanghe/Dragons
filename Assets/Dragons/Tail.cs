using System.Linq;
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
                if(upstream == Direction.North || upstream == Direction.South)
                {
                    return 90;
                }
                return 0;
            }
            else
            {
                straight.SetActive(false);
                curved.SetActive(true);

                var directions = new[] { upstream, downstream };
                if (directions.Contains(Direction.North))
                {
                    Debug.Log("Curved N");
                    if(directions.Contains(Direction.East))
                    {
                        return 90;
                    }
                    return 180;
                }
                else
                {
                    Debug.Log("curved S");
                    if (directions.Contains(Direction.East))
                    {
                        return 0;
                    }
                    return -90;
                }
            }
        }
    }
}
