using System.Collections.Generic;
using Assets.SeedWork;

namespace Assets.Dragons
{
    public class Direction : ValueObject
    {
        private readonly int Value;

        private Direction(int v)
        {
            Value = v;
        }

        public static Direction North = new Direction(0);
        public static Direction East = new Direction(1);
        public static Direction South = new Direction(2);
        public static Direction West = new Direction(3);

        public bool IsOnSameLineAs(Direction direction)
        {
            return (Value - direction.Value) % 2 == 0;
        }

        public Direction TurnLeft()
        {
            var value = (4 + Value - 1) % 4;
            return new Direction(value);
        }

        public Direction TurnRight()
        {
            var value = (4 + Value + 1) % 4;
            return new Direction(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { Value };
        }
    }
}
