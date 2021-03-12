using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Sprites
{
    public class RoomExteriorSprite : AbstractSprite
    {
        public Texture2D Texture { get; set; }

        private const int ROOM_X = 521;
        private const int ROOM_Y = 11;
        private const int ROOM_WIDTH = 256;
        private const int ROOM_HEIGHT = 176;

        public RoomExteriorSprite(Texture2D texture)
        {
            SpriteFrame sprite1 = new SpriteFrame(texture, ROOM_X, ROOM_Y, ROOM_WIDTH, ROOM_HEIGHT);
            Texture = texture;

            Animation = new Animation();
            Animation.AddFrame(sprite1, 0);
        }
    }
}
