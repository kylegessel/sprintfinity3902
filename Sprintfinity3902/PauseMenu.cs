using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902
{
    public class PauseMenu : Interfaces.IDrawable, Interfaces.IUpdateable
    {
        private int count;
        private Game1 Game;
        public Player Link;
        public Map Map { get; set; }
        public bool Pause { get; set; }
        public bool Transition { get; set; }

        public PauseMenu(Game1 game)
        {
            Transition = false;
            Pause = false;
            Game = game;
            Link = Game.link;
            count = 0;
            Map = new Map(new Vector2(15*Global.Var.SCALE, -161 * Global.Var.SCALE));
        }

        public void Update(GameTime gameTime)
        {
            if (Transition)
            {
                if (Pause)
                {
                    ChangePosition();
                    Game.link.Y = Game.link.Y + 2 * Global.Var.SCALE;
                    Map.Y = Map.Y + 2 * Global.Var.SCALE;

                    if (count == 176 * Global.Var.SCALE)
                    {
                        Transition = false;
                    }
                }
                if(Pause == false)
                {
                    ChangePosition();
                    Game.link.Y = Game.link.Y - 2 * Global.Var.SCALE;
                    Map.Y = Map.Y - 2 * Global.Var.SCALE;

                    if (count == 176 * Global.Var.SCALE)
                    {
                        Transition = false;
                        ReregisterCommands();
                    }
                }
            }
            count = count + 2 * Global.Var.SCALE;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch, Color.White);
        }

        public void PauseGame()
        {
            Pause = !Pause;
            Transition = true;
            count = 0;

            if (Pause)
                UnregisterCommands();
        }

        public void UnregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(Game), Keys.W, Keys.Up, Keys.S, Keys.Down, Keys.A, Keys.Left, Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new DoNothingCommand(Game), Keys.E, Keys.D1, Keys.D2, Keys.Z, Keys.N);

            KeyboardManager.Instance.RemoveKeyUpCallback(Keys.L, Keys.K);

            //Store Link within Game, then reset to that Link
        }
        
        public void ReregisterCommands()
        {
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveUpCommand((Player)Link), Keys.W, Keys.Up);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveLeftCommand((Player)Link), Keys.A, Keys.Left);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveDownCommand((Player)Link), Keys.S, Keys.Down);
            KeyboardManager.Instance.RegisterCommand(new SetPlayerMoveRightCommand((Player)Link), Keys.D, Keys.Right);
            KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(Game), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)Link, (BombItem)Game.bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)Link, (BoomerangItem)Game.boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)Link, (MovingSwordItem)Game.movingSword, (SwordHitboxItem)Game.hitboxSword), Keys.Z, Keys.N);

            KeyboardManager.Instance.RegisterKeyUpCallback(Game.dungeon.NextRoom, Keys.L);
            KeyboardManager.Instance.RegisterKeyUpCallback(Game.dungeon.PreviousRoom, Keys.K);
        }

        public void ChangePosition()
        {
            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().blocks)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
            }

            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().enemies.Values)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
            }

            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().items)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    entity.Y = entity.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    entity.Y = entity.Y - 2 * Global.Var.SCALE;
            }

            foreach (IEntity proj in Game.linkProj)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    proj.Y = proj.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    proj.Y = proj.Y - 2 * Global.Var.SCALE;
            }
            
            foreach(IEntity garbage in Game.dungeon.GetCurrentRoom().garbage)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    garbage.Y = garbage.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    garbage.Y = garbage.Y - 2 * Global.Var.SCALE;
            }

            foreach (IEntity door in Game.dungeon.GetCurrentRoom().doors)
            {
                if (count != 176 * Global.Var.SCALE && Pause)
                    door.Y = door.Y + 2 * Global.Var.SCALE;
                else if (count != 176 * Global.Var.SCALE && Pause == false)
                    door.Y = door.Y - 2 * Global.Var.SCALE;
            }

            // Case for the bomb as it doesn't work similarly to other projectiles.

            if (count != 176 * Global.Var.SCALE && Pause)
                Game.bombItem.Y = Game.bombItem.Y + 2 * Global.Var.SCALE;
            else if (count != 176 * Global.Var.SCALE && Pause == false)
                Game.bombItem.Y = Game.bombItem.Y - 2 * Global.Var.SCALE;
        }

    }
}
