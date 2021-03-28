using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Sprites
{
    public abstract class AbstractSprite : ISprite {

        private Animation _animation;

        public Animation Animation {
            get {
                return _animation;
            }
            set {
                _animation = value;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color) {
            Animation.Draw(spriteBatch, position, color);
        }


        public virtual void Update(GameTime gameTime) {
            Animation.Update(gameTime);
        }
    }
}