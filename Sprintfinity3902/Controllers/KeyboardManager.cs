using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using IUpdateable = Sprintfinity3902.Interfaces.IUpdateable;

namespace Sprintfinity3902.Controllers
{
    public class KeyboardManager : IUpdateable {

        // List of keys that describe movement of Link
        private static List<Keys> MOVEMENT_KEYS = new List<Keys>() {
            Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right
        };

        // Dictionary of keys which map to an ICommand
        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        // Dictionary of keys which map to an Action
        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        // Stack with copies of this which can be popped
        private static Stack<Tuple<Dictionary<Keys, Interfaces.ICommand>, Dictionary<Keys, List<Action>>>> keyBoardInstanceStack;

        /* Singleton instance */

        private static KeyboardManager instance;
        public static KeyboardManager Instance {
            get {
                if (instance == null) {
                    instance = new KeyboardManager();
                }
                return instance;
            }
        }

        private KeyboardManager() {
            controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
            keyUpHandlers = new Dictionary<Keys, List<Action>>();
            keyBoardInstanceStack = new Stack<Tuple<Dictionary<Keys, Interfaces.ICommand>, Dictionary<Keys, List<Action>>>>();
        }

        /* Resets Class values */
        public void Reset(
            bool resetStack = true,
            Dictionary<Keys, Interfaces.ICommand> control = null,
            Dictionary<Keys, List<Action>> keyup = null) {

            /*foreach (Keys key in Enum.GetValues(typeof(Keys))) {
                RegisterCommand(new DoNothingCommand(), key);
            }*/

            if (resetStack) keyBoardInstanceStack.Clear();

            if (control == null) {
                controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
            }
            else controllerMappings = control;

            if (keyup == null) {
                keyUpHandlers = new Dictionary<Keys, List<Action>>();
            } else keyUpHandlers = keyup;

            
        }


        public void PushCommandMatrix(bool copyPreviousLayer = false) {
            Tuple<Dictionary<Keys, Interfaces.ICommand>, Dictionary<Keys, List<Action>>> snapshot;
            snapshot = new Tuple<Dictionary<Keys, Interfaces.ICommand>, Dictionary<Keys, List<Action>>>(controllerMappings, keyUpHandlers);
            keyBoardInstanceStack.Push(snapshot);
            if (copyPreviousLayer) {
                Dictionary<Keys, Interfaces.ICommand> dicRef = new Dictionary<Keys, ICommand>();
                foreach (KeyValuePair<Keys, Interfaces.ICommand> item in snapshot.Item1) {
                    dicRef.Add(item.Key, item.Value);
                }
                Dictionary<Keys, List<Action>> handRef = new Dictionary<Keys, List<Action>>();
                foreach (KeyValuePair<Keys, List<Action>> item in snapshot.Item2) {
                    handRef.Add(item.Key, item.Value);
                }
                Reset(resetStack: false, control: dicRef, keyup: handRef);
            } else {
                Reset(resetStack: false);
            }
        }

        public void PopCommandMatrix() {
            if (keyBoardInstanceStack.Count == 0) throw new IndexOutOfRangeException("You attempted to pop keyboard command matrix off a stack without any present.");
            Tuple<Dictionary<Keys, Interfaces.ICommand>, Dictionary<Keys, List<Action>>> snapshot;
            snapshot = keyBoardInstanceStack.Pop();
            Reset(resetStack: false, snapshot.Item1, snapshot.Item2);
        }

        /* Calls all listeners for 'key' */
        public void CallHandlers(Keys key) {
            if (keyUpHandlers.ContainsKey(key)) {

                foreach (Action listener in keyUpHandlers[key]) {
                    // Call listener

                    listener();
                }
            }
        }

        /* Calls commands for all pressed keys in 'keys' */
        public void CallCommands(List<Keys> keys) {
            bool playerHasMoved = false;
            foreach (Keys key in keys) {

                // Ensures only one Execution is performed for player movement
                if (MOVEMENT_KEYS.Contains(key)) {
                    if (playerHasMoved) {
                        continue;
                    } else {
                        playerHasMoved = true;
                    }
                }

                // Execute command
                if (controllerMappings.ContainsKey(key)) {
                    controllerMappings[key].Execute();
                }
                
            }
        }

        /* This is used to put a command into 'controllerMappings'
         * so that when a key is held, the command may be executed
         */
        public void RegisterCommand(Interfaces.ICommand command, params Keys[] keys) {
            foreach (Keys key in keys) {
                bool tryAdd = controllerMappings.TryAdd(key, command);
                if (tryAdd == false) {
                    controllerMappings.Remove(key);
                    controllerMappings.Add(key, command);
                }
            }
        }

        /* This is used to register a listener in 'keyUpHandlers'
         * so that if a key is released, listeners can be notified
         */
        public void RegisterKeyUpCallback(Action callback, params Keys[] keys) {
            foreach (Keys key in keys) {
                if (!keyUpHandlers.ContainsKey(key)) {
                    keyUpHandlers[key] = new List<Action>();
                }
                keyUpHandlers[key].Add(callback);
            }
        }

        public void RemoveKeyUpCallback(params Keys[] keys)
        {
            foreach(Keys key in keys)
            {
                keyUpHandlers.Remove(key);
            }
        }

        public void UnregisterListeners() {
            keyUpHandlers.Clear();
        }

        public void UnregisterCommands() {
            controllerMappings.Clear();
        }

        /* This method updates the InputKeyboard singleton
         * to remove clutter from game class. Additionally,
         * the InputKeyboard will call this.CallCommands and 
         * this.CallHandlers if it needs to.
         */
        public void Update(GameTime gameTime) {
            InputKeyboard.Instance.Update(gameTime);
        }


    }
}
