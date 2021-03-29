using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IGame<T> where T : Enum
    {
        T State { get; }
        void Reset();
        void Pause();
        bool IsInState(T state);
        void UpdateState(T state);
    }
}
