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
        private Texture2D texture;
        public Rectangle rectangle;
        private Vector2 velocity;

        private Vector2 position = new Vector2(220, 75);
        public Vector2 Position
        {
            get { return position; }
        }

        public Enemy()
        {
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);


            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = 0f;
            }

            if (rectangle.IsTouchingLeftOf(newrect))
            {
                position.X = newrect.X - rectangle.Width - 2;
            }
            if (rectangle.IsTouchingRightOf(newrect))
            {
                position.X = newrect.X + rectangle.Width + 10;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }

        public void load(ContentManager content)
        {
            texture = content.Load<Texture2D>("enemy1");
        }
    }
}
