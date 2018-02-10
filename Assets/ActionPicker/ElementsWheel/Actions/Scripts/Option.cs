using Assets.Dragons;
using Assets.FuryEngine.DragonPackage;
using System;

namespace Assets.ActionPicker.ElementsWheel.Actions
{
    public class Option
    {
        public string Name { get; private set; }
        private Func<DragonX, DragonAction> _actionFinder { get; set; }

        public bool CanExecute(DragonX dragon)
        {
            return _actionFinder(dragon).CanExecute();
        }

        public void Execute(DragonX dragon)
        {
            _actionFinder(dragon).Execute();
        }

        public Option(string name, Func<DragonX, DragonAction> actionFinder)
        {
            Name = name;
            _actionFinder = actionFinder;
        }
        
        public static Option Left = new Option("Left", (d) => d.TurnLeft());
        public static Option Right = new Option("Right", (d) => d.TurnRight());
        public static Option Forward = new Option("Forward", (d) => d.MoveForwards());

        public static Option NoOperation = new Option("No operation", (d) => d.DoNothing());

        public static Option ConsumeFire = new Option("ConsumeFire", (d) => d.ConsumeFire());
        public static Option ConsumeWater = new Option("ConsumeWater", (d) => d.ConsumeWater());

        public static Option AttackWithFire = new Option("AttackWithFire", (d) => d.ExpelFire());
        public static Option AttackWithWater = new Option("AttackWithWater", (d) => d.ExpelWater());

        public static Option AdditionalSpiritPhase = new Option("AdditionalSpiritPhase", (d) => d.ChooseAdditionalSpirit());
    }
}
