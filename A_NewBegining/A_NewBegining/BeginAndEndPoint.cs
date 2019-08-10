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
    class BeginAndEndPoint
    {
        public Rectangle rectangle;
        public Vector2 position;
        public Texture2D texture;
        public Vector2 velocity;

        public Texture2D startTexture;
        public Vector2 StartPositie;

        public BeginAndEndPoint(Vector2 EndPosition, Vector2 startPosition)
        {
            position = EndPosition;
            StartPositie = startPosition;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Next");
            startTexture = content.Load<Texture2D>("Begin");
        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(startTexture, StartPositie, Color.White);
        }

        public  void Unload()
        {
            rectangle = new Rectangle(0, 0, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 63, 65);


            if (velocity.Y < 10)
                velocity.Y += 0.2f;
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = 0f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }
    }
}
