using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprintfinity3902.Controllers {
    public class InputKeyboard : IController {
        // A map of keys to commands
        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;
        
        // A map of keys to list of actions (methods)
        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        // A ordered list of the current keys pressed
        private static List<Keys> orderedKeyPress;

        // A list of keys relevant to players movement
        private static List<Keys> movementKeys;

        // Singleton instance variable
        private static InputKeyboard instance;

        public static InputKeyboard Instance {
            get {
                if (instance == null) {
                    instance = new InputKeyboard();
                    orderedKeyPress = new List<Keys>();
                    keyUpHandlers = new Dictionary<Keys, List<Action>>();
                    controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
                    movementKeys = new List<Keys>() {
                        Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right
                    };
                }
                return instance;
            }
        }

        public bool KeyDown(Keys key) {
            return orderedKeyPress.Contains(key);
        }

        // So far a key only needs one command, therefore we do not use a list of commands
        public void RegisterCommand(Interfaces.ICommand command, params Keys[] keys) {
            foreach (Keys key in keys) {
                if (!controllerMappings.TryAdd(key, command)) {
                    controllerMappings.Remove(key);
                    controllerMappings.Add(key, command);
                }
            }
        }

        public void RegisterKeyUpCallback(Action callback, params Keys[] keys) {
            foreach (Keys key in keys) {
                if (!keyUpHandlers.ContainsKey(key)) {
                    keyUpHandlers[key] = new List<Action>();
                }
                keyUpHandlers[key].Add(callback);
            }
        }

        public void Update() {
            // Get a snapshot of keyboard
            KeyboardState ks = Keyboard.GetState();
            Keys[] pressedKeys = ks.GetPressedKeys();

            FireHandlers(ks);

            /*
             * Adds all pressed keys to an ordered list of pressed keys if they don't already exist
             */
            foreach (Keys key in pressedKeys) {
                if (!orderedKeyPress.Contains(key)) {
                    orderedKeyPress.Insert(0, key);
                }
            }

            ExecuteCommands();
        }

        private void FireHandlers(KeyboardState ks) {
            /*
            * This loop calls handlers when a key is released
            */
            for (int i = 0; i < orderedKeyPress.Count; i++) {

                // The key which was put into the local pressed down list is no
                // longer present in the KeyboardState as being pressed.
                // It is therefore released.
                if (!ks.IsKeyDown(orderedKeyPress[i])) {

                    // Call each listener that needs to be notified
                    foreach (Action handler in keyUpHandlers[orderedKeyPress[i]]) {
                        handler();
                    }

                    // Remove the key from the pressed list
                    orderedKeyPress.RemoveAt(i);
                }
            }
        }

        private void ExecuteCommands() {
            /*
            * This loop executes commands for all keys pressed
            */
            bool playerMoveHasExecuted = false;

            foreach (Keys key in orderedKeyPress) {
                if (playerMoveHasExecuted && movementKeys.Contains(key)) {
                    continue;
                } else {
                    playerMoveHasExecuted = true;
                }
                controllerMappings[key].Execute();
            }
        }

        public void UnregisterListeners() {
            keyUpHandlers.Clear();
        }

        public void UnregisterCommands() {
            controllerMappings.Clear();
        }

    }
}
