using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IDungeon
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Build();
        void NextRoom();
        void PreviousRoom();
        IRoom GetCurrentRoom();
        void PauseGame();
    }
}
