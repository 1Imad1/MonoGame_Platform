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
    class Map : MapEngine
    {
        public bool lvl1 = true;
        public bool lvl2 = false;
        public bool lvl3 = false;
        
        Player player;

        List<Coin> Coins;
        List<Enemy> MultipleEnemies;

        ContentManager Content;
        Camera camera;
        GraphicsDevice Graphics;

        public Matrix TheMatrix;

        public Map(ContentManager content, GraphicsDevice graphics)
        {
            Content = content;
            Graphics = graphics;

            player = new Player();

            MultipleEnemies = new List<Enemy>();
            MultipleEnemies.Add(new Enemy(50, new Vector2(300, 0)));

            Coins = Coins = new List<Coin>();
            Coins.Add(new Coin(new Vector2(200, 0)));

            Coins.Add(new Coin(new Vector2(715, 136)));
            Coins.Add(new Coin(new Vector2(730, 136)));
            Coins.Add(new Coin(new Vector2(745, 136)));
            Coins.Add(new Coin(new Vector2(760, 136)));
            Coins.Add(new Coin(new Vector2(775, 136)));
            Coins.Add(new Coin(new Vector2(790, 136)));

            Coins.Add(new Coin(new Vector2(0, 340)));
            Coins.Add(new Coin(new Vector2(15, 340)));
            Coins.Add(new Coin(new Vector2(30, 340)));
            Coins.Add(new Coin(new Vector2(45, 340)));
            Coins.Add(new Coin(new Vector2(60, 340)));
            Coins.Add(new Coin(new Vector2(75, 340)));
            Coins.Add(new Coin(new Vector2(90, 340)));

            Coins.Add(new Coin(new Vector2(727, 391)));
            Coins.Add(new Coin(new Vector2(742, 391)));
            Coins.Add(new Coin(new Vector2(757, 391)));
            Coins.Add(new Coin(new Vector2(772, 391)));
            Coins.Add(new Coin(new Vector2(787, 391)));

            Coins.Add(new Coin(new Vector2(280, 425)));
            Coins.Add(new Coin(new Vector2(295, 425)));
            Coins.Add(new Coin(new Vector2(325, 425)));
            Coins.Add(new Coin(new Vector2(340, 425)));
            Coins.Add(new Coin(new Vector2(355, 425)));
            Coins.Add(new Coin(new Vector2(370, 425)));

            Coins.Add(new Coin(new Vector2(589, 451)));
            Coins.Add(new Coin(new Vector2(604, 451)));
            Coins.Add(new Coin(new Vector2(619, 451)));
            Coins.Add(new Coin(new Vector2(634, 451)));
            Coins.Add(new Coin(new Vector2(649, 451)));
            Coins.Add(new Coin(new Vector2(664, 451)));

            Coins.Add(new Coin(new Vector2(511, 519)));
            Coins.Add(new Coin(new Vector2(526, 519)));
            Coins.Add(new Coin(new Vector2(541, 519)));
            Coins.Add(new Coin(new Vector2(566, 519)));
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

        public void level_two(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {12,9,16,0,0,0,0,0,0,0,0,0,13,14,15,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,},
            }, 64);
        }

        public void Level1ToLevel2(ContentManager content)
        {
            //from level 1 to level 2
            if (player.position.X >= 1034 && lvl1 == true)
            {
                Unload();
                lvl1 = false;
                level_two(content);
                player.position = new Vector2(0, 0);
                lvl2 = true;
            }
        }

        public void Level2ToLevel3(ContentManager content)
        {
            if (player.position.X >= 1080 && lvl2 == true)
            {
                Unload();
                lvl2 = false;
                level_one(content);
                player.position = new Vector2(0, 0);
            }
        }

        public void NotSafeTiles(ContentManager Content)
        {
            foreach (CollisionTiles tile in CollisionTiles)
            {
                if (player.rectangle.IsTouchingTopOf(tile.Rectangle) && tile.texture == Content.Load<Texture2D>("Tile17"))
                {
                    player.position = new Vector2(0, 0);

                }
            }
        }

        public void update(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach (Coin coin in Coins) { coin.Update(gameTime); }

            foreach (Enemy enemy in MultipleEnemies) { enemy.Update(gameTime); }

            foreach (CollisionTiles tile in CollisionTiles)
            {
                player.Collision(tile.Rectangle, Width, Height);
                

                foreach (Coin coin in Coins)
                {
                    coin.Collision(tile.Rectangle, Width, Height);
                }

                foreach (Enemy enemy in MultipleEnemies)
                {
                    enemy.Collision(tile.Rectangle, Width, Height);
                    player.ColideBetweenPlayers(enemy.rectangle, player.rectangle);
                }

                NotSafeTiles(Content);
                camera.Update(player.position, Width, Height);

                TheMatrix = camera.Transform;
            }

            for (int i = 0; i < Coins.Count; ++i)
            {
                Coin coin = Coins[i];
                if (player.rectangle.IsTouchingLeftOf(coin.rectangle) || player.rectangle.IsTouchingRightOf(coin.rectangle) || player.rectangle.IsTouchingTopOf(coin.rectangle)) //determine if the sprite collided here
                {
                    Coins.RemoveAt(i);
                    --i;
                }
            }

            Level1ToLevel2(Content);

            for (int i = 0; i < MultipleEnemies.Count; ++i)
            {
                Enemy enemy = MultipleEnemies[i];
                if (player.rectangle.IsTouchingLeftOf(enemy.rectangle)) //determine if the sprite collided here
                {
                    
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
            base.Draw(spriteBatch);
            player.Draw(spriteBatch);

            foreach (Coin coin in Coins) { coin.Draw(spriteBatch); }
            foreach (Enemy enemy in MultipleEnemies) { enemy.Draw(spriteBatch); }
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            foreach (Coin coin in Coins)
            {
                coin.LaadContent(content);
            }

            foreach (Enemy enemy in MultipleEnemies)
            {
                enemy.LaadContent(content);
            }

            player.LaadContent(content);
            camera = new Camera(Graphics.Viewport);
        }
    }
}
