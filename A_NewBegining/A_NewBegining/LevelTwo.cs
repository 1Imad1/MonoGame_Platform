using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace A_NewBegining
{
    class LevelTwo : Level
    {

        public bool IsCurrentLevel = false;
        public bool IsNotCurrentLevel = true;

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }
    }
}
