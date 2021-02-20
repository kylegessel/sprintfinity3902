using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprintfinity3902.Controllers {
    public class InputKeyboard : IController {

        // This is an ordered list of the pressed keys
        private static List<Keys> orderedKeyPress;

        /* Singleton instance */

        private static InputKeyboard instance;

        public static InputKeyboard Instance {
            get {
                if (instance == null) {
                    instance = new InputKeyboard();
                    orderedKeyPress = new List<Keys>();
                }
                return instance;
            }
        }

        public List<Keys> GetOrderedKeyPress() {
            return orderedKeyPress;
        }

        /* This checks to see if keys were released; if so,
         * listeners are called. Also new pressed keys are 
         * added to 'orderedKeyPress'.
         */
        public void Update(GameTime gameTime) {

            KeyboardState currentState = Keyboard.GetState();

            // Checks to see if keys were released
            for (int i = 0; i < orderedKeyPress.Count; i++) {
                if (!currentState.IsKeyDown(orderedKeyPress[i])) {
                    KeyboardManager.Instance.CallHandlers(orderedKeyPress[i]);
                    Debug.Write(orderedKeyPress[i] + " ");
                    orderedKeyPress.RemoveAt(i);
                }
                
            }
            Debug.WriteLine("");

            // Check to add new keys
            foreach (Keys key in currentState.GetPressedKeys()) {
                if (!orderedKeyPress.Contains(key)) {
                    orderedKeyPress.Insert(0, key);
                }
            }

            // Executes commands by giving list of pressed keys to KeyboardManager
            KeyboardManager.Instance.CallCommands(orderedKeyPress);
        }

    }
}
