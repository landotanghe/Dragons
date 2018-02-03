namespace Assets.Dragons.Damages
{
    public class Fire
    {
        public readonly int Amount;

        public Fire(int amount)
        {
            Amount = amount;
        }

        public static Fire Depleted
        {
            get
            {
                return new Fire(0);
            }
        }

        public static Fire FullPool
        {
            get
            {
                return new Fire(8);
            }
        }

        public static Fire One { get
            {
                return new Fire(1);
            }
        }

        public static Fire operator +(Fire f1, Fire f2)
        {
            return new Fire(f1.Amount + f2.Amount);
        }

        public static Fire operator -(Fire f1, Fire f2)
        {
            return new Fire(f1.Amount - f2.Amount);
        }
    }
}
