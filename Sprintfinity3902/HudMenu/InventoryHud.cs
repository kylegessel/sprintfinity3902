using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class InventoryHud : IHud
    {
        private Game1 Game;
        private IPlayer Link;
        private IEntity selectedWeapon;
        public Vector2 WorldPoint;
        public List<IEntity> Icons { get; private set; }

        public InventoryHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -176 * Global.Var.SCALE);

            selectedWeapon = ((Dungeon.Dungeon)Game.dungeon).hitboxSword;

            Initialize();

            
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix();
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }
            //spriteBatch.Draw(new Texture2D(spriteBatch.GraphicsDevice, 100, 100), 
            //    WorldPoint,
            //    Color.Pink);
            popMatrix();

        }

        private void pushMatrix() {

            foreach (IEntity icon in Icons) {
                icon.Position = new Vector2(icon.Position.X + WorldPoint.X, icon.Position.Y + WorldPoint.Y);
            }

        }

        private void popMatrix()
        {

            foreach (IEntity icon in Icons) {
                icon.Position = new Vector2(icon.Position.X - WorldPoint.X, icon.Position.Y - WorldPoint.Y);
            }

        }

        public void Initialize()
        {
            Icons.Add(new InventoryHudEntity(new Vector2(0, 0)));
        }

    }
}
