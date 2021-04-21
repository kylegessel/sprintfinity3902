using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;

namespace Sprintfinity3902.Entities
{
    public class HeartShop : AbstractEntity, IShop
    /*This either needs a refrence to player, or gets passed player*/
    {
        private static int HEART_X_OFFSET = 4 * Global.Var.SCALE;
        private static int HEART_Y_OFFSET = 4 * Global.Var.SCALE;
        private static int COST_Y_OFFSET = 8 * Global.Var.SCALE;
        private static int COST_X_OFFSET = 8 * Global.Var.SCALE;
        private static int HEARTCOST = 5;

        public IItem Product { get; set; }
        public int Cost { get; set; }
        public bool Buyable { get; set; } /*This may not be needed*/
        public List<ISprite> SpriteList { get; set; }

        private Vector2 NumPosition;
        private Vector2 xPosition;
        private Vector2 HeartPosition;

        public HeartShop(Vector2 pos)
        {
            Product = new HeartItem();
            Buyable = true;
            Cost = HEARTCOST;
            CreateSpriteList();
            Position = pos;
            HeartPosition.X = Position.X + HEART_X_OFFSET;
            HeartPosition.Y = Position.Y - HEART_Y_OFFSET;
            xPosition.X = Position.X;
            xPosition.Y = Position.Y + COST_Y_OFFSET ;
            NumPosition.X = Position.X + COST_X_OFFSET;
            NumPosition.Y = xPosition.Y;
        }

        private void CreateSpriteList()
        {
            SpriteList = ShopSpriteFactory.Instance.CreateHeartShopSprite();
            
        }
        public void BuyItem(IPlayer link)
        {
            if (Buyable)
            {
                link.itemcount[IItem.ITEMS.RUPEE] = link.itemcount[IItem.ITEMS.RUPEE] - HEARTCOST;
                link.LinkHealth = link.MaxHealth;
                Buyable = false;

                HudMenu.InGameHud.Instance.UpdateRupees(link.itemcount[IItem.ITEMS.RUPEE]);
                HudMenu.InGameHud.Instance.UpdateHearts(link.MaxHealth, link.LinkHealth);
                //Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            SpriteList[0].Draw(spriteBatch, HeartPosition, color);
            SpriteList[1].Draw(spriteBatch, xPosition, color);
            SpriteList[2].Draw(spriteBatch, NumPosition, color);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (ISprite sprite in SpriteList)
                sprite.Update(gameTime);
        }

        public override Rectangle GetBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, SpriteList[0].Animation.CurrentFrame.Width * Global.Var.SCALE, SpriteList[0].Animation.CurrentFrame.Height * Global.Var.SCALE);
        }
    }
}
