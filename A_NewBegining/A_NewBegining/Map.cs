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
        public bool lvl1 = false;
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

            //Map heeft Enemies
            MultipleEnemies = new List<Enemy>();

            MultipleEnemies.Add(new Enemy(50, new Vector2(300, 0)));

            //Map heeft Coins
            Coins = Coins = new List<Coin>();

            Coins.Add(new Coin(new Vector2(180, 0)));

            Coins.Add(new Coin(new Vector2(280, 425)));
            Coins.Add(new Coin(new Vector2(295, 425)));
            Coins.Add(new Coin(new Vector2(325, 425)));
            Coins.Add(new Coin(new Vector2(340, 425)));
            Coins.Add(new Coin(new Vector2(355, 425)));
            Coins.Add(new Coin(new Vector2(370, 425)));

        }


        public virtual void level_one(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
                {2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
                {2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
                {2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,2,1,3,3,3,2,2,},
                {2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
                {2,3,3,3,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            }, 64);

            foreach (CollisionTiles tile in CollisionTiles)
            {
                if (player.rectangle.IsTouchingTopOf(tile.Rectangle) && tile.texture == content.Load<Texture2D>("Tile3"))
                {
                    player.position = new Vector2(0, 0);
                }
            }
        }

        public void level_two(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,},
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,},
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,},
            }, 64);
        }

        public void Level1ToLevel2(Player player, Enemy enemy, ContentManager content)
        {
            lvl1 = true;
            //from level 1 to level 2
            if (player.position.X >= 1370 && lvl1 == true)
            {
                Unload();

                level_two(content);
                player.position = new Vector2(0, 0);

                lvl2 = true;
            }

            //if (player.position.X >= 1290 && lvl2 == true)
            //{
            //    Unload();
            //    lvl2 = false;
            //    level_one(content);
            //    player.position = new Vector2(0, 0);
            //}
        }

        public void Level2ToLevel3(Player player, ContentManager content)
        {

            if (player.position.X >= 1370 && lvl2 == true)
            {

                Unload();

                level_one(content);
                player.position = new Vector2(0, 0);
            }
        }

        public void NotSafeTiles(ContentManager Content)
        {
            foreach (CollisionTiles tile in CollisionTiles)
            {
                if (player.rectangle.IsTouchingTopOf(tile.Rectangle) && tile.texture == Content.Load<Texture2D>("Tile3"))
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

            foreach (Enemy enemy in MultipleEnemies)
            {

                Level1ToLevel2(player, enemy, content);
            }

            player.LaadContent(content);
            camera = new Camera(Graphics.Viewport);
        }
    }
}
