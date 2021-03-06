﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Dungeon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IRoom
    {
        int Id { get; set; }
        //List<IEntity> roomEntities { get; set; }
        List<IEntity> blocks { get; set; }
        List<IEntity> items { get; set; }
        List <IEntity> enemies { get; set; }
        string path { get; set; }
        RoomLoader loader { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void ChangePosition(bool pause);
        void SetPauseCount();
    }
}