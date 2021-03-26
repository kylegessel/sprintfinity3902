using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class SwordHitboxItem : AbstractEntity, IProjectile
    {
        IPlayer PlayerCharacter;
        Boolean itemUse;
        int itemUseCount;
        IPlayerState firingState;
        Direction swordDirection;
        Vector2 currentRect;

        public SwordHitboxItem(Vector2 position)
        {
            Position = position;
            currentRect = new Vector2(7, 12);
            itemUse = false;
            itemUseCount = 0;
        }

        public Boolean getItemUse()
        {
            return itemUse;
        }
        public Boolean Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            // Code for removing sword on contact, needs to be replaced.
            Position = new Vector2(-1000, -1000);
            // This can be improved, not long term.
            if (itemUseCount < 20) return false;
            return enemy.HitRegister(enemyID, 1, 0, swordDirection, room) <= 0;
        }

        public void Collide(IRoom room)
        {
            // Do nothing
        }
        public override void Draw(SpriteBatch spriteBatch, Color color)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (itemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            if (itemUseCount <= 5) //this time amount needs to be tweaked.
            {


            }
            else
            {
                itemUse = false;
                itemUseCount = 0;
                Position = new Vector2(-1000, -1000);
            }

            itemUseCount++;
        }
        public void UseItem(ILink player)
        {
            PlayerCharacter = (IPlayer)player;
            firingState = PlayerCharacter.CurrentState;

            if (firingState == PlayerCharacter.facingDownAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 5 * Global.Var.SCALE, PlayerCharacter.Y + 16 * Global.Var.SCALE);
                //currentRect = new Vector2(7, 12);
                swordDirection = Direction.DOWN;

            }
            else if (firingState == PlayerCharacter.facingUpAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 6 * Global.Var.SCALE, PlayerCharacter.Y - 12 * Global.Var.SCALE);
                //currentRect = new Vector2(7, 12);
                swordDirection = Direction.UP;

            }
            else if (firingState == PlayerCharacter.facingLeftAttack)
            {
                Position = new Vector2(PlayerCharacter.X - 12 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                //currentRect = new Vector2(12, 7);
                swordDirection = Direction.LEFT;
            }
            else if (firingState == PlayerCharacter.facingRightAttack)
            {
                Position = new Vector2(PlayerCharacter.X + 16 * Global.Var.SCALE, PlayerCharacter.Y + 5 * Global.Var.SCALE);
                //currentRect = new Vector2(12, 7);
                swordDirection = Direction.RIGHT;
            }
            itemUse = true;
        }


        /* will be used in sprint 4 for a clearer hitbox */
        //public override Rectangle GetBoundingRect()
        //{

        //   return new Rectangle((int)Position.X, (int)Position.Y, (int)currentRect.X, (int)currentRect.Y);
        //}

    }
}
