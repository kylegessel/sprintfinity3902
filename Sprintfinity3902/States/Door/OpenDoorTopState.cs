using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class OpenDoorTopState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }

        public OpenDoorTopState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateOpenDoorTop();
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
