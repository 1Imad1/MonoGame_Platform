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

        /// Number of frames in the animation
        public int frameIndex;

        /// Time that has passed since last frame change 
        public double timeElapse;

        public double timeToUpdate;

        /// Our time per frame is equal to 1 divided by frames per second(we are deciding FPS)
        public int FramesPerSec
        {
            set { timeToUpdate = (1f / value); }
        }

        /// Dictionary that contains all animations
        public Dictionary<string, Rectangle[]> RectanglesAnimaties = new Dictionary<string, Rectangle[]>();

        public Animation(Vector2 position, Vector2 velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }

        /// <summary>
        /// Determines when we have to change frames
        /// </summary>
        /// <param name="GameTime">GameTime</param>
        public void Update(GameTime gametime)
        {            
            //Adds time that has elapsed since our last draw
            timeElapse += gametime.ElapsedGameTime.TotalSeconds;

            //We need to change our image if our timeElapsed is greater than our timeToUpdate(calculated by our framerate)
            if (timeElapse > timeToUpdate)
            {    
                //Resets the timer in a way, so that we keep our desired FPS
                timeElapse -= timeToUpdate;

                //Adds one to our frameIndex
                if (frameIndex < RectanglesAnimaties[currentAnimatie].Length - 1)
                {
                    frameIndex++;
                }
                else //Restarts the animation
                {
                    frameIndex = 0;
                }
                timeElapse = 0;
            }
            //position += velocity;
            //velocity = Vector2.Zero;
        }

        /// <summary>
        /// Adds an animation to the Animation sprite
        /// </summary>
        /// <param name="frames"> How many frames it has at a certain position </param>
        /// <param name="yPos"> The begin position of that animation of sprite (like example walk) </param>
        /// <param name="xStart"> At wich frame you want to start </param>
        /// <param name="naam"> Name of Animation </param>
        /// <param name="width"> Width of first frame </param>
        /// <param name="height"> Height of first frame </param>
        /// <param name="offset"> outlining the charachter when you becaus the are frames where you attack and its diffrent from the others </param>
        public void AddAnimatie(int frames, double yPos, int xStart, string naam, int width, int height, Vector2 offset)
        {
            //Creates an array of rectangles which will be used when playing an animation
            Rectangle[] Rectangles = new Rectangle[frames];

            //Fills up the array of rectangles
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStart) * width, (int)yPos, width, height);
            }

            RectanglesAnimaties.Add(naam, Rectangles);
        }

        public void Afspelen(string animatieNaam)
        {            
            //Makes sure we won't start a new annimation unless its diffrent from our current animation
            if (currentAnimatie != animatieNaam)
            {
                currentAnimatie = animatieNaam;
                frameIndex = 0;
            }
        }
    }
}
