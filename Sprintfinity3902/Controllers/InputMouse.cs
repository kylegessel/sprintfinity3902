﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;

namespace Ardrey.Sprint0
{
    public class InputMouse : IController
    {
        private Game1 myGame;

        public InputMouse(Game1 game)
        {
            myGame = game;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {

        }

    }
}
