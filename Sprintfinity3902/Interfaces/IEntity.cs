using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface IEntity
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
        void Draw(SpriteBatch spriteBatch);
        void Move();
        void Attack();
        void SetState(IState state);
    }
}
