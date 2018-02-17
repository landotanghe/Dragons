using Assets.FuryEngine.Dragons;

namespace Assets.FuryEngine.Actions
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