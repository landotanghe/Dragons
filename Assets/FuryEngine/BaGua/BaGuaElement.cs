using Assets.ActionPicker.ElementsWheel.Actions;
using Assets.Dragons;
using Assets.FuryEngine.BaGua;
using Assets.FuryEngine.DragonPackage;
using FuryEngine;
using System;
using System.Linq;

public abstract class BaGuaElement {
    private DiscStack _discs;


    public void AddDisc(Disc disc)
    {
        if (disc == null)
            throw new ArgumentNullException();

        _discs.Add(disc);
    }

    public abstract BaGuaElementType Type { get; }

    public Disc[] RemoveAllDiscs()
    {
        return _discs.RemoveAll();
    }

    public int NumberOfDiscs{
        get
        {
            return _discs.Count;
        }
    }

    public bool CanExecuteAction(DragonX dragon, GameEngine board)
    {
        var firstMove = GetAvailableOptions(dragon, board)[0];

        return firstMove.For(dragon).Any();
    }

    protected abstract AvailableOptions[] GetAvailableOptions(Direction direction);

    public AvailableOptions[] GetAvailableOptions(DragonX dragon, GameEngine game)
    {
        var availableOptions = GetAvailableOptions(dragon.Direction);

        return availableOptions;
    }

    public PlayerColor[] GetDiscConfiguration()
    {
        return _discs.GetDiscConfiguration();
    }
}
