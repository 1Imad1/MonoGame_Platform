using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    public class Enemy
    {
        public Rectangle rectangle;
        private Vector2 velocity;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        Animation animation;

        public Enemy()
        {
            position = new Vector2(220, 0);

            animation = new Animation(position, velocity);

            animation.AddAnimatie(13, 0, 0, "Walk", 22, 34, new Vector2(0, 0));
            animation.AnimatieAfspelen("Walk");

            animation.FramesPerSec = 10;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("enemy1");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            animation.Update(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 22, 34);
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = 0f;
            }

            if (rectangle.IsTouchingLeftOf(newrect))
            {
                position.X = newrect.X - rectangle.Width - 1;
            }
            if (rectangle.IsTouchingRightOf(newrect))
            {
                position.X = newrect.X + rectangle.Width + 2;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }
    }
}
