using Assets.Dragons.Actions;
using Assets.FuryEngine.DragonPackage;
using System.Linq;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public int playerIndex;
        public Head head;
        public TailSegment[] tail;
        public Board board;

        public Bar fireBar;
        public Bar waterBar;


        public void Start()
        {
            DragonX.OnDragonTookDamageHandler += OnDragonDamaged;
            DragonX.MovedEventHandler += OnDragonMoved;
        }

        public void Update()
        {
        }
        

        public void OnDragonDamaged(DragonX.DragonTookDamageEvent @event)
        {
            waterBar.fillRate = @event.Health;
            if(tail.Length > @event.TailLength)
            {
                tail = tail.Take(@event.TailLength).ToArray();
            }
        }
                
        private void LoseSegment()
        {
            tail = tail.Take(tail.Length - 1).ToArray();
        }

        public void OnDragonMoved(DragonX.DragonMovedEvent @event)
        {
            MoveTo(@event.Location, @event.Direction);
        }
                
        private void MoveTo(Location target, Direction direction)
        {
            MoveLastTailPartToHeadPosition(direction);
            head.Reposition(target, direction);

            head.SetDownStream(direction.Invert());
        }

        private void MoveLastTailPartToHeadPosition(Direction direction)
        {
            if (tail.Length == 0)
                return;

            MoveLastTailPartToHeadPosition();

            tail[0].Reposition(head.Location, direction);
            tail[0].SetDownStream(head.DownStream);
        }

        private void MoveLastTailPartToHeadPosition()
        {
            var lastTailPart = tail[tail.Length - 1];

            for (int i = tail.Length - 1; i > 0; i--)
            {
                tail[i] = tail[i - 1];
            }
            tail[0] = lastTailPart;
        }
    }
}