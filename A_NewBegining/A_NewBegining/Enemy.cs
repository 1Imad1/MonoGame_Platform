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

        Animation animation;
        public float distance;
        public HealthBar healthBar;

        float oldDistance;
        Vector2 origin;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle rectangle;
        bool right = false;

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        private Vector2 velocity;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDIS"> How far he goes right and left (patrolling) </param>
        public Enemy(float newDIS, Vector2 pos)
        {
            position = pos;

            healthBar = new HealthBar();

            animation = new Animation(position, velocity);

            animation.AddAnimatie(10, 0, 0, "Idle", 20, 33, new Vector2(0, 0));
            animation.AddAnimatie(13, 40, 0, "WalkRight", 22, 34, new Vector2(0, 0));
            animation.AddAnimatie(13, 75, 0, "WalkLeft", 22, 34, new Vector2(0, 0));

            animation.FramesPerSec = 10;

            distance = newDIS;
            oldDistance = distance;
        }

        public void LaadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Skeletonsheet");

            healthBar.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            animation.Update(gameTime);
            origin = new Vector2(25 / 2, 22 / 2);


            if (distance <= 0)
            {
                right = true;
                animation.Afspelen("WalkRight");

                velocity.X = 1f;
            }
            else if (distance >= oldDistance)
            {
                right = false;
                animation.Afspelen("WalkLeft");
                velocity.X = -1f;
            }

            if (right == true) distance += 1; else distance -= 1;

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            healthBar.Update(position);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.RectanglesAnimaties[animation.currentAnimatie][animation.frameIndex], Color.White);

            healthBar.Draw(spriteBatch);
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

        //Loses health if the enemy collides with the player
        public void ColideWithPlayer(Rectangle enemy, Rectangle player, Input key)
        {
            if (enemy.Intersects(player))
            {
                if (enemy.IsTouchingLeftOf(player) && key.NormalAttack)
                {
                    healthBar.CurrentHealth -= 5;
                }

                if (enemy.IsTouchingRightOf(player) && key.NormalAttack)
                {
                    healthBar.CurrentHealth -= 5;
                }
            }
        }
    }
}