using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Diagnostics;

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
            this.game = _game;
            Link = _game.link;
            direction = true;
            count = 0;

        }

        public void Update(GameTime gameTime)
        {

            if (((Game1)game).IsInState(Game1.GameState.PAUSED_TRANSITION)) {
                count = count + 2 * Global.Var.SCALE;

                ChangePosition();
                game.link.Y = game.link.Y + 2 * Global.Var.SCALE * (direction ? 1 : -1);

                /* Crucial Global.Var.SCALE remains an int so this equality is valid */
                if (count == HUD_HEIGHT * Global.Var.SCALE) {
                    ((Game1)game).UpdateState(direction ? Game1.GameState.PAUSED : Game1.GameState.PLAYING);
                    direction = !direction;
                    count = 0;
                }

            }
            
        }

        public void UnregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(game), Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left, Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(game), Keys.E, Keys.D1, Keys.D2, Keys.Z, Keys.N);

            KeyboardManager.Instance.RemoveKeyUpCallback(Keys.L, Keys.K);

            //Store Link within Game, then reset to that Link
        }
        
        public void ReregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveUpCommand((Player)Link), Keys.W, Keys.Up);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveLeftCommand((Player)Link), Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveDownCommand((Player)Link), Keys.S, Keys.Down);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveRightCommand((Player)Link), Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(game), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)Link, (BombItem)game.bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)Link, (BoomerangItem)game.boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)Link, (MovingSwordItem)game.movingSword, (SwordHitboxItem)game.hitboxSword), Keys.Z, Keys.N);

            KeyboardManager.Instance.RegisterKeyUpCallback(game.dungeon.NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(game.dungeon.PreviousRoom, Keys.K);
        }

        public void ChangePosition()
        {
            if (count == HUD_HEIGHT * Global.Var.SCALE) return ;

            int shiftAmount = 2 * Global.Var.SCALE * (direction ? 1 : -1);

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().blocks)
            {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().enemies.Values)
            {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in game.dungeon.GetCurrentRoom().items)
            {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity proj in game.linkProj)
            {
                proj.Y = proj.Y + shiftAmount;
            }
            
            foreach(IEntity garbage in game.dungeon.GetCurrentRoom().garbage)
            {
                garbage.Y = garbage.Y + shiftAmount;
            }

            foreach (IHud hud in game.huds)
            {
                foreach (IEntity icon in hud.Icons)
                {
                    icon.Y = icon.Y + shiftAmount;
                }
            }

            // Case for the bomb as it doesn't work similarly to other projectiles.

            game.bombItem.Y = game.bombItem.Y + shiftAmount;
        }

    }
}