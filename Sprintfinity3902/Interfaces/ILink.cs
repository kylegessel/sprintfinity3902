using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Sprites;

namespace Sprintfinity3902.Interfaces
{
    public interface ILink : IEntity
    {
        public void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
        void RemoveDecorator();
    }
}

