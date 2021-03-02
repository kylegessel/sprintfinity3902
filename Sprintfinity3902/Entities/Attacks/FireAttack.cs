using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class FireAttack : AbstractEntity
    {
        public ISprite Sprite1;
        public ISprite Sprite2;
        public ISprite Sprite3;

        private bool isMoving;
        private Vector2 _positionUp;
        private Vector2 _positionDown;
        public Vector2 PositionUp
        {
            get { return _positionUp; }
            set { _positionUp = value; }
        }
        public float X_Up
        {
            get { return PositionUp.X; }
            set { _positionUp.X = value; }
        }
        public float Y_Up
        {
            get { return PositionUp.Y; }
            set { _positionUp.Y = value; }
        }
        public Vector2 PositionDown
        {
            get { return _positionDown; }
            set { _positionDown = value; }
        }
        public float X_Down
        {
            get { return PositionDown.X; }
            set { _positionDown.X = value; }
        }
        public float Y_Down
        {
            get { return PositionDown.Y; }
            set { _positionDown.Y = value; }
        }

        public FireAttack(Vector2 position)
        {
            Sprite1 = ItemSpriteFactory.Instance.CreateFireAttack();
            Sprite2 = ItemSpriteFactory.Instance.CreateFireAttack();
            Sprite3 = ItemSpriteFactory.Instance.CreateFireAttack();
        
            PositionUp = position;
            Position = position;
            PositionDown = position;
            isMoving = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (Sprite1 != null) 
                Sprite1.Update(gameTime);
            
            if (Sprite2 != null) 
                Sprite2.Update(gameTime); 
            
            if (Sprite3 != null) 
                Sprite3.Update(gameTime);

            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving)
            {
                Sprite1.Draw(spriteBatch, PositionUp, Color.White);
                Sprite2.Draw(spriteBatch, Position, Color.White);
                Sprite3.Draw(spriteBatch, PositionDown, Color.White);
            }
        }

        public override void Move()
        {
            //Implement 2 count integers that handle spread

            isMoving = true;

            X_Up = X_Up - 8;
            X = X - 8;
            X_Down = X_Down - 8;

            Y_Up = Y_Up - 4;
            Y_Down = Y_Down + 4;
        }
    }
}
