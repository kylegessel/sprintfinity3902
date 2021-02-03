using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IPlayerState
    {
        public ISprite Sprite { get; set; }
        void Move();
    }
}
