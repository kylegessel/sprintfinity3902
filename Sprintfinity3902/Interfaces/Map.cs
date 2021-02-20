using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces {
    public interface Map : IDrawable, IUpdateable {
        public void Setup();
    }
}
