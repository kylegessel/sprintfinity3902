using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Controllers
{
    public class InputKeyboard : IController
    {
        private Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        public InputKeyboard()
        {
            controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();

        }

        public void RegisterCommand(Keys key, Interfaces.ICommand command)
        {
            bool tryAdd = controllerMappings.TryAdd(key, command);
            if (tryAdd == false)
            {
                controllerMappings.Remove(key);
                controllerMappings.Add(key, command);
            }

        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();
            }
        }

    }
}
