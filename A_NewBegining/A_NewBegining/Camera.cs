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
    class Camera
    {
        private Matrix transform;
        public Matrix Transform { get { return transform; } }

        private Vector2 center;
        private Viewport viewport;

        public Camera(Viewport newViewport) { viewport = newViewport; }

        /// <summary> 
        /// Update method explained
        /// </summary>
        /// 
        /// if => if the player is less than the viewport width then camera will stop going further to the left
        /// else if => else if player is larger than the viewport width then camera will stop going further to the right
        /// else => else center camera wil stop following till you move
        /// 
        /// the second if else if else else statement is the same but then for the height
        /// <param name="position"> what the camera is going to follow </param>
        /// <param name="xOffset"> X part of the screen between 0 and the amount of tiles multiply by the tiles width </param>
        /// <param name="yOffset"> same as x but then for the height </param>
        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewport.Width / 2)
                center.X = viewport.Width / 2;
            else if (position.X > xOffset - (viewport.Width / 2))
                center.X = xOffset - (viewport.Width / 2);
            else center.X = position.X;

            if (position.Y < viewport.Height / 2)
                center.Y = viewport.Height / 2;
            else if (position.Y > yOffset - (viewport.Height / 2))
                center.Y = yOffset - (viewport.Height / 2);
            else center.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width/2), -center.Y + (viewport.Height/2), 0));
        }
    }
}
