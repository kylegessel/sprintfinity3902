using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System.Collections.Generic;

namespace Sprintfinity3902.Entities
{
    public class BombShop : AbstractEntity, IShop
    /*This either needs a refrence to player, or gets passed player*/
    {
        private static Vector2 BOMB_OFFSET = new Vector2(4 * Global.Var.SCALE, -8 * Global.Var.SCALE);
        private static Vector2 X_OFFSET = new Vector2(0 , 8 * Global.Var.SCALE);
        private static Vector2 NUMBER_OFFSET = new Vector2(8 * Global.Var.SCALE, 8 * Global.Var.SCALE);
        private static int BOMB_COST = 5;
        private const int GET_BOMBS = 5;

        public IItem Product { get; set; }
        public int Cost { get; set; }
        public bool Buyable { get; set; } /*This may not be needed*/
        public List<ISprite> SpriteList { get; set; }

        public BombShop(Vector2 pos)
        {
            Product = new HeartItem();
            Buyable = true;
            Cost = BOMB_COST;
            CreateSpriteList();
            Position = pos;
        }

        private void CreateSpriteList()
        {
            SpriteList = ShopSpriteFactory.Instance.CreateBombShopSprite();

        }
        public void BuyItem(IPlayer link)
        {
            if (Buyable)
            {
                link.itemcount[IItem.ITEMS.RUPEE] = link.itemcount[IItem.ITEMS.RUPEE] - BOMB_COST;
                link.itemcount[IItem.ITEMS.BOMB] = link.itemcount[IItem.ITEMS.BOMB] + GET_BOMBS;
                Buyable = false;

                HudMenu.InGameHud.Instance.UpdateRupees(link.itemcount[IItem.ITEMS.RUPEE]);
                HudMenu.InGameHud.Instance.UpdateBomb(link.itemcount[IItem.ITEMS.BOMB]);
                HudMenu.InventoryHud.Instance.EnableItemInInventory(IPlayer.SelectableWeapons.BOMB);
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            SpriteList[0].Draw(spriteBatch, Position + BOMB_OFFSET, color);
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