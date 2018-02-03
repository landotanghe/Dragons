using System;

namespace Assets.Dragons
{
    public class Head : BodyPart
    {
        public override float GetDisplayRotationInDegrees(Direction upstream, Direction downstream)
        {
            //TODO display rotated dragon head
            if(upstream == Direction.North)
                    return 180;
            if (upstream == Direction.East)
                    return -90;
            if (upstream == Direction.South)
                    return 0;
            return 90;            
        }
    }
}
