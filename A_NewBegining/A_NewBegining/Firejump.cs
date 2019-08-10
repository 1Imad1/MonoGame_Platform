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


            animation.AnimatieAfspelen("Jump");

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {

            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = -velocity.Y - 2;

            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }


        //public Vector2 position;
        //public Vector2 velocity;
        //public Texture2D texture;

        //public bool isVisible = true;
        //Random random = new Random();
        //int randX, randY;

        //float spawn = 0;

        //public Firejump(Texture2D newTexture, Vector2 newPosition)
        //{
        //    position = newPosition;
        //    texture = newTexture;

        //    randY = random.Next(-4, 4);
        //    randX = random.Next(-4, -1);

        //    velocity = new Vector2(randX, randY);

        //}

        //public void Update(GraphicsDevice graphicsDevice)
        //{
        //    position += velocity;

        //    if (position.Y <= 0 || position.Y >= graphicsDevice.Viewport.Height - texture.Height)
        //        velocity.Y = -velocity.Y;

        //    if (position.X < 0 - texture.Width)
        //        isVisible = false;
        //}

        //public void Draw(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(texture, position, Color.White);
        //}

        //public void Loadfire()
    }
}
