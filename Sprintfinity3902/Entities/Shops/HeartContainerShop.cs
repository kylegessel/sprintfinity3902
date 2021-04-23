using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;

namespace Sprintfinity3902.Entities
{
    public class HeartContainerShop : AbstractEntity, IShop
    /*This either needs a refrence to player, or gets passed player*/
    {
        private static Vector2 HEARTCONT_OFFSET = new Vector2(4 * Global.Var.SCALE, -8 * Global.Var.SCALE);
        private static Vector2 X_OFFSET = new Vector2(0, 8 * Global.Var.SCALE);
        private static Vector2 NUMBER_OFFSET = new Vector2(8 * Global.Var.SCALE, 8 * Global.Var.SCALE);
        private static int HEARTCONTAINERCOST = 5;

        public IItem Product { get; set; }
        public int Cost { get; set; }
        public bool Buyable { get; set; } /*This may not be needed*/
        public List<ISprite> SpriteList { get; set; }

        public HeartContainerShop(Vector2 pos)
        {
            Product = new HeartContainerItem();
            Buyable = true;
            Cost = HEARTCONTAINERCOST;
            CreateSpriteList();
            Position = pos;
        }

        private void CreateSpriteList()
        {
            SpriteList = ShopSpriteFactory.Instance.CreateHeartContainerShopSprite();

        }
        public void BuyItem(IPlayer link)
        {
            if (Buyable)
            {
                link.itemcount[IItem.ITEMS.RUPEE] = link.itemcount[IItem.ITEMS.RUPEE] - HEARTCONTAINERCOST;
                link.MaxHealth = link.MaxHealth + 2;
                link.LinkHealth = link.LinkHealth + 2;

                HudMenu.InGameHud.Instance.UpdateRupees(link.itemcount[IItem.ITEMS.RUPEE]);
                HudMenu.InGameHud.Instance.UpdateHearts(link.MaxHealth, link.LinkHealth);
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            SpriteList[0].Draw(spriteBatch, Position + HEARTCONT_OFFSET, color);
            SpriteList[1].Draw(spriteBatch, Position + X_OFFSET, color);
            SpriteList[2].Draw(spriteBatch, Position + NUMBER_OFFSET, color);
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