using System;

namespace Assets.Dragons
{
    public class Head : BodyPart
    {
        public override void DisplayRotation(Direction upstream, Direction downstream)
        {
            //TODO display rotated dragon head
            switch (upstream)
            {
                case Direction.North:
                    return;
                case Direction.East:
                    return;
                case Direction.South:
                    return;
                case Direction.West:
                    return;
            }
        }
    }
}
