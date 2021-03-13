using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Link
{
    class DamagedEntity : AbstractEntity, IEnemy, ICollidable
    {
        IRoom room;
        AbstractEntity decoratedEntity;
        int entityID;
        Color Color;
        int counter;
        int timer = 400;

        // pass room as well?
        public DamagedEntity(int entityID, AbstractEntity decoratedEntity, IRoom room)
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
            counter = timer % 12;
            if (counter < 3)
            {
                Color = Color.Aqua;
            }
            else if (counter < 6)
            {
                Color = Color.Red;
            }
            else if (counter < 9)
            {
                Color = Color.White;
            }
            else
            {
                Color = Color.Blue;
            }

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

        // How do I remove decorator?
        public IEntity GetUnDecorated()
        {
            return decoratedEntity;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            IEnemy enemy = (IEnemy)decoratedEntity;
            return enemy.HitRegister(enemyID, damage, stunLength, projDirection);
        }
    }
}
