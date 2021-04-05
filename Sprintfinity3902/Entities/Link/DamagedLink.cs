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
        private ISprite _sprite;
        private Vector2 _position;



        public ISprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public float X
        {
            get
            {
                return (int)Position.X;
            }
            set
            {
                _position.X = value;
            }
        }
        public float Y
        {
            get
            {
                return (int)Position.Y;
            }
            set
            {
                _position.Y = value;
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


        public void Draw(SpriteBatch spriteBatch, Color Ignorecolor)
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
            //game.link = decoratedLink;
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
    }
}
