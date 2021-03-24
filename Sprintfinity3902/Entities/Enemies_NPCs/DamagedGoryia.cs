using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class DamagedGoryia : IEntity, IEnemy
    {
        IRoom room;
        IEntity decoratedGoryia;
        Color goryiaColor;
        int counter;
        int timer = 200;
        private ISprite _sprite;
        private Vector2 _position;
        private int goryiaID;

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
                //Position = new Vector2(value, Position.Y);
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
                //Position = new Vector2(Position.X, value);
            }
        }

        public DamagedGoryia(IEntity decoratedGoryia, IRoom room, int enemyID)
        {
            this.decoratedGoryia = decoratedGoryia;
            this.room = room;
            goryiaColor = Color.Red;
            goryiaID = enemyID;
        }


        public void Update(GameTime gameTime)
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
            counter = timer % 12;
            if (counter < 3)
            {
                goryiaColor = Color.Aqua;
            }
            else if (counter < 6)
            {
                goryiaColor = Color.Red;
            }
            else if (counter < 9)
            {
                goryiaColor = Color.White;
            }
            else
            {
                goryiaColor = Color.Blue;
            }

            decoratedGoryia.Update(gameTime);
        }
        public void Attack()
        {
            decoratedGoryia.Attack();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            decoratedGoryia.Draw(spriteBatch, goryiaColor);
        }

        public Rectangle GetBoundingRect()
        {
            return decoratedGoryia.GetBoundingRect();
        }

        public float GetStepSize()
        {
            return decoratedGoryia.GetStepSize();
        }

        public void Move()
        {
            decoratedGoryia.Move();
        }

        public void SetState(IPlayerState state)
        {
            decoratedGoryia.SetState(state);
        }

        public void SetStepSize(float size)
        {
            decoratedGoryia.SetStepSize(size);
        }

        public void RemoveDecorator()
        {
            //game.playerCharacter = decoratedLink;
            room.enemies[goryiaID] = decoratedGoryia;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, AbstractEntity.Direction projDirection, IRoom room)
        {
            //Do nothing
            return 0;
        }
    }


}
