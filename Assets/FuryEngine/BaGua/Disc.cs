using Assets.FuryEngine.DragonPackage;

public class Disc
{
    public Disc(PlayerColor color)
    {
        Color = color;
    }

    public PlayerColor Color { get; private set; }
}