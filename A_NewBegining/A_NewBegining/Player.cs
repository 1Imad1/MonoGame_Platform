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
        public Rectangle rectangle;

        public Vector2 velocity;
        private bool hasJumped = false;

        public float speed = 2.5f;

        public Vector2 position;
        //public Vector2 Position
        //{
        //    get { return position; }
        //    set { value = position; }
        //}

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        public Input Key; 
        public bool LinkseStand = false;

        Animation animation;

        public HealthBar healthBar;

        public int Health
        {
            get { return healthBar.CurrentHealth; }
            set { healthBar.CurrentHealth = value; }
        }

        public Player()
        {
            position = new Vector2(0, 0);
            velocity = Vector2.Zero;
            Key = new Input();

            healthBar = new HealthBar();

            //hierin animatie adden
            animation = new Animation(position, velocity);

            animation.AddAnimatie(4, 2, 0, "RechteIdle", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(4, 68, 0, "LinkseIdle", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(6, 133, 0, "Right", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(6, 205, 0, "Left", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(3, 340, 0, "RightFistAttack", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(3, 410, 0, "LeftFistAttack", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(3, 481, 0, "Kick", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(4, 618, 0, "RightGunAttack", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(4, 686, 0, "LeftGunAttack", 64, 64, new Vector2(0, 0));
            animation.AddAnimatie(4, 686, 0, "Jump", 64, 64, new Vector2(0, 0));

            animation.AnimatieAfspelen("RechterIdle");

            animation.FramesPerSec = 8;
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Player1");

            healthBar.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White/*, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f*/);
            
            healthBar.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            //animatie update
            animation.Update(gameTime);

            Key.update();
            Movement(gameTime);

            Debug.WriteLine("player pos x = " + position.X);
            Debug.WriteLine("player pos y = " + position.Y);

            if (velocity.Y < 11)
                velocity.Y += 0.4f;
            healthBar.Update(position);
        }

        public void Movement(GameTime gameTime)
        {
            //animatie afspelen in de input
            if (Key.Right)
            {
                animation.AnimatieAfspelen("Right");
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                LinkseStand = false;
            }
            else if (Key.Left)
            {
                animation.AnimatieAfspelen("Left");
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                LinkseStand = true;
            }
            else if (Key.NormalAttack && LinkseStand == false)
            {
                animation.AnimatieAfspelen("RightGunAttack");
            }
            else if (Key.NormalAttack && LinkseStand == true)
            {
                animation.AnimatieAfspelen("LeftGunAttack");
            }
            else if (Key.ComboAttack && LinkseStand == false)
            {
                animation.AnimatieAfspelen("RightFistAttack");
                Key.Right = false;
            }
            else if (Key.ComboAttack && LinkseStand == true)
            {
                animation.AnimatieAfspelen("LeftFistAttack");
            }
            else
            {
                if (LinkseStand == true)
                {
                    animation.AnimatieAfspelen("LinkseIdle");
                }
                else                    
                    animation.AnimatieAfspelen("RechteIdle");

                velocity.X = 0f;
            }

            if (Key.up && hasJumped == false)
            {
                //animation.AnimatieAfspelen("Jump");
                position.Y -= 2f;
                velocity.Y = -9f;
                hasJumped = true;

            }
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 54, 60);
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
                position.X = newrect.X + rectangle.Width + 12;
            }
            if (rectangle.IsTouchingBottom(newrect))
            {
               // rectangle.Y = newrect.Y - rectangle.Height - 150;
                velocity.Y = 5f;
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
                    healthBar.CurrentHealth--;
                }

                if (player.IsTouchingRightOf(enemy))
                {
                    position.X = enemy.X + rectangle.Width - 25;
                    healthBar.CurrentHealth--;
                }

                if (player.IsTouchingTopOf(enemy))
                {
                    rectangle.Y = enemy.Y - rectangle.Height;
                    velocity.Y = 0f;
                    hasJumped = false;

                    healthBar.CurrentHealth--;
                }
            }
        }
    }
}