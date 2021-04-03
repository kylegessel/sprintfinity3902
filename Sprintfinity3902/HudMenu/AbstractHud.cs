using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public abstract class AbstractHud : IHud
    {
        public Vector2 WorldPoint { get; set; }

        public List<IEntity> Icons { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix(Icons.ToArray());
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
            popMatrix(Icons.ToArray());
        }

        public abstract void Initialize();

        public abstract void Update(GameTime gameTime);

        public abstract void UpdateSelf();
        protected void pushMatrix(params IEntity[] moveEntities)
        {
            foreach (IEntity entity in moveEntities) {
                entity.Position = new Vector2(entity.Position.X + WorldPoint.X, entity.Position.Y + WorldPoint.Y);
            }
        }

        protected void popMatrix(params IEntity[] moveEntities)
        {
            foreach (IEntity entity in moveEntities) {
                entity.Position = new Vector2(entity.Position.X - WorldPoint.X, entity.Position.Y - WorldPoint.Y);
            }
        }
        public void TranslateMatrix(Vector2 deltaVec)
        {
            WorldPoint = new Vector2(WorldPoint.X + deltaVec.X, WorldPoint.Y + deltaVec.Y);
        }
    }
}
