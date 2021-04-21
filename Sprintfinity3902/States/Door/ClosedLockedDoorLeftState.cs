using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class ClosedLockedDoorLeftState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }

        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public bool IsBombable { get; set; }
        public DoorDirection doorDirection { get; set; }



        public ClosedLockedDoorLeftState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorLeft();
            IsOpen = false;
            IsLocked = false;
            IsBombable = false;
            doorDirection = DoorDirection.LEFT;
        }

        public void Open()
        {
            CurrentDoor.SetState(CurrentDoor.lockedDoorLeft);
        }

        public void Close()
        {
            //Door can't be closed.
        }
    }
}
