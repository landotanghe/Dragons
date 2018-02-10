using Assets.FuryEngine.DragonPackage;
using FuryEngine;

namespace Assets.Dragons
{
    public abstract class DragonAction
    {
        protected DragonX Dragon { get; private set; }
        protected GameEngine GameEngine { get; private set; }

        public DragonAction(DragonX dragon, GameEngine game)
        {
            Dragon = dragon;
            GameEngine = game;
        }        

        public abstract bool CanExecute();
        public abstract void Execute();
    }
}