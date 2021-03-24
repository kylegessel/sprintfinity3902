using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Controllers
{
    public class InputMouse : IController {

        /*MAGIC NUMBERS REFACTOR*/
        private static int SIXTEEN = 16;
        private static int EIGHTEEN = 18;
        private static int FORTY_TWO = 42;
        private static int FORTY_FOUR = 44;
        private static int SEVENTY = 70;
        private static int NINETY_SIX = 96;
        private static int FIFTY_FOUR = 54;
        private static int NINETY_ONE = 91;

        private static int ONE_HUNDRED_TWENTY_TWO = 122;
        private static int ONE_HUNDRED_TWENTY_NINE = 129;
        private static int ONE_HUNDRED_FORTY_EIGHT = 148;
        private static int ONE_HUNDRED_SIXTY_SEVEN = 167;
        private static int ONE_HUNDRED_SEVENTY_FOUR = 174;

        private static int TWO_HUNDRED_FIVE = 205;
        private static int TWO_HUNDRED_FORTY_TWO = 242;

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

            if (Game.IsInState(Game1.GameState.PAUSED) )
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

        //FOR SPRINT 3 ONLY
        /*MAGIC NUMBERS REFACTOR*/
        public void MouseMapInput()
        {
            if (mouseLocation.X > FIFTY_FOUR * Global.Var.SCALE && mouseLocation.X < NINETY_ONE * Global.Var.SCALE && mouseLocation.Y > ONE_HUNDRED_FORTY_EIGHT * Global.Var.SCALE && mouseLocation.Y < ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(1);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y > ONE_HUNDRED_FORTY_EIGHT * Global.Var.SCALE && mouseLocation.Y < ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(2);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_SIXTY_SEVEN * Global.Var.SCALE && mouseLocation.Y > ONE_HUNDRED_FORTY_EIGHT * Global.Var.SCALE && mouseLocation.Y < ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(3);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y >  ONE_HUNDRED_TWENTY_TWO * Global.Var.SCALE && mouseLocation.Y < ONE_HUNDRED_FORTY_EIGHT * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(4);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > FIFTY_FOUR * Global.Var.SCALE && mouseLocation.X < NINETY_ONE * Global.Var.SCALE && mouseLocation.Y >  NINETY_SIX * Global.Var.SCALE && mouseLocation.Y <  ONE_HUNDRED_TWENTY_TWO * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(5);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y >  NINETY_SIX * Global.Var.SCALE && mouseLocation.Y <  ONE_HUNDRED_TWENTY_TWO * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(6);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_SIXTY_SEVEN * Global.Var.SCALE && mouseLocation.Y >  NINETY_SIX * Global.Var.SCALE && mouseLocation.Y <  ONE_HUNDRED_TWENTY_TWO * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(7);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  SIXTEEN * Global.Var.SCALE && mouseLocation.X < FIFTY_FOUR * Global.Var.SCALE && mouseLocation.Y >  SEVENTY * Global.Var.SCALE && mouseLocation.Y <  NINETY_SIX * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(8);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > FIFTY_FOUR * Global.Var.SCALE && mouseLocation.X < NINETY_ONE * Global.Var.SCALE && mouseLocation.Y >  SEVENTY * Global.Var.SCALE && mouseLocation.Y <  NINETY_SIX * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(9);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y >  SEVENTY * Global.Var.SCALE && mouseLocation.Y <  NINETY_SIX * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(10);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_SIXTY_SEVEN * Global.Var.SCALE && mouseLocation.Y >  SEVENTY * Global.Var.SCALE && mouseLocation.Y <  NINETY_SIX * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(11);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  ONE_HUNDRED_SIXTY_SEVEN * Global.Var.SCALE && mouseLocation.X <  TWO_HUNDRED_FIVE * Global.Var.SCALE && mouseLocation.Y >  SEVENTY * Global.Var.SCALE && mouseLocation.Y <  NINETY_SIX * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(12);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  SIXTEEN * Global.Var.SCALE && mouseLocation.X < FIFTY_FOUR * Global.Var.SCALE && mouseLocation.Y >  EIGHTEEN * Global.Var.SCALE && mouseLocation.Y <  FORTY_TWO * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(13);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y >  FORTY_FOUR * Global.Var.SCALE && mouseLocation.Y <  SEVENTY * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(14);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  ONE_HUNDRED_SIXTY_SEVEN * Global.Var.SCALE && mouseLocation.X <  TWO_HUNDRED_FIVE * Global.Var.SCALE && mouseLocation.Y >  FORTY_FOUR * Global.Var.SCALE && mouseLocation.Y <  SEVENTY * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(15);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X >  TWO_HUNDRED_FIVE * Global.Var.SCALE && mouseLocation.X <  TWO_HUNDRED_FORTY_TWO * Global.Var.SCALE && mouseLocation.Y >  FORTY_FOUR * Global.Var.SCALE && mouseLocation.Y <  SEVENTY * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(16);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > FIFTY_FOUR * Global.Var.SCALE && mouseLocation.X < NINETY_ONE * Global.Var.SCALE && mouseLocation.Y >  EIGHTEEN * Global.Var.SCALE && mouseLocation.Y <  FORTY_TWO * Global.Var.SCALE)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    Game.dungeon.SetCurrentRoom(17);
                    Game.Pause();
                }
            }
            else if (mouseLocation.X > NINETY_ONE * Global.Var.SCALE && mouseLocation.X <  ONE_HUNDRED_TWENTY_NINE * Global.Var.SCALE && mouseLocation.Y >  EIGHTEEN * Global.Var.SCALE && mouseLocation.Y <  FORTY_TWO * Global.Var.SCALE)
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
