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
    public class Input: IController
    {
        #region Properties
        public bool left;
        public bool right;
        public bool up;
        public bool down;
        public bool normalAttack;

        public bool hasJumped = false;

        public bool Left
        {
            get { return left; }
            set { left = value; }
        }

        public bool Right
        {
            get { return right; }
            set { right = value; }
        }

        public bool Up
        {
            get { return up; }
            set { up = value; }
        }

        public bool Down
        {
            get { return down; }
            set { down = value; }
        }

        public bool NormalAttack
        {
            get { return normalAttack; }
            set { normalAttack = value; }
        }
        #endregion


        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Up))
            {
                Up = true;
            }

            if (keyState.IsKeyUp(Keys.Up))
            {
                Up = false;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                Down = true;
            }

            if (keyState.IsKeyUp(Keys.Down))
            {
                Down = false;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                Left = true;
            }

            if (keyState.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                Right = true;
            }

            if (keyState.IsKeyUp(Keys.Right))
            {
                Right = false;
            }

            if (keyState.IsKeyDown(Keys.Z))
            {
                NormalAttack = true;
            }

            if (keyState.IsKeyUp(Keys.Z))
            {
                NormalAttack = false;
            }
        }
    }
}
