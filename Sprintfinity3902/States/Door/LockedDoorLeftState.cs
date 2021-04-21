using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class LockedDoorLeftState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public bool IsBombable { get; set; }
        public DoorDirection doorDirection { get; set; }


        public LockedDoorLeftState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorLeft();
            IsOpen = false;
            IsLocked = true;
            IsBombable = false;
            doorDirection = DoorDirection.LEFT;
        }

        public void Open()
        {
            CurrentDoor.SetState(CurrentDoor.openDoorLeft);
        }

        // To be implemented when room first entered, door starts opened then closes.
        public void Close()
        {
            CurrentDoor.SetState(CurrentDoor.closedLockedDoorLeft);
        }
    }
}
