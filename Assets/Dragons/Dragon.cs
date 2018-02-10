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
        public PlayerColor color;

        public Dragon()
        {

        }
        
        public void Start()
        {
            DragonX.OnDragonTookDamage += OnDragonDamaged;
            DragonX.MovedEventHandler += OnDragonMoved;
        }

        public void Update()
        {
        }
        

        public void OnDragonDamaged(DragonX.DragonTookDamageEvent @event)
        {
            if (@event.Color != color)
                return;

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
            if (@event.Color != color)
                return;

            MoveTo(@event.Location, @event.Direction);
        }
                
        private void MoveTo(Location target, Direction direction)
        {
            Debug.Log("head@ " + head.Location.X + "," + head.Location.Y);
            MoveTailTo(tail, head.Location, direction);
            head.Reposition(target, direction);
        }
        
        private void MoveTailTo(TailSegment[] tail, Location target, Direction direction)
        {
            foreach (var segment in tail)
            {
                var previousLocation = segment.Location;
                var previousDirection = segment.Direction;
                Debug.Log("segment was @ " + previousLocation.X + ", " + previousLocation.Y);

                segment.Reposition(target, direction);
                target = previousLocation;
                direction = previousDirection;
            }
        }
    }
}