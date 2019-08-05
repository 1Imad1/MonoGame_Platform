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
        public int FullHealth;
        public int CurrentHealth;
        public Rectangle healthbarRect;

        public int RateOfChange = 1;

        public HealthBar(ContentManager content)
        {
            LoadContent(content);
            FullHealth = Lifebar.Width;
            CurrentHealth = FullHealth;
            healthbarRect = new Rectangle((int)Position.X, (int)Position.Y, CurrentHealth, Lifebar.Height);

        }

        private void LoadContent(ContentManager content)
        {
            Lifebar = content.Load<Texture2D>("health");
            Container = content.Load<Texture2D>("containerHeatlhBar");
        }

        public void Update(Vector2 PlayerPosition)
        {
            Position = PlayerPosition;

            Debug.WriteLine("curr: " + CurrentHealth);
            Debug.WriteLine("recthealth: " + healthbarRect);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Lifebar, Position, healthbarRect, Color.White);
            spriteBatch.Draw(Container, Position, Color.White);
        }
    }
}
