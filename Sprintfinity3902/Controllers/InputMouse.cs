using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Controllers
{
    public class InputMouse : IController {

        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        private static InputMouse instance;

        public static InputMouse Instance {
            get {
                if (instance == null) {
                    instance = new InputMouse();
                    controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
                };

                return instance;
            }
                
        }
    
        public void Update() {
            MouseState ms = Mouse.GetState();
            Point mouseLocation = new Point(ms.X, ms.Y);

            // Do stuff here

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

    }
}
