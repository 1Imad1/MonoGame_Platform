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

        private Input Key = new Input();
        public bool LinkseStand = false;

        Animation animation;
        private HealthBar HealthBar;

        public List<Vector2> Bullets;
        public Texture2D bulletImage;
        public float BulletSpeed = 400f;

        public Player()
        {
            position = new Vector2(0, 0);
            velocity = Vector2.Zero;
            Bullets = new List<Vector2>();

            //hierin animatie adden
            animation = new Animation(position, velocity);

            animation.AddAnimatie(4, 0, 0, "RechteIdle", 50, 35, new Vector2(0, 0));
            animation.AddAnimatie(4, 34, 0, "LinkseIdle", 50, 35, new Vector2(0, 0));
            animation.AddAnimatie(6, 72, 0, "Right", 50, 34, new Vector2(0, 0));
            animation.AddAnimatie(6, 107.9, 0, "Left", 50, 40, new Vector2(0, 0));
            animation.AddAnimatie(4, 180, 0, "RightSlide", 50, 32, new Vector2(0, 0));
            animation.AddAnimatie(4, 180, 4, "LeftSlide", 50, 32, new Vector2(0, 0));
            animation.AddAnimatie(7, 255, 0, "FirstAttack", 50, 45, new Vector2(0, 0));
            animation.AddAnimatie(14, 300, 0, "ComboAttack", 50, 41, new Vector2(0, 0));
            animation.AddAnimatie(5, 300, 0, "Dood", 50, 41, new Vector2(0, 0));
            animation.AddAnimatie(9, 144, 0, "Jump", 46, 41, new Vector2(0, 0));

            animation.FramesPerSec = 10;
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("char");
            bulletImage = content.Load<Texture2D>("SuperSlash");
            HealthBar = new HealthBar(content);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            HealthBar.Draw(sprite);

            for (int i = 0; i < Bullets.Count; i++)
                sprite.Draw(bulletImage, Bullets[i], Color.White);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            //animatie update
            animation.Update(gameTime);

            Key.update();
            Movement(gameTime);

            Debug.WriteLine("position x = " + position.X);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            HealthBar.Update(position);


            if(Key.NormalAttack)
                Bullets.Add(position);

            for (int i = 0; i < Bullets.Count; i++)
            {
                float x = Bullets[i].X + 1;

                x += BulletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Bullets[i] = new Vector2(x, Bullets[i].Y);
            }
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
            else if (Key.Down && LinkseStand == false)
            {
                animation.AnimatieAfspelen("RightSlide");
            }
            else if ((Key.Down && LinkseStand == true))
            {
                animation.AnimatieAfspelen("LeftSlide");
            }
            else if (Key.NormalAttack)
            {
                animation.AnimatieAfspelen("FirstAttack");
            }
            else if (Key.ComboAttack)
            {
                animation.AnimatieAfspelen("ComboAttack");
            }
            else
            {
                if (LinkseStand == true)
                    animation.AnimatieAfspelen("LinkseIdle");
                else
                    animation.AnimatieAfspelen("RechteIdle");
                velocity.X = 0f;
            }


            if (Key.up && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;

            }
        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 38, 50);
            if (rectangle.IsTouchingTopOf(newrect))
            {
                rectangle.Y = newrect.Y - rectangle.Height;
                velocity.Y = 0;
                hasJumped = false;
            }

            if (rectangle.IsTouchingLeftOf(newrect))
            {
                position.X = newrect.X - rectangle.Width - 16;
            }
            if (rectangle.IsTouchingRightOf(newrect))
            {
                position.X = newrect.X + rectangle.Width + 2 ;
            }
            if (rectangle.IsTouchingBottom(newrect))
            {
                //rectangle.Y = rectangle.Y + rectangle.Height;
                velocity.Y = 1f;
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
                if (player.Right <= enemy.Right &&
                    player.Right >= enemy.Left + 2 &&
                    player.Top <= enemy.Bottom - (enemy.Width / 4) &&
                    player.Bottom >= enemy.Top + (enemy.Width / 4))
                {
                    position.X = enemy.X - rectangle.Width - 2;
                }

                if (player.Left >= enemy.Left &&
                    player.Left <= enemy.Right - 20 &&
                    player.Top <= enemy.Bottom - (enemy.Width / 4) &&
                    player.Bottom >= enemy.Top + (enemy.Width / 4))
                {
                    position.X = enemy.X + rectangle.Width - 26;
                    HealthBar.CurrentHealth--;
                }

                if (player.IsTouchingTopOf(enemy))
                {
                    rectangle.Y = enemy.Y - rectangle.Height;
                    velocity.Y = 0f;
                    hasJumped = false;
                }
            }
        }
    }
}