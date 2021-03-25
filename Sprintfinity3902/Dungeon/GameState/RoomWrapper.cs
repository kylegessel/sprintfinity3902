using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Dungeon.GameState
{
    public abstract class RoomWrapper : IRoom
    {
        public int Id {
            get {
                return CurrentState.Id;
            }

            set {
                CurrentState.Id = value;
            }
        }

        public List<IBlock> blocks {
            get {
                return CurrentState.blocks;
            }

            set {
                CurrentState.blocks = value;
            }
        }

        public Dictionary<int, IEntity> enemies {
            get {
                return CurrentState.enemies;
            }

            set {
                CurrentState.enemies = value;
            }
        }
        public List<IEntity> items {
            get {
                return CurrentState.items;
            }

            set {
                CurrentState.items = value;
            }
        }

        public List<IEntity> enemyProj {
            get {
                return CurrentState.enemyProj;
            }

            set {
                CurrentState.enemyProj = value;
            }
        }

        public List<IEntity> garbage {
            get {
                return CurrentState.garbage;
            }

            set {
                CurrentState.garbage = value;
            }
        }
        //projectiles may have to be added here later.

        public string path {
            get {
                return CurrentState.path;
            }

            set {
                CurrentState.path = value;
            }
        }
        
        public bool Pause {
            get {
                return CurrentState.Pause;
            }

            set {
                CurrentState.Pause = value;
            }
        }
        public float startY {
            get {
                return CurrentState.startY;
            }

            set {
                CurrentState.startY = value;
            }
        }
        public int count {
            get {
                return CurrentState.count;
            }

            set {
                CurrentState.count = value;
            }
        }

        public string music_id {
            get;
            protected set;
        }

        public IDungeon dungeon { get; protected set;}

        protected IRoom CurrentState;
        
        public RoomWrapper(IRoom currentRoom) {
            CurrentState = currentRoom;
        }

        public virtual void ChangePosition(bool pause)
        {
            CurrentState.ChangePosition(pause);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            CurrentState.Draw(spriteBatch, color);
        }

        public virtual void SetPauseCount()
        {
            CurrentState.SetPauseCount();
        }

        public virtual void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
        }

        public virtual void Wrapup()
        {
            SoundManager.Instance.DestroySoundEffectInstance(music_id);
            SoundManager.Instance.PlayAll();
            CollisionDetector.Instance.Pause();
            dungeon.CurrentRoom = CurrentState;
            dungeon.GameStateUpdate(IDungeon.GameState.RETURN);
        }
    }
}
