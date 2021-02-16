using Sprintfinity3902.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprintfinity3902.Commands
{
    public class ShiftListCommand<T> : ICommand
    {
        private List<T> _list;
        private int _cycleBy;

        public ShiftListCommand(ref List<T> list, int delta)
        {
            _list = list;
            _cycleBy = delta;
        }

        public void Execute()
        {
            Debug.WriteLine(_list.ToString());

            List<T> holder = new List<T>();
            for (int i = 0; i< _cycleBy % _list.Count; i++) {
                holder.Add(_list[i]);
            }

            _list.RemoveRange(0, _cycleBy % _list.Count );

            _list.AddRange(holder);

            Debug.WriteLine(_list.ToString());

        }
    }
}

