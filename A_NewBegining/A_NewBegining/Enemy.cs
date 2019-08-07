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
    public class Enemy
    {
        #region Variabelen
        public Rectangle rectangle;
        private Vector2 velocity;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        Animation animation;

        bool right = false;
        public float distance;
        float oldDistance;
        Vector2 origin;

        #endregion

        public Enemy(float newDIS, Vector2 pos)
        {
            position = pos;

            animation = new Animation(position, velocity);

            animation.AddAnimatie(10, 0, 0, "Idle", 20, 33, new Vector2(0, 0));
            animation.AddAnimatie(13, 40, 0, "WalkRight", 22, 34, new Vector2(0, 0));
            animation.AddAnimatie(13, 75, 0, "WalkLeft", 22, 34, new Vector2(0, 0));
            animation.AnimatieAfspelen("WalkRight");

            animation.FramesPerSec = 10;


            distance = newDIS;
            oldDistance = distance;
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Skeletonsheet"); 
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            animation.Update(gameTime);
            origin = new Vector2(25 / 2, 22 / 2);


            if (distance <= 0)
            {
                right = true;
                animation.AnimatieAfspelen("WalkRight");
                velocity.X = 1f;
            }
            else if (distance >= oldDistance)
            {
                right = false;
                animation.AnimatieAfspelen("WalkLeft");
                velocity.X = -1f;
            }

            if (right == true) distance += 1; else distance -= 1;

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);

        }

        public void Collision(Rectangle newrect, int xOffset, int yOffset)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 28, 33);

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
                position.X = newrect.X + rectangle.Width + 2;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.X = yOffset - rectangle.Height;

        }
    }
}
