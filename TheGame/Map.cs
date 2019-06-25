using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Map : MapEngine
    {
        public void ShowMap(ContentManager Content)
        {
            Tiles.Content = Content;

            Generate(new int[,]{
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
                {2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
                {2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
                {2,2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,1,0,0,0,2,2,},
                {2,2,0,0,1,0,1,2,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
                {2,0,0,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {2,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            }, 74);
        }
    }
}
