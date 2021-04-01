using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon;

namespace Sprintfinity3902.Interfaces
{
    public interface IDungeon
    {
        public enum GameState
        {
            NULL,
            WIN,
            LOSE,
            RETURN
        }

        public IRoom CurrentRoom { get; set; }
        public int NextId { get; set; }
        public ChangeRoom changeRoom { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Initialize();
        void NextRoom();
        void PreviousRoom();
        IRoom GetCurrentRoom();
        IRoom GetById(int id);
        void SetCurrentRoom(int id);
        void ChangeRoom(IDoor door);
        void UpdateState(GameState state);
    }
}
