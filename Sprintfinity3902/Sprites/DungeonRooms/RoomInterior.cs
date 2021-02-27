using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class RoomInterior : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ROOM_X = 1;
        private const int ROOM_Y = 192;
        private const int ROOM_WIDTH = 192;
        private const int ROOM_HEIGHT = 112;

        public RoomInterior(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ROOM_X, ROOM_Y, ROOM_WIDTH, ROOM_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
