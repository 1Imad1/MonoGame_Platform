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
    /// <summary>
    /// this class makes it possible to Generate the map hence the name MapEngine
    /// </summary>
    class MapEngine
    {
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }

        private int width, height;
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        /// <summary>
        /// 2D map Tile Generator 
        /// </summary>
        /// <param name="map"> the map that you wil create and generate </param>
        /// <param name="size"> Size of the map </param>
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