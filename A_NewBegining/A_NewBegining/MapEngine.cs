﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    class MapEngine
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public MapEngine()
        {

        }

        /// <summary>
        /// 2D map Tile based
        /// collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size))); == new tile added, 
        /// size is de size of the tile and x * size, y * size is the position of the map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="size"></param>
        public void Generate(int[ , ] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        width = (x + 1) * size;
                        height = (y + 1) * size;

                        
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }
                }
            }
        }

        public virtual void level_one(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {2,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {9,9,16,0,0,0,0,0,0,0,0,0,0,1,2,2,2,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,1,2,8,5,5,5,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,13,14,8,9,9,9,9,9,0,0,0,0,0,},
                {0,0,0,13,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {4,10,3,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,},
                {4,5,10,11,2,3,0,0,0,1,2,8,10,11,3,0,0,0,0,0,0,0,},
                {8,5,5,5,5,6,17,17,1,8,5,5,5,5,6,17,17,0,0,0,0,0,},
            }, 64);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        public virtual void LoadContent(ContentManager content) { }

        public virtual void Unload()
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.UnloadContent();
            }
        }
    }
}