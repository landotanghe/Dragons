using System.Linq;
using Assets.FuryEngine.Dragons;
using Assets.FuryEngine.Location;
using UnityEngine;

namespace Assets.Dragons
{
    public class Dragon : MonoBehaviour
    {
        public Head head;
        public TailSegment[] tail;
        public Board board;

        public Bar fireBar;
        public Bar waterBar;
        public PlayerColor color;

        public Dragon()
        {
            DragonX.OnDragonHealed += OnDragonHealed;
            DragonX.OnDragonTookDamage += OnDragonDamaged;

            DragonX.OnDragonSpitFire += UpdateFire;
            DragonX.OnDragonConsumedFire += UpdateFire;

            DragonX.MovedEventHandler += OnDragonMoved;
        }

        private void UpdateFire(DragonX.DragonFireEventData @event)
        {
            if (@event.Color != color)
                return;
            fireBar.FillRate = @event.ConsumedFire;
        }

        public void Start()
        {
        }

        public void Update()
        {
        }
        
        public void OnDragonHealed(DragonX.DragonHealthEventData @event)
        {
            if (@event.Color != color)
                return;
            UpdateHealth(@event);
        }

        public void OnDragonDamaged(DragonX.DragonHealthEventData @event)
        {
            if (@event.Color != color)
                return;
            UpdateHealth(@event);
        }

        private void UpdateHealth(DragonX.DragonHealthEventData @event)
        {
            waterBar.FillRate = @event.Health;
            if (tail.Length > @event.TailLength)
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