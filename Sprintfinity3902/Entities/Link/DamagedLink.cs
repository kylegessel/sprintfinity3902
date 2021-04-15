using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Link
{
    public class DamagedLink : ILink
    {

        private static int MOD_BOUND = 12;
        private static int THREE = 3;
        private static int SIX = 6;
        private static int NINE = 9;

        Game1 game;
        IPlayer decoratedLink;
        Color linkColor;
        int counter;
        int timer = 200;



        public ISprite Sprite
        {
            get {
                return decoratedLink.Sprite;
            }
            set {
                decoratedLink.Sprite = value;
            }
        }

        public Vector2 Position
        {
            get {
                return decoratedLink.Position;
            }
            set {
                decoratedLink.Position = value;
            }
        }
        public float X
        {
            get {
                return decoratedLink.Position.X;
            }
            set {
                decoratedLink.X = value;
            }
        }
        public float Y
        {
            get {
                return decoratedLink.Position.Y;
            }
            set {
                decoratedLink.Y = value;
            }
        }
        public bool STATIC
        {
            get {
                return decoratedLink.STATIC;
            }
            set {
                decoratedLink.STATIC = value;
            }
        }



        public DamagedLink(IPlayer decoratedLink, Game1 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;
            linkColor = Color.Red;
        }
        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {
                RemoveDecorator();
            }
            //Implement logic to determine color
            counter = timer % MOD_BOUND;
            if (counter < THREE)
            {
                linkColor = Color.Aqua;
            }
            else if (counter < SIX)
            {
                linkColor = Color.Red;
            }
            else if (counter < NINE)
            {
                linkColor = Color.White;
            }
            else
            {
                linkColor = Color.Blue;
            }

            decoratedLink.Update(gameTime);

        }

        public bool IsCollidable()
        {
            return decoratedLink.IsCollidable();
        }
        public void Draw(SpriteBatch spriteBatch, Color Ignorecolor)
        {
            decoratedLink.Draw(spriteBatch, linkColor);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 pos, Color Ignorecolor)
        {
            decoratedLink.Draw(spriteBatch, linkColor);
        }
        public void Move()
        {
            decoratedLink.Move();
        }
        public void Attack()
        {
            decoratedLink.Attack();
        }
        public void SetState(IPlayerState state)
        {
            decoratedLink.SetState(state);
        }
        public void RemoveDecorator()
        {
            decoratedLink.RemoveDecorator();
            game.link = decoratedLink;
        }
        public void UseItem(IItem.ITEMS item)
        {
            decoratedLink.UseItem(item);
        }
        public void UseItem()
        {
            decoratedLink.UseItem();
        }
        public void Pickup(IItem item)
        {
            decoratedLink.Pickup(item);
        }
        public void DeathSpin(bool end)
        {
            RemoveDecorator();
            decoratedLink.DeathSpin(end);
        }

        public Rectangle GetBoundingRect()
        {
            return decoratedLink.GetBoundingRect();
        }

        public void SetStepSize(float size)
        {
            decoratedLink.SetStepSize(size);
        }

        public float GetStepSize()
        {
            return decoratedLink.GetStepSize();
        }
    }
}
