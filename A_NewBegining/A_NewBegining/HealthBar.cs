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
    public class HealthBar
    {
        public Texture2D Container, Lifebar;
        public Vector2 Position;
        private int fullHealth;
        private int currentHealth;
        public Rectangle healthbarRect;
                
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public int FullHealth
        {
            get { return fullHealth; }
            set { fullHealth = value; }
        }

        public void LoadContent(ContentManager content)
        {
            Lifebar = content.Load<Texture2D>("health");
            Container = content.Load<Texture2D>("containerHeatlhBar");

            FullHealth = Lifebar.Width;
            currentHealth = FullHealth;
        }

        public void Update(Vector2 PlayerPosition)
        {
            Position = PlayerPosition;

            healthbarRect = new Rectangle((int)PlayerPosition.X, (int)PlayerPosition.Y - 5, CurrentHealth, Lifebar.Height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Lifebar, healthbarRect, Color.White);
            spriteBatch.Draw(Container, new Vector2(Position.X, Position.Y - 5), Color.White);
        }
    }
}
