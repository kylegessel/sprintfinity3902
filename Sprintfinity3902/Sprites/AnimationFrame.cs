using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.Sprites
{
    public class AnimationFrame
    {
        private Sprite _sprite;
        
        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value", "The sprite cannot be null.");

                _sprite = value;
            }
        }

        public float TimeStamp { get; }

        public AnimationFrame(Sprite sprite, float timeStamp)
        {
            Sprite = sprite;
            TimeStamp = timeStamp;
        }


    }
}
