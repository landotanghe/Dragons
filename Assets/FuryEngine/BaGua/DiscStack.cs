using Assets.FuryEngine.DragonPackage;
using System.Linq;

public class DiscStack
{
    private Disc[] _discs;

    public int Count
    {
        get
        {
            return _discs.Length;
        }
    }

    public Disc[] RemoveAll()
    {
        var removed = _discs;
        _discs = new Disc[0];

        return removed;
    }

    public void Add(Disc disc)
    {
        var changedDiscs = _discs.ToList();
        changedDiscs.Add(disc);
        _discs = changedDiscs.ToArray();
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
