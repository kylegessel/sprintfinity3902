using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Dungeon;
using System;
using System.Diagnostics;
using Sprintfinity3902.HudMenu;

namespace Sprintfinity3902
{
    public class PauseMenu :  Interfaces.IUpdateable
    {
        private int count;
        private Game1 game;
        private Player Link;
        private static int HUD_HEIGHT = 176;

        private bool direction;

        public PauseMenu(Game1 _game)
        {
            /* We should ask him about casting game or if we can code to concrete instead of interface. */
            game = _game;
            Link = _game.link;
            direction = true;
            count = 0;

        }

        public void Update(GameTime gameTime)
        {

            if ((game).IsInState(Game1.GameState.PAUSED_TRANSITION)) {
                ChangePosition();
                count = count + 2 * Global.Var.SCALE;
                game.link.Y = game.link.Y + 2 * Global.Var.SCALE * (direction ? 1 : -1);

                /* Crucial Global.Var.SCALE remains an int so this equality is valid */
                if (count == HUD_HEIGHT * Global.Var.SCALE) {
                    game.UpdateState(direction ? Game1.GameState.PAUSED : Game1.GameState.PLAYING);
                    direction = !direction;
                    count = 0;
                }

            } 
            
        }


        public void ChangePosition()
        {
            if (count == HUD_HEIGHT * Global.Var.SCALE) return ;

            int shiftAmount = 2 * Global.Var.SCALE * (direction ? 1 : -1);

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().blocks) {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().enemies.Values) {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().items)  {
                entity.Y = entity.Y + shiftAmount;
            }

            //foreach (IEntity proj in game.dungeon.linkProj) {
                //proj.Y = proj.Y + shiftAmount;
            //}
            
            foreach(IEntity garbage in game.dungeon.GetCurrentRoom().garbage) {
                garbage.Y = garbage.Y + shiftAmount;
            }

            foreach (IHud hud in game.huds) {
                hud.TranslateMatrix(new Vector2(0, shiftAmount));
            }

            foreach (IEntity door in game.dungeon.GetCurrentRoom().doors) {
                door.Y = door.Y + shiftAmount;
            }

            // Case for the bomb as it doesn't work similarly to other projectiles.

            ((Dungeon.Dungeon)game.dungeon).bombItem.Y = ((Dungeon.Dungeon)game.dungeon).bombItem.Y + shiftAmount;
            ((Dungeon.Dungeon)game.dungeon).bombExplosion.Y = ((Dungeon.Dungeon)game.dungeon).bombExplosion.Y + shiftAmount;
            ((Dungeon.Dungeon)game.dungeon).boomerangItem.Y = ((Dungeon.Dungeon)game.dungeon).boomerangItem.Y + shiftAmount;
            ((Dungeon.Dungeon)game.dungeon).bowArrow.Y = ((Dungeon.Dungeon)game.dungeon).bowArrow.Y + shiftAmount;
        }

    }
}