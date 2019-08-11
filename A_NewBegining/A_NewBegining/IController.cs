using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace A_NewBegining
{
    interface IController
    {
        bool Left { get; set; }
        bool Right { get; set; }
        bool Up { get; set; }
        bool Down { get; set; }
        bool NormalAttack { get; set; }

        void Update();
    }
}
