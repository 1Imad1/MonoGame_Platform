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
        //no laod, no draw, boxroundCharachter, no speed, no direction (velocity)


        public Vector2 Position;
        public Texture2D Texture;
        public Vector2 sDirection = Vector2.Zero;

        public string currentAnimatie;

        public int frameIndex;
        public double timeElapse;
        public double timeToUpdate;

        public Rectangle BoxRondCharachter
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 50, 41);
            }
        }

        public int FramesPerSec
        {
            set { timeToUpdate = (1f / value); }
        }

        public Animation(Vector2 pos, Texture2D txt, Vector2 velocity, Rectangle rectangle)
        {
            Position = pos;
            Texture = txt;
            sDirection = velocity;
            rectangle = BoxRondCharachter;
        }

        public Dictionary<string, Rectangle[]> Animatie = new Dictionary<string, Rectangle[]>();

        public void Update(GameTime gametime)
        {
            timeElapse += gametime.ElapsedGameTime.TotalSeconds;

            if (timeElapse > timeToUpdate)
            {
                timeElapse -= timeToUpdate;

                if (frameIndex < Animatie[currentAnimatie].Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                }
                timeElapse = 0;
            }

            Position += sDirection;
            sDirection = Vector2.Zero;
        }

        public void AddAnimatie(int frames, double yPos, int xStart, string naam, int width, int height, Vector2 offset)
        {

            Rectangle[] Rectangles = new Rectangle[frames];

            ///neemt de spritesheet en het verdeelt zich
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStart) * width, (int)yPos, width, height);
            }

            Animatie.Add(naam, Rectangles);
        }

        public void AnimatieAfspelen(string animatieNaam)
        {
            if (currentAnimatie != animatieNaam)
            {
                currentAnimatie = animatieNaam;
                frameIndex = 0;
            }
        }

        public void LaadContent(ContentManager content, string afbeelding)
        {
            Texture = content.Load<Texture2D>(afbeelding);
        }

        public void Draw(SpriteBatch sprite, string current, int frameindex)
        {
            sprite.Draw(Texture, Animatie[current][frameindex], Color.White);
        }
    }
}
