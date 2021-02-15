using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.Interfaces
{
    public interface ISprite {

        public Animation Animation { get; }

        void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);

        void Update(GameTime gameTime);
    }
}