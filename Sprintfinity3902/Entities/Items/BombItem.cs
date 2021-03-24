using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractItem {

        ILink PlayerCharacter;
        BombExplosionItem BombExplosion;
        Boolean itemUse;
        int itemUseCount;
        public BombItem(Vector2 position, BombExplosionItem bombExplode)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Position = position;
            BombExplosion = bombExplode;
            itemUse = false;
            itemUseCount = 0;
            ID = IItem.ITEMS.BOMB;
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (itemUseCount <= 60)
            {
                Sprite.Draw(spriteBatch, Position, Color.White);
            }

            if (BombExplosion != null)
            {
                BombExplosion.Draw(spriteBatch, Color.White);
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
                BombExplosion.Move(new Vector2(-1000, -1000));
            }else if (itemUseCount == 60)
            {
                BombExplosion.Move(Position);
            }
            itemUseCount++;
        }

        public void UseItem(ILink player)
        {
            PlayerCharacter = player;
            itemUse = true;
            if ( ((Player)PlayerCharacter).CurrentState == ((Player)PlayerCharacter).facingDownItem)
            {
                Position = new Vector2(player.X + 4*Global.Var.SCALE, player.Y + 11*Global.Var.SCALE);
            }
            else if ( ((Player)PlayerCharacter).CurrentState == ((Player)PlayerCharacter).facingUpItem)
            {
                Position = new Vector2(player.X + 2*Global.Var.SCALE, player.Y - 15*Global.Var.SCALE);
            }
            else if ( ((Player)PlayerCharacter).CurrentState == ((Player)PlayerCharacter).facingLeftItem)
            {
                Position = new Vector2(player.X - 9*Global.Var.SCALE, player.Y);
            }
            else if ( ((Player)PlayerCharacter).CurrentState == ((Player)PlayerCharacter).facingRightItem)
            {
                Position = new Vector2(player.X + 16*Global.Var.SCALE, player.Y);
            }
        }

    }
}
