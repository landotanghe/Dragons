using Assets.FuryEngine.DragonPackage;

public class Disc
{
    public static Disc White()
    {
        return new Disc(PlayerColor.White);
    }

    public static Disc Black()
    {
        return new Disc(PlayerColor.Black);
    }

    private Disc(PlayerColor color)
    {
        Color = color;
    }

    public PlayerColor Color { get; private set; }
}