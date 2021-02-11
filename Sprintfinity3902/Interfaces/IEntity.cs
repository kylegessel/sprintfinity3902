using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Sprites;

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
        void SetState(IPlayerState state);
    }
}
