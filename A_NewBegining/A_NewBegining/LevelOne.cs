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
    class LevelOne : Level
    {
        public bool IsCurrentLevel = true;
        public bool IsNotCurrentLevel = false;

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            base.Draw(spriteBatch);


            spriteBatch.End();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);                     
        }
    }
}
