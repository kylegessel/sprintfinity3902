using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class LockedDoorRightState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public bool IsBombable { get; set; }
        public DoorDirection doorDirection { get; set; }



        public LockedDoorRightState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateLockedDoorRight();
            IsOpen = false;
            IsLocked = true;
            IsBombable = false;
            doorDirection = DoorDirection.RIGHT;
        }

        public void Open()
        {
            CurrentDoor.SetState(CurrentDoor.openDoorRight);
        }

        // To be implemented when room first entered, door starts opened then closes.
        public void Close()
        {
            //NULL
        }
    }
}
