namespace Sprintfinity3902.Interfaces
{
    public interface IGoriyaState
    {
        ISprite Sprite { get; set; }

        bool Start { get; set; }

        void Move();

        void Wait();

        void UseItem();

        void Update();
    }
}
