using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGame
{
    class Inputs : IController
    {
        #region Properties
        public bool left;
        public bool right;
        public bool up;
        public bool normalAttack;
        public bool comboAttack;

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

        public bool NormalAttack
        {
            get { return normalAttack; }
            set { normalAttack = value; }
        }

        public bool ComboAttack
        {
            get { return comboAttack; }
            set { comboAttack = value; }
        }
        #endregion
        

        public void update()
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

            if (keyState.IsKeyDown(Keys.A))
            {
                NormalAttack = true;
            }

            if (keyState.IsKeyUp(Keys.A))
            {
                NormalAttack = false;
            }

            if (keyState.IsKeyDown(Keys.Z))
            {
                ComboAttack = true;
            }

            if (keyState.IsKeyUp(Keys.Z))
            {
                ComboAttack = false;
            }
        }
    }
}