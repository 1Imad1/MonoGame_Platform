using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    class Portal
    {

        public Texture2D gate;
        public Rectangle rectangle;
        public Vector2 position;
        public Vector2 velocity;

        Animation animation;

        public Portal()
        {
            position = new Vector2(1360, 0);
            animation = new Animation(position, velocity);
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 20);

            animation.AddAnimatie(8, 0, 0, "Portal", 64, 56, new Vector2(0, 0));

            animation.AnimatieAfspelen("Portal");
            animation.FramesPerSec = 10;
        }

        public void LoadContent(ContentManager content)
        {
            gate = content.Load<Texture2D>("Tile4");

        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gate, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);
        }

        public  void Unload()
        {
            rectangle = new Rectangle(0, 0, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            animation.Update(gameTime);
        }
    }
}
