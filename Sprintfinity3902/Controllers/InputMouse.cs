using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;
using Sprintfinity3902;

namespace Sprintfinity3902.Controllers
{
    public class InputMouse : IController {

        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        private static InputMouse instance;
        private Game1 Game;
        private MouseState ms;
        private Point mouseLocation;

        public static InputMouse Instance {
            get {
                if (instance == null) {
                    instance = new InputMouse();
                    controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
                };

                return instance;
            }

        }

        public void Update(GameTime gameTime) {
            ms = Mouse.GetState();
            mouseLocation = new Point(ms.X, ms.Y);

            if (Game.pauseMenu.Pause && Game.pauseMenu.Transition == false)
                MouseMapInput();
        }

        private void addMapping(Interfaces.ICommand command, Keys key) {
            bool tryAdd = controllerMappings.TryAdd(key, command);
            if (tryAdd == false) {
                controllerMappings.Remove(key);
                controllerMappings.Add(key, command);
            }
        }

        public void RegisterCommand(Interfaces.ICommand command, params Keys[] keys) {
            foreach (Keys key in keys) {
                addMapping(command, key);
            }
        }

        public void RegisterCommand(Keys key, Interfaces.ICommand command) {
            addMapping(command, key);
        }

        public void GiveGame(Game1 game)
        {
            Game = game;
        }

        public void MouseMapInput()
        {
            if (mouseLocation.X > 54 * Global.Var.SCALE && mouseLocation.X < 91 * Global.Var.SCALE && mouseLocation.Y > 148 * Global.Var.SCALE && mouseLocation.Y < 174 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(1);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 148 * Global.Var.SCALE && mouseLocation.Y < 174 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(2);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 129 * Global.Var.SCALE && mouseLocation.X < 167 * Global.Var.SCALE && mouseLocation.Y > 148 * Global.Var.SCALE && mouseLocation.Y < 174 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(3);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 122 * Global.Var.SCALE && mouseLocation.Y < 148 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(4);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 54 * Global.Var.SCALE && mouseLocation.X < 91 * Global.Var.SCALE && mouseLocation.Y > 96 * Global.Var.SCALE && mouseLocation.Y < 122 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(5);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 96 * Global.Var.SCALE && mouseLocation.Y < 122 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(6);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 129 * Global.Var.SCALE && mouseLocation.X < 167 * Global.Var.SCALE && mouseLocation.Y > 96 * Global.Var.SCALE && mouseLocation.Y < 122 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(7);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 16 * Global.Var.SCALE && mouseLocation.X < 54 * Global.Var.SCALE && mouseLocation.Y > 70 * Global.Var.SCALE && mouseLocation.Y < 96 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(8);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 54 * Global.Var.SCALE && mouseLocation.X < 91 * Global.Var.SCALE && mouseLocation.Y > 70 * Global.Var.SCALE && mouseLocation.Y < 96 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(9);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 70 * Global.Var.SCALE && mouseLocation.Y < 96 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(10);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 129 * Global.Var.SCALE && mouseLocation.X < 167 * Global.Var.SCALE && mouseLocation.Y > 70 * Global.Var.SCALE && mouseLocation.Y < 96 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(11);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 167 * Global.Var.SCALE && mouseLocation.X < 205 * Global.Var.SCALE && mouseLocation.Y > 70 * Global.Var.SCALE && mouseLocation.Y < 96 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(12);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 16 * Global.Var.SCALE && mouseLocation.X < 54 * Global.Var.SCALE && mouseLocation.Y > 18 * Global.Var.SCALE && mouseLocation.Y < 42 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(13);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 44 * Global.Var.SCALE && mouseLocation.Y < 70 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(14);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 167 * Global.Var.SCALE && mouseLocation.X < 205 * Global.Var.SCALE && mouseLocation.Y > 44 * Global.Var.SCALE && mouseLocation.Y < 70 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(15);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 205 * Global.Var.SCALE && mouseLocation.X < 242 * Global.Var.SCALE && mouseLocation.Y > 44 * Global.Var.SCALE && mouseLocation.Y < 70 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(16);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 54 * Global.Var.SCALE && mouseLocation.X < 91 * Global.Var.SCALE && mouseLocation.Y > 18 * Global.Var.SCALE && mouseLocation.Y < 42 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(17);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > 91 * Global.Var.SCALE && mouseLocation.X < 129 * Global.Var.SCALE && mouseLocation.Y > 18 * Global.Var.SCALE && mouseLocation.Y < 42 * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(18);
                    Game.Pause();
                }
            }

        }

    }

}
