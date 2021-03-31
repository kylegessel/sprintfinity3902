using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IBomb
    {
        Boolean getItemUse();
        void ExplodeBomb();
        void UseItem(ILink Player);
    }
}
