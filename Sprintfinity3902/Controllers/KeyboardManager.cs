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

        private static List<Keys> MOVEMENT_KEYS = new List<Keys>() {
            Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right
        };

        private static Dictionary<Keys, Interfaces.ICommand> controllerMappings;
        private static Dictionary<Keys, List<Action>> keyUpHandlers;

        private static List<int> counters;

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

        public void Reset() {
            counters = new List<int>();
            keyUpHandlers = new Dictionary<Keys, List<Action>>();
            controllerMappings = new Dictionary<Keys, Interfaces.ICommand>();
        }

        public void CallHandlers(Keys key) {
            if (keyUpHandlers.ContainsKey(key)) {
                foreach (Action handler in keyUpHandlers[key]) {
                    handler();
                }
            }
        }

        public void CallCommands(List<Keys> keys) {
            bool playerHasMoved = false;
            foreach (Keys key in keys) {

                if (MOVEMENT_KEYS.Contains(key)) {
                    if (playerHasMoved) {
                        continue;
                    } else {
                        playerHasMoved = true;
                    }
                }

                controllerMappings[key].Execute();

            }
        }

        public void Initialize(Player player) {
            foreach (Keys key in Enum.GetValues(typeof(Keys))) {
                RegisterCommand(new DoNothingCommand(), key);
            }

            RegisterCommand(new SetPlayerMoveUpCommand((Player)player), Keys.W, Keys.Up);
            RegisterCommand(new SetPlayerMoveLeftCommand((Player)player), Keys.A, Keys.Left);
            RegisterCommand(new SetPlayerMoveDownCommand((Player)player), Keys.S, Keys.Down);
            RegisterCommand(new SetPlayerMoveRightCommand((Player)player), Keys.D, Keys.Right);
            
            RegisterKeyUpCallback(() => {
                ((Player)player).CurrentState.Sprite.Animation.Stop();
            },
            Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.E);
        }

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

        public int GetCountDeltaKey(int index, int mod) {
            if (index < 0 || index >= counters.Count) {
                throw new IndexOutOfRangeException("The index was not in range");
            }

            int ret = counters[index] % mod;

            return ret < 0 ? ret + mod : ret;
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

        private void addCallback(Keys key, Action callback) {
            if (!keyUpHandlers.ContainsKey(key)) {
                keyUpHandlers[key] = new List<Action>();
            }
            keyUpHandlers[key].Add(callback);
        }

        public void RegisterKeyUpCallback(Action callback, params Keys[] keys) {
            foreach (Keys key in keys) {
                addCallback(key, callback);
            }
        }

        public void UnregisterListeners() {
            keyUpHandlers.Clear();
        }

        public void UnregisterCommands() {
            controllerMappings.Clear();
        }

        public void Update() {
            InputKeyboard.Instance.Update();
        }

    }
}
