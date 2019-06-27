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
    public class Player
    {
        private Vector2 position;
        private Texture2D texture;
        public Rectangle rectangle;

        public Vector2 velocity;
        private bool hasJumped = false;

        Animation _animation;

        public Vector2 Position
        {
            get { return position; }
        }


        //public void load(ContentManager content)
        //{
        //    texture = content.Load<Texture2D>("player1");
        //}

        public Player(ContentManager content)
        {
            position = new Vector2(64, 384);
            texture = content.Load<Texture2D>("player1");
            velocity = Vector2.Zero;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            Input(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = 5;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            }
            else
            {
                velocity.X = 0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.IsTouchingLeftOf(newrect))
            {
                position.X = newrect.X - rectangle.Width - 2;
            }
            if (rectangle.IsTouchingRightOf(newrect))
            {
                position.X = newrect.X + rectangle.Width + 10;
            }
            if (rectangle.IsTouchingBottom(newrect))
            {
                velocity.Y = 0.8f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }

        public void ColideBetweenPlayers(Rectangle enemy, Rectangle player)
        {
            if (player.Intersects(enemy))
            {
                if (player.IsTouchingLeftOf(enemy))
                {
                    position.X = enemy.X - rectangle.Width - 2;
                    Debug.WriteLine("hit left of enemy");
                }
                else if (player.IsTouchingRightOf(enemy))
                {
                    position.X = enemy.X + rectangle.Width + 2;
                    Debug.WriteLine("hit right of enemy");
                }
                else if (player.IsTouchingTopOf(enemy))
                {
                    rectangle.Y = enemy.Y - rectangle.Height;
                    velocity.Y = 0f;
                    hasJumped = false;
                    Debug.WriteLine("hit top of enemy");
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
