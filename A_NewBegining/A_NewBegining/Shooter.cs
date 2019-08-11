using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace A_NewBegining
{
    class Shooter
    {
        public Input Controls = new Input();

        public List<Vector2> Bullets;
        public Texture2D bulletImage;
        public float BulletSpeed = 200f;
        public Vector2 position;
        public Rectangle rectangle;
        public Vector2 velocity;

        public Shooter()
        { 
            Bullets = new List<Vector2>();
        }

        public void load(ContentManager content)
        {
            bulletImage = content.Load<Texture2D>("fireBall");
        }

        public void Update(GameTime gameTime, Input key,Vector2 position)        
        {
            this.position = position;

            position += velocity;
            if (key.NormalAttack)
            {
                Bullets.Add(new Vector2(position.X + 50, position.Y + 13));
            }

            for (int i = 0; i < Bullets.Count; i++)
            {
                float x = Bullets[i].X;

                x += BulletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Bullets[i] = new Vector2(x + 2, Bullets[i].Y);
            }

            if (velocity.Y > 10)
                velocity.Y += 0.4f;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Bullets.Count; i++)
                spriteBatch.Draw(bulletImage, Bullets[i], Color.White);
        }

        public void Collision(Rectangle enemy)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 59, 13);

            if (rectangle.Intersects(enemy))
            {
                    for (int i = 0; i < Bullets.Count; ++i)
                    {
                        if (rectangle.IsTouchingLeftOf(enemy)) //determine if the sprite collided here
                        {
                            Bullets.RemoveAt(i);
                            --i;
                        }
                    }
            }
        }
    }
}
