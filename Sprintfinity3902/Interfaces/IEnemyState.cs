namespace Sprintfinity3902.Interfaces
{
    public interface IEnemyState
    {
        ISprite Sprite { get; set; }

        bool Start { get; set; }

        void Move();

        void Wait();

        void UseItem();

        void Update();
    }
}
