using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System.Diagnostics;

namespace Sprintfinity3902.Controllers
{
    public class InputKeyboard : IController
    {
        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        private static List<Keys> orderedKeyPress;

        private static InputKeyboard instance;

        public static InputKeyboard Instance {
            get {
                if (instance == null) {
                    instance = new InputKeyboard();
                    orderedKeyPress = new List<Keys>();
                    keyUpHandlers = new Dictionary<Keys, List<Action>>();
                    controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
                }
                return instance;
            }
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

        public bool KeyDown(Keys key) {
            return orderedKeyPress.Contains(key);
        }

        public void RegisterKeyUpCallback(Keys key, Action callback) {
            if (!keyUpHandlers.ContainsKey(key)) {
                keyUpHandlers[key] = new List<Action>();
            }
            keyUpHandlers[key].Add(callback);
        }

        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            Keys[] pressedKeys = ks.GetPressedKeys();

            for (var i = 0; i < orderedKeyPress.Count; i++) {
                if (!ks.IsKeyDown(orderedKeyPress[i])) {

                   if (keyUpHandlers.Count > 0) {
                        Debug.WriteLine(orderedKeyPress[i]);
                   }

                    

                    foreach (KeyValuePair<Keys, List<Action>> pair in keyUpHandlers) {
                        if (pair.Key == orderedKeyPress[i]) {
                            
                            foreach (Action handler in pair.Value) {
                                handler();
                            }
                        }
                    }
                    orderedKeyPress.RemoveAt(i);
                } 
            }

            foreach (Keys key in pressedKeys)
            {
                if (!orderedKeyPress.Contains(key)) {
                    orderedKeyPress.Insert(0, key);
                }
            }

            bool playerMoveHasExecuted = false;

            foreach (Keys key in orderedKeyPress) {
                if (playerMoveHasExecuted && (key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D)) {
                    continue;
                } else {
                    playerMoveHasExecuted = true;
                }
                controllerMappings[key].Execute();
            }

        }

    }
}
