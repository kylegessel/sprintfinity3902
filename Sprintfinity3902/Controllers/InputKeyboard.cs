using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprintfinity3902.Controllers {
    public class InputKeyboard : IController {

        private static List<Keys> orderedKeyPress;

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

        public void Update() {

            KeyboardState currentState = Keyboard.GetState();

            for (int i = 0; i < orderedKeyPress.Count; i++) {
                if (!currentState.IsKeyDown(orderedKeyPress[i])) {
                    KeyboardManager.Instance.CallHandlers(orderedKeyPress[i]);
                    Debug.Write(orderedKeyPress[i] + " ");
                    orderedKeyPress.RemoveAt(i);
                }
                
            }
            Debug.WriteLine("");

            foreach (Keys key in currentState.GetPressedKeys()) {
                if (!orderedKeyPress.Contains(key)) {
                    orderedKeyPress.Insert(0, key);
                }
            }

            KeyboardManager.Instance.CallCommands(orderedKeyPress);
        }

    }
}
