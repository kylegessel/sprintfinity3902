using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Ardrey.Sprint0.Commands;
using Sprintfinity3902.Interfaces;

namespace Ardrey.Sprint0
{
    public class InputKeyboard : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public InputKeyboard()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();

        }

        public void RegisterCommand(Keys key, ICommand command)
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
