using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon;
using System.Collections.Generic;

namespace Sprintfinity3902.Interfaces
{
    public interface IRoom
    {
        int Id { get; set; }
        //List<IEntity> roomEntities { get; set; }
        List<IBlock> blocks { get; set; }
        List<IEntity> items { get; set; }
        Dictionary <int, IEntity> enemies { get; set; }
        string path { get; set; }
        RoomLoader loader { get; set; }
        Room13Loader loader13 { get; set; }
        List<IEntity> garbage { get; set; }

        List<IEntity> enemyProj { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void ChangePosition(bool pause);
        void SetPauseCount();
        void DamageGoryia(int enemyID);
    }
}
