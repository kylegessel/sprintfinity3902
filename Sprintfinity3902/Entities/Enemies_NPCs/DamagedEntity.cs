using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System;

namespace Sprintfinity3902.Link
{
    class DamagedEntity : AbstractEntity, IEnemy
    {

        private static int NINE = 9;
        private static int SIX = 6;
        private static int THREE =  3;
        private static int MOD_BOUND = 12;

        IRoom room;
        IEntity decoratedEntity;
        int entityID;
        Color Color;
        int counter;
        int timer = 30;
        

        // pass room as well?
        public DamagedEntity(int entityID, IEntity decoratedEntity, IRoom room)
        {
            this.entityID = entityID;
            this.decoratedEntity = decoratedEntity;
            this.room = room;
            Position = decoratedEntity.Position;
            Sprite = decoratedEntity.Sprite;
            Color = Color.Red;
        }

        public override void Update(GameTime gameTime)
        {
            timer--;
            // No remove decorator here as we'll have that happen when the enemy is done with it's "hit."
            //Implement logic to determine color
            counter = timer % MOD_BOUND;
            if (counter < THREE)
            {
                Color = Color.Aqua;
            }
            else if (counter < SIX)
            {
                Color = Color.Red;
            }
            else if (counter < NINE)
            {
                Color = Color.White;
            }
            else
            {
                Color = Color.Blue;
            }

            Position = decoratedEntity.Position;
            decoratedEntity.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            decoratedEntity.Draw(spriteBatch, Color);
        }

        public override void Move()
        {
            decoratedEntity.Move();
        }

        public override void Attack()
        {
            decoratedEntity.Attack();
        }

        public override void SetState(IPlayerState state)
        {
            decoratedEntity.SetState(state);
        }

        public override Rectangle GetBoundingRect()
        {
            return decoratedEntity.GetBoundingRect();
        }

        public override Boolean IsCollidable()
        {
            return decoratedEntity.IsCollidable();
        }

        // How do I remove decorator?
        public void RemoveDecorator()
        {
            room.enemies[entityID] = decoratedEntity;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            IEnemy enemy = (IEnemy)decoratedEntity;
            return enemy.HitRegister(enemyID, damage, stunLength, projDirection, room);
        }
    }
}
