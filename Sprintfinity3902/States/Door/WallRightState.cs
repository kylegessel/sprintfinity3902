using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class WallRightState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsOpen { get; set; }
        public DoorDirection doorDirection { get; set; }
        public bool IsLocked { get; set; }
        public bool IsBombable { get; set; }




        public WallRightState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateWallRight();
            IsOpen = false;
            IsLocked = false;
            IsBombable = true;
            doorDirection = DoorDirection.RIGHT;
        }

        public void Open()
        {
            if (CurrentDoor.DoorDestination != -1)
            {
                CurrentDoor.SetState(CurrentDoor.holeDoorRight);
            }
        }

        public void Close()
        {
            //NULL
        }
    }
}
