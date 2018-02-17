using System.Collections.Generic;
using System.Linq;
using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.BaGua
{
    public class DiscStack
    {
        private List<Disc> _discs;

        public DiscStack()
        {
            _discs = new List<Disc>();
        }

        public int Count
        {
            get
            {
                return _discs.Count;
            }
        }

        public Disc[] RemoveAll()
        {
            var removed = _discs;
            _discs = new List<Disc>();

            return removed.ToArray();
        }

        public void Add(Disc disc)
        {
            _discs.Add(disc);
        }

        public bool Any()
        {
            return Count > 0;
        }

        public PlayerColor[] GetDiscConfiguration()
        {
            return _discs.Select(d => d.Color).ToArray();
        }
    }
}
