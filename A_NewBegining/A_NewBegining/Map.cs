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
    class Map : MapEngine, ILevels
    {
        public bool lvl1 = true;
        public bool lvl2 = false;
        public bool lvl3 = false;
        public bool clear = false;

        public bool Level1
        {
            get { return lvl1; }
            set { lvl1 = value; }
        }
        public bool Level2
        {
            get { return lvl2; }
            set { lvl2 = value; }
        }
        public bool Level3
        {
            get { return lvl3; }
            set { lvl3 = value; }
        }

       public Player player;

        List<Coin> Coins;
        List<Enemy> MultipleEnemies;

        ContentManager Content;
        Camera camera;
        GraphicsDevice Graphics;

        List<Coin> LevelTwoCoins;
        List<Firejump> Fires;

        BeginAndEndPoint EndPoint;

        public bool Ending = false;

        public int counter = 0;
        public SpriteFont Font;

        public Map(ContentManager content, GraphicsDevice graphics)
        {
            Content = content;
            Graphics = graphics;

            player = new Player();

            EndPoint = new BeginAndEndPoint(new Vector2(1034, 0), new Vector2(0, 4));

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

            ////COINS LEVEL TWO
            LevelTwoCoins = new List<Coin>();
            LevelTwoCoins.Add(new Coin(new Vector2(66, 327)));
            LevelTwoCoins.Add(new Coin(new Vector2(81, 327)));
            LevelTwoCoins.Add(new Coin(new Vector2(96, 327)));
            LevelTwoCoins.Add(new Coin(new Vector2(111, 327)));

            LevelTwoCoins.Add(new Coin(new Vector2(320, 261)));
            LevelTwoCoins.Add(new Coin(new Vector2(335, 261)));
            LevelTwoCoins.Add(new Coin(new Vector2(350, 261)));
            LevelTwoCoins.Add(new Coin(new Vector2(365, 261)));

            LevelTwoCoins.Add(new Coin(new Vector2(519, 199)));
            LevelTwoCoins.Add(new Coin(new Vector2(534, 199)));
            LevelTwoCoins.Add(new Coin(new Vector2(549, 199)));

            LevelTwoCoins.Add(new Coin(new Vector2(642, 139)));
            LevelTwoCoins.Add(new Coin(new Vector2(657, 139)));
            LevelTwoCoins.Add(new Coin(new Vector2(672, 139)));
            LevelTwoCoins.Add(new Coin(new Vector2(687, 139)));


            LevelTwoCoins.Add(new Coin(new Vector2(819, 72)));
            LevelTwoCoins.Add(new Coin(new Vector2(834, 72)));
            LevelTwoCoins.Add(new Coin(new Vector2(849, 72)));
            LevelTwoCoins.Add(new Coin(new Vector2(864, 72)));
            LevelTwoCoins.Add(new Coin(new Vector2(879, 72)));
            LevelTwoCoins.Add(new Coin(new Vector2(894, 72)));

            ////LEVEL THREE CONTENT

            Fires = new List<Firejump>();
            Fires.Add(new Firejump(new Vector2(200, 0)));
            Fires.Add(new Firejump(new Vector2(300, 0)));
            Fires.Add(new Firejump(new Vector2(400, 0)));
            Fires.Add(new Firejump(new Vector2(500, 0)));
            Fires.Add(new Firejump(new Vector2(600, 0)));
            Fires.Add(new Firejump(new Vector2(690, 0)));
            Fires.Add(new Firejump(new Vector2(800, 0)));

            level_one(content);
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
        public void level_three(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {13,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,},
            }, 64);
        }

        public void Level1ToLevel2(ContentManager content)
        {
            if ((player.rectangle.IsTouchingRightOf(EndPoint.rectangle)) && Level1 == true)
            {
                Unload();
                Level1 = false;
                level_two(content);
                player.position = new Vector2(0, 0);
                Level2 = true;
            }
        }

        public void Level2ToLevel3(ContentManager content)
        {
            if ((player.rectangle.IsTouchingTopOf(EndPoint.rectangle)) && Level2 == true)
            {
                Unload();

                Level2 = false;
                level_three(content);
                player.position = new Vector2(0, 0);
                Level3 = true;

            }
        }

        public void BackToMainMenu(ContentManager content)
        {
            if ((player.rectangle.IsTouchingLeftOf(EndPoint.rectangle)) && Level3 == true)
            {
                Unload();
                player.position = new Vector2(0, 0);
                Level3 = false;
                Ending = true;

            }
        }

        public void NotSafeTiles(ContentManager Content)
        {
            foreach (CollisionTiles tile in CollisionTiles)
            {
                if (player.rectangle.IsTouchingTopOf(tile.Rectangle) && tile.texture == Content.Load<Texture2D>("Tile17"))
                {
                    player.position = new Vector2(0, 0);
                    player.Health -= 18;
                }
            }
        }

        public void update(GameTime gameTime, ContentManager content)
        {
            player.Update(gameTime);

            EndPoint.Update(gameTime);

            foreach (Firejump fire in Fires) { fire.Update(gameTime); }
            foreach (Coin coin in Coins) { coin.Update(gameTime); }
            foreach (Enemy enemy in MultipleEnemies) { enemy.Update(gameTime); }

            foreach (CollisionTiles tile in CollisionTiles)
            {
                player.Collision(tile.Rectangle, Width, Height);
                EndPoint.Collision(tile.Rectangle, Width, Height);


                NotSafeTiles(Content);
                camera.Update(player.position, Width, Height);

                foreach (Firejump fire in Fires) { fire.Collision(tile.Rectangle, Width, Height); }
                foreach (Coin coin in Coins) { coin.Collision(tile.Rectangle, Width, Height); }
                foreach (Enemy enemy in MultipleEnemies) { enemy.Collision(tile.Rectangle, Width, Height); player.ColideBetweenPlayers(enemy.rectangle, player.rectangle); }
                foreach (Coin coin in LevelTwoCoins) { coin.Collision(tile.Rectangle, Width, Height); }
            }

            for (int i = 0; i < Coins.Count; ++i)
            {
                Coin coin = Coins[i];
                if (player.rectangle.IsTouchingLeftOf(coin.rectangle) || player.rectangle.IsTouchingRightOf(coin.rectangle) || player.rectangle.IsTouchingTopOf(coin.rectangle)) //determine if the sprite collided here
                {
                    Coins.RemoveAt(i);
                    --i;

                    counter++;
                }
            }

            Level1ToLevel2(Content);

            if (Level2 == true)
            {
                Coins.Clear();
                MultipleEnemies.Clear();
                EndPoint.position = new Vector2(845, 388);

                for (int i = 0; i < LevelTwoCoins.Count; ++i)
                {
                    Coin coin = LevelTwoCoins[i];
                    if (player.rectangle.IsTouchingLeftOf(coin.rectangle) || player.rectangle.IsTouchingRightOf(coin.rectangle) || player.rectangle.IsTouchingTopOf(coin.rectangle)) //determine if the sprite collided here
                    {
                        LevelTwoCoins.RemoveAt(i);
                        --i;

                        counter++;
                    }
                }

                foreach (Coin coin in LevelTwoCoins) { coin.Update(gameTime); }


                Level2ToLevel3(content);
            }



            if (lvl3 == true)
            {
                for (int i = 0; i < Fires.Count; ++i)
                {
                    Firejump fire = Fires[i];
                    if (player.rectangle.IsTouchingBottom(fire.rectangle)) //determine if the sprite collided here
                    {
                        player.position = new Vector2(0, 0);
                        counter--;
                        player.Health--;
                    }
                }

                EndPoint.position = new Vector2(1343, 518);

                BackToMainMenu(content);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred,
                      BlendState.AlphaBlend,
                      null, null, null, null,
                      camera.Transform);

                base.Draw(spriteBatch);

                EndPoint.Draw(spriteBatch);
                player.Draw(spriteBatch);

                foreach (Coin coin in Coins) { coin.Draw(spriteBatch); }
                foreach (Enemy enemy in MultipleEnemies) { enemy.Draw(spriteBatch); }

                if (Level2 == true)
                    foreach (Coin coin in LevelTwoCoins) { coin.Draw(spriteBatch); }

                if (Level3 == true)
                    foreach (Firejump fire in Fires) { fire.Draw(spriteBatch); }


            spriteBatch.End();

            //DRAW SCORE ON 
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, "Coins: " + counter, new Vector2(2, 0), Color.Black);
            spriteBatch.End();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            EndPoint.LoadContent(content);
            player.LaadContent(content);
            camera = new Camera(Graphics.Viewport);

            foreach (Coin coin in Coins) { coin.LaadContent(content); }
            foreach (Enemy enemy in MultipleEnemies) { enemy.LaadContent(content); }

            foreach (Coin coin in LevelTwoCoins) { coin.LaadContent(content); }

            foreach (Firejump fire in Fires) { fire.LaadContent(content); }

            Font = Content.Load<SpriteFont>("Score");
        }
    }
}