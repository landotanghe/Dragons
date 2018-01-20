namespace Assets.ActionPicker.ElementsWheel
{
    public class Discs
    {
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public Discs(int count)
        {
            _count = count;
        }

        public void RemoveOne()
        {
            _count--;
        }

        public bool Any()
        {
            return _count > 0;
        }
    }
}
