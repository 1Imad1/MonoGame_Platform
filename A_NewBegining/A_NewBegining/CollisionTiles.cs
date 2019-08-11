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
        /// <summary>
        /// Every tile png has to have the name Tile and his unique number togheter (like example Tile1)
        /// if you do this then the only thing that you have to do is generate the map with the generate method in the mapengine class
        /// thats when the i comes in, you can see this like this in de generate method                 
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},
        ///    {i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,i,},}
        ///    and thats why the number nex to the Tile is importent so you just have to put a number in
        /// </summary>
        /// <param name="i"></param>
        /// <param name="newRect">size of map</param>
        public CollisionTiles(int i, Rectangle newRect)
        {
            texture = Content.Load<Texture2D>("Tile" + i); //loads the tile (tile1, tile2)
            Rectangle = newRect;
        }

        /// <summary>
        /// unloads the map that you created, this is used to mape levelswitching possible (unload level map 1, then generate new map) like in the map class
        /// </summary>
        public void UnloadContent()
        {
            Rectangle = new Rectangle(0, 0, 0, 0);           
        }
    }
}