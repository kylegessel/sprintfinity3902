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



        public WallRightState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateWallRight();
            IsOpen = false;
            doorDirection = DoorDirection.RIGHT;
        }

        public void Open()
        {
            //NULL
        }

        public void Close()
        {
            //NULL
        }
    }
}
