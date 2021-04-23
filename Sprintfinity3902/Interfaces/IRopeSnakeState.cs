namespace Sprintfinity3902.Interfaces
{
    public interface IRopeSnakeState
    {
        ISprite Sprite { get; set; }
        float Speed { get; set; }
        void Move();
        void Dart();
        void Update();
    }
}
