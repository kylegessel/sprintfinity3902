using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractItem 
    {

        private static int ONE_THOUSAND = 1000;
        private static int SIXTY = 60;
        private static int FOUR = 4;
        private static int TWO = 2;
        private static int ELEVEN = 11;
        private static int FIFTEEN = 15;
        private static int NINE = 9;

        Player PlayerCharacter;
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
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (itemUseCount <= SIXTY)
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

            if (BombExplosion != null)
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
                Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
                BombExplosion.Move(new Vector2(-ONE_THOUSAND, -ONE_THOUSAND));
            }else if (itemUseCount == SIXTY)
            {
                BombExplosion.Move(Position);
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Bomb_Blow).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
            itemUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            itemUse = true;
            if (PlayerCharacter.CurrentState == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(player.X + FOUR*Global.Var.SCALE, player.Y + ELEVEN*Global.Var.SCALE);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(player.X + TWO*Global.Var.SCALE, player.Y - FIFTEEN*Global.Var.SCALE);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(player.X - NINE*Global.Var.SCALE, player.Y);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(player.X + Global.Var.TILE_SIZE*Global.Var.SCALE, player.Y);
            }
        }

    }
}
