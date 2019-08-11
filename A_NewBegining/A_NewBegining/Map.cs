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
    /// <summary>
    /// Map has levels, content and update after thing changes
    /// </summary>
    class Map : MapEngine, ILevels
    {
        public bool level1IsCurrentLevel = true;
        public bool level2IsCurrentLevel = false;
        public bool level3IsCurrentLevel = false;

        public bool Level1IsCurrentLevel
        {
            get { return level1IsCurrentLevel; }
            set { level1IsCurrentLevel = value; }
        }
        public bool Level2IsCurrentLevel
        {
            get { return level2IsCurrentLevel; }
            set { level2IsCurrentLevel = value; }
        }
        public bool Level3IsCurrentLevel
        {
            get { return level3IsCurrentLevel; }
            set { level3IsCurrentLevel = value; }
        }

        public Player player;

        ContentManager Content;
        Camera camera;
        GraphicsDevice Graphics;

        //LEVEL ONE CONTENT
        List<Coin> Coins;
        List<Enemy> MultipleEnemies;

        //LEVEL TWE CONTENT
        List<Coin> LevelTwoCoins;
        
        //LEVEL THREE CONTENT
        List<Firejump> Fires;
        List<Enemy> Enemies;

        BeginAndEndPoint EndPoint;

        public bool YouLose = false;
        public bool YouWon = false;

        public int counter = 0;
        public SpriteFont Font;

        public Map(ContentManager content, GraphicsDevice graphics)
        {
            Content = content;
            Graphics = graphics;

            player = new Player();

            EndPoint = new BeginAndEndPoint(new Vector2(1034, 0), new Vector2(0, 4));

            #region Level One Content
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
#endregion

            #region Level Two Content
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
#endregion

            #region Level Three Content
            Fires = new List<Firejump>();
            Fires.Add(new Firejump(new Vector2(200, 0)));
            Fires.Add(new Firejump(new Vector2(300, 0)));
            Fires.Add(new Firejump(new Vector2(400, 0)));
            Fires.Add(new Firejump(new Vector2(500, 0)));
            Fires.Add(new Firejump(new Vector2(600, 0)));
            Fires.Add(new Firejump(new Vector2(690, 0)));
            Fires.Add(new Firejump(new Vector2(800, 0)));

            Fires.Add(new Firejump(new Vector2(250, 518)));
            Fires.Add(new Firejump(new Vector2(350, 518)));
            Fires.Add(new Firejump(new Vector2(400, 518)));
            Fires.Add(new Firejump(new Vector2(500, 518)));
            Fires.Add(new Firejump(new Vector2(600, 518)));
            Fires.Add(new Firejump(new Vector2(690, 518)));
            Fires.Add(new Firejump(new Vector2(880, 518)));

            Enemies = new List<Enemy>();
            Enemies.Add(new Enemy(50, new Vector2(900, 518)));
            Enemies.Add(new Enemy(50, new Vector2(1054, 518)));
            #endregion

            level_one(content);
        }

        public void level_one(ContentManager content)
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
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
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
            if ((player.rectangle.IsTouchingRightOf(EndPoint.rectangle)) && Level1IsCurrentLevel == true)
            {
                Unload();
                Level1IsCurrentLevel = false;

                level_two(content);
                player.position = new Vector2(0, 0);

                Level2IsCurrentLevel = true;
            }
        }

        public void Level2ToLevel3(ContentManager content)
        {
            if ((player.rectangle.IsTouchingTopOf(EndPoint.rectangle)) && Level2IsCurrentLevel == true)
            {
                Unload();

                Level2IsCurrentLevel = false;
                level_three(content);
                player.position = new Vector2(0, 0);

                Level3IsCurrentLevel = true;

            }
        }

        public void BackToMainMenu(ContentManager content)
        {
            if ((player.rectangle.IsTouchingLeftOf(EndPoint.rectangle)) && Level3IsCurrentLevel == true)
            {
                Unload();
                player.position = new Vector2(0, 0);
                Level3IsCurrentLevel = false;

                if (counter >= 30)
                    YouWon = true;
                else
                    YouLose = true;
            }
        }

        public void NotSafeTiles(ContentManager Content)
        {
            foreach (CollisionTiles tile in CollisionTiles)
            {
                if (player.rectangle.IsTouchingTopOf(tile.Rectangle) && tile.texture == Content.Load<Texture2D>("Tile17"))
                {
                    player.position = new Vector2(0, 0);
                    player.healthBar.CurrentHealth -= 18;
                }
            }
        }

        public void update(GameTime gameTime, ContentManager content)
        {
            player.Update(gameTime);
            EndPoint.Update(gameTime);

            #region  LEVEL 1 AND 3 CONTENT UPDATE
            foreach (Coin coin in Coins) { coin.Update(gameTime); }
            foreach (Enemy enemy in MultipleEnemies) { if(enemy.healthBar.CurrentHealth >= 0) enemy.Update(gameTime); }
            
            //LEVEL 3 CONTENT
            foreach (Firejump fire in Fires) { fire.Update(gameTime); }
            foreach (Enemy enemy in Enemies) { if (enemy.healthBar.CurrentHealth >= 0) enemy.Update(gameTime); }
            #endregion

            foreach (CollisionTiles tile in CollisionTiles)
            {
                player.Collision(tile.Rectangle, Width, Height);
                EndPoint.Collision(tile.Rectangle, Width, Height);

                NotSafeTiles(Content);
                camera.Update(player.position, Width, Height);

                //LEVEL 1 CONTENT
                foreach (Coin coin in Coins) { coin.Collision(tile.Rectangle, Width, Height); }
                foreach (Enemy enemy in MultipleEnemies)
                {
                    if (enemy.healthBar.CurrentHealth >= 0)
                    {
                        enemy.Collision(tile.Rectangle, Width, Height);
                        enemy.ColideWithPlayer(enemy.rectangle, player.rectangle, player.Key);
                        player.ColideWithEnemy(enemy.rectangle, player.rectangle);
                    }
                }

                //LEVEL 3 CONTENT
                foreach (Firejump fire in Fires) { fire.Collision(tile.Rectangle, Width, Height); }
                foreach (Enemy enemy in Enemies)
                {
                    if (enemy.healthBar.CurrentHealth >= 0)
                    {
                        enemy.Collision(tile.Rectangle, Width, Height);
                        enemy.ColideWithPlayer(enemy.rectangle, player.rectangle, player.Key);
                        player.ColideWithEnemy(enemy.rectangle, player.rectangle);
                    }
                }

                //LEVEL 2 CONTENT
                foreach (Coin coin in LevelTwoCoins) { coin.Collision(tile.Rectangle, Width, Height); }
            }

            //When a coin is taken remove from map and count up
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

            //If currentLevel = 2, then clear all coin and enemies from previous map, endpoint position (endpoint = to go to next level)
            //also level 2 coins will be drawn zo you can take those coins and count up with previous captured coins
            if (Level2IsCurrentLevel == true)
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

                //animation of coin only if level 2 is current level
                foreach (Coin coin in LevelTwoCoins) { coin.Update(gameTime); }
            }


            //if level 3 is current level = endpoint changes, after getting hit by firebal then player position changes
            if (Level3IsCurrentLevel == true)
            {
                //player loses health and coins if he is getting hit by fireball
                for (int i = 0; i < Fires.Count; ++i)
                {
                    Firejump fire = Fires[i];
                    if (player.rectangle.IsTouchingBottom(fire.rectangle)) //determine if the sprite collided here
                    {
                        player.position = new Vector2(0, 0);
                        counter--;
                        player.healthBar.CurrentHealth--;
                    }
                }

                EndPoint.position = new Vector2(1343, 518);

                //set bool ending to true, so you can get the gameOver screen
                BackToMainMenu(content);
            }

            Level1ToLevel2(content);
            Level2ToLevel3(content);
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
                foreach (Enemy enemy in MultipleEnemies) { if (enemy.healthBar.CurrentHealth >= 0) enemy.Draw(spriteBatch); }

                if (Level2IsCurrentLevel == true)
                    foreach (Coin coin in LevelTwoCoins) { coin.Draw(spriteBatch); }

                if (Level3IsCurrentLevel == true)
                {
                    foreach (Firejump fire in Fires) { fire.Draw(spriteBatch); }
                    foreach (Enemy enemy in Enemies) { if (enemy.healthBar.CurrentHealth >= 0) enemy.Draw(spriteBatch); }
                }


            spriteBatch.End();

            //DRAW SCORE ON SCREEN WHEN PLAYING GAME TO KEEP TRACK OF HOW MANY COINS YOU TOOK 
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

            //LEVEL ONE CONTENT
            foreach (Coin coin in Coins) { coin.LaadContent(content); }
            foreach (Enemy enemy in MultipleEnemies) {enemy.LaadContent(content); }

            //LEVEL TWO
            foreach (Coin coin in LevelTwoCoins) { coin.LaadContent(content); }

            //LEVEL THREE CONTENT
            foreach (Firejump fire in Fires) { fire.LaadContent(content); }
            foreach (Enemy enemy in Enemies) { enemy.LaadContent(content); }

            Font = Content.Load<SpriteFont>("Score");
        }
    }
}