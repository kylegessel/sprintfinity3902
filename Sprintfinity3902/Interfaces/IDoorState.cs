using Sprintfinity3902.States.Door;

namespace Sprintfinity3902.Interfaces
{
    public interface IDoorState
    {
        ISprite Sprite { get; set; }

        bool IsOpen { get; set; }
        DoorDirection doorDirection { get; set; }
        void Open();

        void Close();
    }
}
