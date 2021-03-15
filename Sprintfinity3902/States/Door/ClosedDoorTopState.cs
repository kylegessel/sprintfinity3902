using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class ClosedDoorTopState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }

        public ClosedDoorTopState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateClosedDoorTop();
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
