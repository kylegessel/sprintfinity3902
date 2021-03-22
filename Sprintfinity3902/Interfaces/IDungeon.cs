using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface IDungeon
    {
        public IRoom CurrentRoom { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Build();
        void NextRoom();
        void PreviousRoom();
        IRoom GetCurrentRoom();
        void SetCurrentRoom(int id);
        void CleanUp();
        public void GameStateUpdate(bool didWin);
    }
}
