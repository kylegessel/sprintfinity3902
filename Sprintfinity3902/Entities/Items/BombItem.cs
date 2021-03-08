using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractEntity {

        Player PlayerCharacter;
        BombExplosionItem BombExplosion;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        Vector2 Position2;
        Vector2 Position3;
        Vector2 Position4;
        Vector2 Position5;
        Vector2 Position6;
        Vector2 Position7;
        public BombItem(Vector2 position, BombExplosionItem bombExplode)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateSmokeItem();
            Position = position;
            BombExplosion = bombExplode;
            itemUse = false;
            itemUseCount = 0;
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (itemUseCount <= 60)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }

            if (BombExplosion != null)
            {
                BombExplosion.Draw(spriteBatch);
            }
        }
        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (itemUse)
            {
                ExplodeBomb();
            }

            if(BombExplosion != null)
            {
                BombExplosion.Update(gameTime);
            }
        }

        public void ExplodeBomb()
        {
            if(itemUseCount > 120)
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-1000, -1000);
                BombExplosion = null;
            }else if (itemUseCount == 60)
            {
                BombExplosion = new BombExplosionItem(Position);
            }
            itemUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            itemUse = true;
            if (PlayerCharacter.CurrentState == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(player.X + 4*Global.Var.SCALE, player.Y + 11*Global.Var.SCALE);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(player.X + 2*Global.Var.SCALE, player.Y - 15*Global.Var.SCALE);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(player.X - 9*Global.Var.SCALE, player.Y);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(player.X + 16*Global.Var.SCALE, player.Y);
            }
        }

    }
}
