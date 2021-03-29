using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class ClosedDoorLeftState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }

        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public DoorDirection doorDirection { get; set; }



        public ClosedDoorLeftState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorLeft();
            IsOpen = false;
            IsLocked = false;
            doorDirection = DoorDirection.LEFT;
        }

        public void Open()
        {
            CurrentDoor.SetState(CurrentDoor.openDoorLeft);
        }

        public void Close()
        {
            //Door can't be closed.
        }
    }
}
