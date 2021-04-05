using System;

namespace Sprintfinity3902.Interfaces
{
    public interface IBomb
    {
        Boolean getItemUse();
        void ExplodeBomb();
        void UseItem(ILink Player);
    }
}
