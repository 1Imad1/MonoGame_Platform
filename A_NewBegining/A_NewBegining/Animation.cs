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
        #region Variabele
        public float speed = 2.5f;
        protected string currentAnimatie;

        public Vector2 sPosition;
        public Texture2D sTexture;
        public Rectangle rectangle;

        private int FrameIndex;
        private double TimeElapse;
        private double TimeToUpdate;

        public Vector2 sDirection = Vector2.Zero;
        #endregion

        #region BoxRondCharachter

        public Rectangle BoxRondCharachter;
        

        #endregion

        #region FramePerSec en Animatie constructor
        public int FramesPerSec
        {
            set { TimeToUpdate = (1f / value); }
        }

        public Animation(Vector2 pos, Texture2D texture, Rectangle rect)
        {
            BoxRondCharachter = rect;
            sPosition = pos;
            sTexture = texture;
        }
        #endregion

        private Dictionary<string, Rectangle[]> sAnimatie = new Dictionary<string, Rectangle[]>();

        #region Update

        public void Update(GameTime gametime)
        {
            TimeElapse += gametime.ElapsedGameTime.TotalSeconds;

            if (TimeElapse > TimeToUpdate)
            {
                TimeElapse -= TimeToUpdate;

                if (FrameIndex < sAnimatie[currentAnimatie].Length - 1)
                {
                    FrameIndex++;
                }
                else
                {
                    FrameIndex = 0;
                }
                TimeElapse = 0;
            }
        }
        #endregion

        #region AddAnimatie

        public void AddAnimatie(int frames, double yPos, int xStart, string naam, int width, int height, Vector2 offset)
        {

            Rectangle[] Rectangles = new Rectangle[frames];

            ///neemt de spritesheet en het verdeelt zich
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStart) * width, (int)yPos, width, height);
            }

            sAnimatie.Add(naam, Rectangles);
        }
        #endregion

        #region Draw
        /// <summary>
        /// sAnimatie[currentAnimatie][FrameIndex]
        ///     toegang tot de animatie woordenboek en hierin zoeken we de current animatie en hierop zoeken we de frame van de frameindex
        /// </summary>
        /// <param name="sprite"></param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(sTexture, sPosition, sAnimatie[currentAnimatie][FrameIndex], Color.White);
        }
        #endregion

        #region AnimatieAfspelen
        /// <summary>
        /// mag alleen veranderen als er een nieuwe animatie is
        //FrameIndex = 0 => zorgt ervoor dat we geen index buiten de grenzen krijgen, bv we spelen onze run animatie af en dit heeft 9 frames bijvoorbeeld, en we schakellen over naar en er is maar 1 frame erin dan krijgen we een index out of bound
        /// </summary>
        /// <param name="animatieNaam"></param>
        public void AnimatieAfspelen(string animatieNaam)
        {
            if (currentAnimatie != animatieNaam)
            {
                currentAnimatie = animatieNaam;
                FrameIndex = 0;
            }
        }
        #endregion

        #region LoadContent
        /// <summary>
        /// het geeft de speler een afbeelding die je hebt meegegeven
        /// laad het dan in de texture
        /// </summary>
        /// <param name="content"></param>
        public void LaadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("char");
        }
        #endregion
    }
}
