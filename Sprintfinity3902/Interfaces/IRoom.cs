using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IRoom
    {
        int Id { get; set; }
        List<IEntity> roomEntities { get; set; }
        string path { get; set; }
        RoomLoader loader { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
