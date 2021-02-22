/*
 * The basic idea for this AnimationFrame class came from the following tutorial on YouTube:
 * https://www.youtube.com/watch?v=2PKRJ0HSg4o
 */
namespace Sprintfinity3902.Sprites
{
    public class AnimationFrame
    {

        private SpriteFrame _sprite;

        public SpriteFrame Sprite {
            get {
                return _sprite;
            }
            set
            {
                _sprite = value;
            }
        }

        public float TimeStamp { get; set; }

        public AnimationFrame(SpriteFrame sprite, float timeStamp) {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }

    }
}
