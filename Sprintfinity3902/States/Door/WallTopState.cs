using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States.Door
{
    class WallTopState : IDoorState
    {

        public Entities.Doors.Door CurrentDoor { get; set; }
        public ISprite Sprite { get; set; }

        public WallTopState(Entities.Doors.Door currentDoor)
        {
            CurrentDoor = currentDoor;
            Sprite = BlockSpriteFactory.Instance.CreateWallTop();
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
