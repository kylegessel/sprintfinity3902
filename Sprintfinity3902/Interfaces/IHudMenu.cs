using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace Sprintfinity3902.Interfaces
{
    public interface IHud : IUpdateable
    {
        List<IEntity> Icons { get; }

        void Initialize();

        void Draw(SpriteBatch spriteBatch, Color color);
    }
}
