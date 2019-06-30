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

        private Input Key = new Input();
        public bool LinkseStand = false;

        Animation animation;

        public Player()
        {
            position = new Vector2(0, 0);
            velocity = Vector2.Zero;

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

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("char");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            //animatie update
            animation.Update(gameTime);

            Key.update();
            Movement(gameTime);

            

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
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
                }

                if (player.IsTouchingTopOf(enemy))
                {
                    rectangle.Y = enemy.Y - rectangle.Height;
                    velocity.Y = 0f;
                    hasJumped = false;
                }
            }
        }








        //public Rectangle rectangle;

        //public Vector2 velocity;
        //private bool hasJumped = false;

        //public float speed = 2.5f;

        //private Vector2 position;
        //public Vector2 Position
        //{
        //    get { return position; }
        //}

        //private Texture2D texture;
        //public Texture2D Texture
        //{
        //    get { return texture; }
        //}

        //private Input Key = new Input();
        //public bool LinkseStand = false;


        //protected string currentAnimatie;
        //private int FrameIndex;
        //private double TimeElapse;
        //private double TimeToUpdate;

        //public int FramesPerSec
        //{
        //    set { TimeToUpdate = (1f / value); }
        //}

        //public Player()
        //{
        //    position = new Vector2(0, 30);

        //    velocity = Vector2.Zero;

        //    //hierin animatie adden
        //    AddAnimatie(4, 0, 0, "RechteIdle", 50, 35, new Vector2(0, 0));
        //    AddAnimatie(4, 34, 0, "LinkseIdle", 50, 35, new Vector2(0, 0));
        //    AddAnimatie(6, 72, 0, "Right", 50, 34, new Vector2(0, 0));
        //    AddAnimatie(6, 107, 0, "Left", 50, 40, new Vector2(0, 0));
        //    AddAnimatie(4, 180, 0, "RightSlide", 50, 32, new Vector2(0, 0));
        //    AddAnimatie(4, 180, 4, "LeftSlide", 50, 32, new Vector2(0, 0));
        //    AddAnimatie(7, 255, 0, "FirstAttack", 50, 45, new Vector2(0, 0));
        //    AddAnimatie(14, 300, 0, "ComboAttack", 50, 41, new Vector2(0, 0));
        //    AddAnimatie(5, 300, 0, "Dood", 50, 41, new Vector2(0, 0));
        //    AddAnimatie(9, 144, 0, "Jump", 46, 41, new Vector2(0, 0));

        //    FramesPerSec = 10;
        //}

        //private Dictionary<string, Rectangle[]> sAnimatie = new Dictionary<string, Rectangle[]>();


        //public void Update(GameTime gameTime)
        //{

        //    position += velocity;

        //    //animatie update
        //    TimeElapse += gameTime.ElapsedGameTime.TotalSeconds;

        //    if (TimeElapse > TimeToUpdate)
        //    {
        //        TimeElapse -= TimeToUpdate;

        //        if (FrameIndex < sAnimatie[currentAnimatie].Length - 1)
        //        {
        //            FrameIndex++;
        //        }
        //        else
        //        {
        //            FrameIndex = 0;
        //        }
        //        TimeElapse = 0;
        //    }

        //    Key.update();
        //    Movement(gameTime);

        //    if (velocity.Y < 10)
        //        velocity.Y += 0.4f;
        //}

        //public void Movement(GameTime gameTime)
        //{
        //    //animatie afspelen in de input
        //    if (Key.Right)
        //    {
        //        AnimatieAfspelen("Right");
        //        velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

        //        LinkseStand = false;
        //    }
        //    else if (Key.Left)
        //    {
        //        AnimatieAfspelen("Left");
        //        velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

        //        LinkseStand = true;
        //    }
        //    else if (Key.Down && LinkseStand == false)
        //    {
        //        AnimatieAfspelen("RightSlide");
        //    }
        //    else if ((Key.Down && LinkseStand == true))
        //    {
        //        AnimatieAfspelen("LeftSlide");
        //    }
        //    else if (Key.NormalAttack)
        //    {
        //        AnimatieAfspelen("FirstAttack");
        //    }
        //    else if (Key.ComboAttack)
        //    {
        //        AnimatieAfspelen("ComboAttack");
        //    }
        //    else
        //    {
        //        if (LinkseStand == true)
        //            AnimatieAfspelen("LinkseIdle");
        //        else
        //            AnimatieAfspelen("RechteIdle");
        //        velocity.X = 0f;
        //    }


        //    if (Key.up && hasJumped == false)
        //    {
        //        position.Y -= 5f;
        //        velocity.Y = -9f;
        //        hasJumped = true;

        //    }
        //}

        //public void AddAnimatie(int frames, double yPos, int xStart, string naam, int width, int height, Vector2 offset)
        //{

        //    Rectangle[] Rectangles = new Rectangle[frames];

        //    ///neemt de spritesheet en het verdeelt zich
        //    for (int i = 0; i < frames; i++)
        //    {
        //        Rectangles[i] = new Rectangle((i + xStart) * width, (int)yPos, width, height);
        //    }

        //    sAnimatie.Add(naam, Rectangles);
        //}

        //public void Draw(SpriteBatch sprite)
        //{
        //    sprite.Draw(texture, position, sAnimatie[currentAnimatie][FrameIndex], Color.White);
        //}

        //public void AnimatieAfspelen(string animatieNaam)
        //{
        //    if (currentAnimatie != animatieNaam)
        //    {
        //        currentAnimatie = animatieNaam;
        //        FrameIndex = 0;
        //    }
        //}

        //public void LaadContent(ContentManager content)
        //{
        //    texture = content.Load<Texture2D>("char");
        //}

        //public void Collision(Rectangle newrect, int xOffset, int yOffset)
        //{
        //    rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 35/*texture.Width, texture.Height)*/);

        //    if (rectangle.IsTouchingTopOf(newrect))
        //    {
        //        rectangle.Y = newrect.Y - rectangle.Height;
        //        velocity.Y = 0;
        //        hasJumped = false;
        //    }

        //    if (rectangle.IsTouchingLeftOf(newrect))
        //    {
        //        position.X = newrect.X - rectangle.Width - 2;
        //    }
        //    if (rectangle.IsTouchingRightOf(newrect))
        //    {
        //        position.X = newrect.X + rectangle.Width + 15;
        //    }
        //    if (rectangle.IsTouchingBottom(newrect))
        //    {
        //        velocity.Y = 1f;
        //    }

        //    if (position.X < 0) position.X = 0;
        //    if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
        //    if (position.Y < 0) velocity.Y = 1f;
        //    if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;
        //}

        //public void ColideBetweenPlayers(Rectangle enemy, Rectangle player)
        //{
        //    if (player.Intersects(enemy))
        //    {
        //        if (player.IsTouchingLeftOf(enemy))
        //        {
        //            position.X = enemy.X - rectangle.Width - 2;
        //            Debug.WriteLine("hit left of enemy");
        //        }
        //        else if (player.IsTouchingRightOf(enemy))
        //        {
        //            position.X = enemy.X + rectangle.Width + 2;
        //            Debug.WriteLine("hit right of enemy");
        //        }

        //        if (player.IsTouchingTopOf(enemy))
        //        {
        //            rectangle.Y = enemy.Y - rectangle.Height;
        //            velocity.Y = 0f;
        //            hasJumped = false;
        //            Debug.WriteLine("hit top of enemy");
        //        }
        //    }
        //}
    }
}