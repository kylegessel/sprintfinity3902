using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace Sprintfinity3902.Interfaces
{
    public interface IHud : IUpdateable
    {
        Vector2 WorldPoint { get; set; }

        List<IEntity> Icons { get; }

        void Initialize();

        void TranslateMatrix(Vector2 deltaVec);

        void Draw(SpriteBatch spriteBatch, Color color);
    }
}
