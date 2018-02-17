namespace Assets.FuryEngine.Damages
{
    public class Water
    {
        public readonly int Amount;

        public Water(int amount)
        {
            Amount = amount;
        }

        public static Water Depleted
        {
            get
            {
                return new Water(0);
            }
        }

        public static Water One
        {
            get
            {
                return new Water(1);
            }
        }

        public static Water operator++ (Water water)
        {
            return water + One;
        }
        
        public static Water operator + (Water w1, Water w2)
        {
            return new Water(w1.Amount + w2.Amount);
        }

        public static Water operator -(Water w1, Water w2)
        {
            return new Water(w1.Amount - w2.Amount);
        }
    }
}
