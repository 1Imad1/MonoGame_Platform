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
    class CollisionTiles : Tiles
    {

        public CollisionTiles(int i, Rectangle newRect)
        {
            texture = Content.Load<Texture2D>("Tile" + i); //loads the tile (tile1, tile2)
            Rectangle = newRect;
        }

        public void UnloadContent()
        {
            Rectangle = new Rectangle(0, 0, 0, 0);           
        }
    }
}