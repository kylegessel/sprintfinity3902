using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class NextRoomCommand : ICommand
    {
        private IDungeon Dungeon;

        public NextRoomCommand(IDungeon dungeon)
        {
            Dungeon = dungeon;
        }

        public void Execute()
        {
            Dungeon.NextRoom();
        }
    }
}
