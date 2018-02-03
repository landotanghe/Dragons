using Assets.SeedWork;
using System;
using System.Collections.Generic;

namespace Assets.Dragons.Damages
{
    public class Damage : ValueObject
    {
        public readonly int Value;

        public static Damage None = new Damage(0);

        private Damage(int value)
        {
            if(value < 0)
            {
                throw new ArgumentException("damage can't be below 0");
            }

            Value = value;
        }

        internal static Damage FromValue(int value)
        {
            return new Damage(value);
        }

        public static Damage Bite()
        {
            return new Damage(1);
        }

        public static Damage Ranged(int value)
        {
            return new Damage(value);
        }

        public static Damage FullSegment
        {
            get
            {
                return new Damage(Health.Maximum);
            }
        }

        public static Damage operator -(Damage first, Damage substractor)
        {
            return FromValue(first.Value - substractor.Value);
        }

        public static bool operator <(Damage first, Damage other)
        {
            return first.Value < other.Value;
        }

        public static bool operator >(Damage first, Damage other)
        {
            return first.Value > other.Value;
        }

        public static bool operator >=(Damage first, Damage other)
        {
            return !( first < other);
        }

        public static bool operator <=(Damage first, Damage other)
        {
            return !(first > other);
        }

        public static Damage operator +(Damage first, Damage other)
        {
            return new Damage(first.Value + other.Value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { Value };
        }

        //TODO how does fire damage work
    }
}
