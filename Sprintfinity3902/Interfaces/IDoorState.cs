namespace Sprintfinity3902.Interfaces
{
    public interface IDoorState
    {
        ISprite Sprite { get; set; }

        void Open();

        void Close();
    }
}
