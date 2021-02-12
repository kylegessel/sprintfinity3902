using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IPlayerState
    {
        ISprite Sprite { get; set; }
        void Move();
        //void TakeDamage();
        //void RemoveDecorator();
    }
}
