using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface IEntity : ICollidable
    {
        ISprite Sprite
        {
            get; set;
        }
        Vector2 Position
        {
            get; set;
        }
        float X
        {
            get; set;
        }
        float Y
        {
            get; set;
        }
        bool STATIC 
        { 
            get; set; 
        }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Color color);
        void Move();
        void Attack();
        Rectangle GetBoundingRect();
        void SetStepSize(float size);
        float GetStepSize();
    }
}
