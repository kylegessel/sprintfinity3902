using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BombItem : AbstractEntity {

        Player PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        ISprite Sprite2;
        Vector2 Position2;
        Vector2 Position3;
        Vector2 Position4;
        Vector2 Position5;
        Vector2 Position6;
        Vector2 Position7;
        public BombItem(Vector2 position)
        {
            Sprite = ItemSpriteFactory.Instance.CreateBombItem();
            Sprite2 = ItemSpriteFactory.Instance.CreateSmokeItem();
            Position = position;
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
            else if (itemUseCount < 120)
            {
                Sprite2.Draw(spriteBatch, Position, Color.White);
                Sprite2.Draw(spriteBatch, Position2, Color.White);
                Sprite2.Draw(spriteBatch, Position3, Color.White);
                Sprite2.Draw(spriteBatch, Position4, Color.White);
                Sprite2.Draw(spriteBatch, Position5, Color.White);
                Sprite2.Draw(spriteBatch, Position6, Color.White);
                Sprite2.Draw(spriteBatch, Position7, Color.White);
            }
        }
        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Sprite2.Update(gameTime);
            if (itemUse)
            {
                ExplodeBomb();
            }
        }

        public void ExplodeBomb()
        {
            if(itemUseCount > 120)
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-1000, -1000);
                Sprite2.Animation.Stop();
            }else if (itemUseCount == 60)
            {
                Position = new Vector2(Position.X - 15, Position.Y);
                Sprite2.Animation.Play();
            }
            itemUseCount++;
        }

        public void UseItem(Player player)
        {
            PlayerCharacter = player;
            itemUse = true;
            if (PlayerCharacter.CurrentState == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(player.X + 20, player.Y + 55);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(player.X + 10, player.Y - 75);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(player.X - 45, player.Y);
            }
            else if (PlayerCharacter.CurrentState == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(player.X + 80, player.Y);
            }

            Position2 = new Vector2(Position.X - 95, Position.Y);
            Position3 = new Vector2(Position.X + 65, Position.Y);
            Position4 = new Vector2(Position.X + 25, Position.Y - 80);
            Position5 = new Vector2(Position.X - 55, Position.Y - 80);
            Position6 = new Vector2(Position.X + 25, Position.Y + 80);
            Position7 = new Vector2(Position.X - 55, Position.Y + 80);
        }

    }
}
