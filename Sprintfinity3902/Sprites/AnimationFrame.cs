using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Sprites
{
    public class AnimationFrame
    {
        private SpriteFrame _sprite;

        public SpriteFrame Sprite
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

        public float TimeStamp { get; }

        public AnimationFrame(SpriteFrame sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }


    }
}
