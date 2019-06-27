using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    interface ICollider
    {
        Rectangle CollisionRectangle { get; set; }
    }
}
