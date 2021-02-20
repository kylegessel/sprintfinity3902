using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Controllers {
    public class KeyboardManager {

        // List of keys that describe movement of Link
        private static List<Keys> MOVEMENT_KEYS = new List<Keys>() {
            Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right
        };

        // Dictionary of keys which map to an ICommand
        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;

        // Dictionary of keys which map to an Action
        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        // List of counter variables which can be incremented or decremented
        private static List<int> counters;

        /* Singleton instance */

        private static KeyboardManager instance;
        public static KeyboardManager Instance {
            get {
                if (instance == null) {
                    instance = new KeyboardManager();
                    controllerMappings = new Dictionary<Keys, ICommand>();
                    keyUpHandlers = new Dictionary<Keys, List<Action>>();
                    counters = new List<int>();
                }
                return instance;
            }
        }

        public KeyboardManager() {
            Reset();
        }

        /* Resets Class values */
        public void Reset() {
            counters = new List<int>();
            keyUpHandlers = new Dictionary<Keys, List<Action>>();
            controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
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
                controllerMappings[key].Execute();
            }
        }

        /* Sets up Listeners and Command mappings */
        public void Initialize(Player player) {
            foreach (Keys key in Enum.GetValues(typeof(Keys))) {
                RegisterCommand(new DoNothingCommand(), key);
            }

            RegisterCommand(new SetPlayerMoveUpCommand((Player)player), Keys.W, Keys.Up);
            RegisterCommand(new SetPlayerMoveLeftCommand((Player)player), Keys.A, Keys.Left);
            RegisterCommand(new SetPlayerMoveDownCommand((Player)player), Keys.S, Keys.Down);
            RegisterCommand(new SetPlayerMoveRightCommand((Player)player), Keys.D, Keys.Right);
            
            RegisterKeyUpCallback(
                ((Player)player).CurrentState.Sprite.Animation.Stop,
            Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.E);
        }

        /* Creates an index in counters list initialized to 0
         * if 'decr' or 'incr' are released then the value of counters[index]
         * will decrease or increase -- this is useful in sprint 2 to cycle through 
         * blocks, items, and NPC
         */
        public int CreateNewDeltaKeys(Keys decr, Keys incr) {
            
            int index = counters.Count;
            counters.Add(0);
            RegisterKeyUpCallback(() => {
                counters[index]--;
            }, decr);
            RegisterKeyUpCallback(() => {
                counters[index]++;
            }, incr);

            return index;
        }

        /* Used to access a specific counter (given index) 
         * and a list size to correctly adjust the value to 
         * fit the scale of 'mod'
         */
        public int GetCountDeltaKey(int index, int mod) {
            if (index < 0 || index >= counters.Count) {
                throw new IndexOutOfRangeException("The index was not in range");
            }

            int ret = counters[index] % mod;

            return ret < 0 ? ret + mod : ret;
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
        public void Update() {
            InputKeyboard.Instance.Update();
        }

    }
}
