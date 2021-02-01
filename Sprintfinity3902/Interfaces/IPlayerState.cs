using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.Interfaces
{
    public interface IPlayerState
    {
        public ISprite Sprite { get; set; }
        void Move();
    }
}
