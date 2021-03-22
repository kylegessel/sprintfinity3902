using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public class LoseWrapper : RoomWrapper
    {

        private IDungeon dungeon;
        public LoseWrapper(IRoom room, IDungeon dung) : base(room)
        {
            dungeon = dung;
            SoundManager.Instance.PauseAll();
            SoundLoader.Instance.GetSound(SoundLoader.Sounds.Game_Over).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Draw(spriteBatch, Color.Yellow);
            wrapup();
        }

        private void wrapup()
        {
            dungeon.CurrentRoom = CurrentState;
        }
    }
}
