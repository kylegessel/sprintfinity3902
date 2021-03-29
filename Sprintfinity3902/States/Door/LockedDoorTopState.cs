using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class LockedDoorTopState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public DoorDirection doorDirection { get; set; }



        public LockedDoorTopState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorTop();
            IsOpen = false;
            IsLocked = true;
            doorDirection = DoorDirection.UP;
        }

        public void Open()
        {
            CurrentDoor.SetState(CurrentDoor.openDoorTop);
        }

        // To be implemented when room first entered, door starts opened then closes.
        public void Close()
        {
            //NULL
        }
    }
}
