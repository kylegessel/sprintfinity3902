using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface ILink
    {
        ISprite Sprite
        {
            get; set;
        }
        Vector2 Position
        {
            get; set;
        }
        int X
        {
            get; set;
        }
        int Y
        {
            get; set;
        }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Color color);
        void Move();
        void SetState(IState state);
        void TakeDamage();

        void RemoveDecorator();
    }
}

