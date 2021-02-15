using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.Controllers
{
    public class InputKeyboard : IController
    {
        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        private static List<Keys> orderedKeyPress;

        private static List<Keys> movementKeys;

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

        private void addCallback(Keys key, Action callback) {
            if (!keyUpHandlers.ContainsKey(key)) {
                keyUpHandlers[key] = new List<Action>();
            }
            keyUpHandlers[key].Add(callback);
        }

        public void RegisterKeyUpCallback(Keys key, Action callback) {
            addCallback(key, callback);
        }

        public void RegisterKeyUpCallback(Action callback, params Keys[] keys) {
            foreach (Keys key in keys) {
                addCallback(key, callback);
            }
        }

        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            Keys[] pressedKeys = ks.GetPressedKeys();

            for (var i = 0; i < orderedKeyPress.Count; i++) {
                if (!ks.IsKeyDown(orderedKeyPress[i])) {

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
                if (playerMoveHasExecuted && movementKeys.Contains(key)) {
                    continue;
                } else {
                    playerMoveHasExecuted = true;
                }
                controllerMappings[key].Execute();
            }

        }

    }
}
