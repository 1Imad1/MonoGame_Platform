﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace A_NewBegining
{
    /// <summary>
    /// Is used in de states classes to make a list of buttons (components) on screen so you can use it
    /// </summary>
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
