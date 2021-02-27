using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Maps
{
    public class Room : IRoom
    {
        private List<IEntity> roomEntities;
        private ISprite _roomExterior { get; set; }
        private ISprite _roomInterior { get; set; }
        public ISprite RoomExterior
        {
            get
            {
                return _roomExterior;
            }
            set
            {
                _roomExterior = value;
            }
        }
        public ISprite RoomInterior
        {
            get
            {
                return _roomInterior;
            }
            set
            {
                _roomInterior = value;
            }
        }

        public Room()
        {
            _roomExterior = BlockSpriteFactory.Instance.CreateRoomExterior();
            _roomInterior = BlockSpriteFactory.Instance.CreateRoomInterior();
        }

        public void Update(GameTime gameTime)
        {
            RoomInterior.Update(gameTime);
            RoomExterior.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 roomPosition)
        {
            RoomInterior.Draw(spriteBatch, roomPosition, Color.White);
            RoomExterior.Draw(spriteBatch, roomPosition, Color.White);
        }
    }
}
