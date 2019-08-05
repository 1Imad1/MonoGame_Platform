using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{

    public class Animation
    {
        public Vector2 position;
        public Texture2D texture;

        public Vector2 velocity = Vector2.Zero;

        public string currentAnimatie;
        public int frameIndex;
        public double timeElapse;
        public double timeToUpdate;

        public int FramesPerSec
        {
            set { timeToUpdate = (1f / value); }
        }

        public Animation(Vector2 position, Vector2 velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }

        public Dictionary<string, Rectangle[]> RectanglesAnimaties = new Dictionary<string, Rectangle[]>();
        
        public void Update(GameTime gametime)
        {
            timeElapse += gametime.ElapsedGameTime.TotalSeconds;

            if (timeElapse > timeToUpdate)
            {
                timeElapse -= timeToUpdate;

                if (frameIndex < RectanglesAnimaties[currentAnimatie].Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
                timeElapse = 0;
            }
            position += velocity;
            velocity = Vector2.Zero;
        }

        public void AddAnimatie(int frames, double yPos, int xStart, string naam, int width, int height, Vector2 offset)
        {
            Rectangle[] Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStart) * width, (int)yPos, width, height);
            }

            RectanglesAnimaties.Add(naam, Rectangles);
        }

        public void AnimatieAfspelen(string animatieNaam)
        {
            if (currentAnimatie != animatieNaam)
            {
                currentAnimatie = animatieNaam;
                frameIndex = 0;
            }
        }
    }
}
