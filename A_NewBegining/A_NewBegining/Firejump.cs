using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace A_NewBegining
{
    public class Firejump
    {
        public Rectangle rectangle;
        public Vector2 position;
        public Texture2D texture;
        public Vector2 velocity;

        Animation animation;

        public Firejump(Vector2 pos)
        {
            position = pos;

            animation = new Animation(position, velocity);
            animation.AddAnimatie(54, 0, 0, "Jump", 14, 45, new Vector2(0, 0));
            animation.Afspelen("Jump");
            animation.FramesPerSec = 70;

        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Jumping_Small_Fireball_14x45");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            animation.Update(gameTime);
            rectangle = new Rectangle((int)position.X, (int)position.Y, 14, 39);

            if (velocity.Y < 10)
                velocity.Y += 0.8f;
        }

        /// <summary>
        /// Collision With tiles if it hits top of the tile then it bounce back
        /// </summary>
        /// <param name="newrect">Tile rectangle</param>
        /// <param name="xOffset">Map width</param>
        /// <param name="yOffset">Map height</param>
        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = -velocity.Y - 15;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;
        }
    }
}