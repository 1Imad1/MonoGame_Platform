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
    public class Coin
    {
        Animation animation;
        public Vector2 position;
        public Rectangle rectangle;
        public Texture2D texture;
        public Vector2 velocity;
        
        public Coin(Vector2 pos)
        {
            position = pos;
            animation = new Animation(position, velocity);

            animation.AddAnimatie(4, 0, 0, "Coin", 15, 16, new Vector2(0, 0));
            animation.Afspelen("Coin");
            animation.FramesPerSec = 10;
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("goldCoin");            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);           
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
            rectangle = new Rectangle((int)position.X, (int)position.Y, 15, 16);

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