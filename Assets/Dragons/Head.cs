using System;

namespace Assets.Dragons
{
    public class Head : BodyPart
    {
        public override float GetDisplayRotationInDegrees(Direction upstream, Direction downstream)
        {
            //TODO display rotated dragon head
            switch (upstream)
            {
                case Direction.North:
                    return 180;
                case Direction.East:
                    return -90;
                case Direction.South:
                    return 0;
                case Direction.West:
                    return 90;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
