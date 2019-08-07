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

        public Rectangle BoxRoundBullet;

        public Shooter()
        {
            Bullets = new List<Vector2>();
        }

        public void load(ContentManager content)
        {
            bulletImage = content.Load<Texture2D>("fireBall");
        }

        public void Update(GameTime gameTime, Vector2 pos, Input key)
        {

            BoxRoundBullet = new Rectangle((int)pos.X + 5, (int)pos.Y + 20, 59, 13);
            if (key.NormalAttack)
            {
                Bullets.Add(new Vector2(pos.X + 5, pos.Y + 20));
            }

            for (int i = 0; i < Bullets.Count; i++)
            {
                float x = Bullets[i].X;

                x += BulletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Bullets[i] = new Vector2(x + 2, Bullets[i].Y);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Bullets.Count; i++)
                spriteBatch.Draw(bulletImage, Bullets[i], Color.White);
        }
    }
}
