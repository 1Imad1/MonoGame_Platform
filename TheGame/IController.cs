﻿using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TheGame
{
    interface IController
    {
        bool Left { get; set; }
        bool Right { get; set; }
        bool Up { get; set; }
        bool NormalAttack { get; set; }
        bool ComboAttack { get; set; }

        void update();
    }
}
