using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace A_NewBegining
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Map map;

        //Player player;
        //Camera camera;

        Texture2D background;
        Vector2 backPos;
        HealthBar health;

        List<Enemy> MultipleEnemies;
        List<Coin> Coins;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //player = new Player();
            map = new Map(Content, GraphicsDevice);

            //MultipleEnemies = new List<Enemy>();

            //MultipleEnemies.Add(new Enemy(50, new Vector2(250, 230)));
            //MultipleEnemies.Add(new Enemy(80, new Vector2(700, 230)));

            map.level_one(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map.LoadContent(Content);

            //player.LaadContent(Content);

            //foreach (Enemy enemy in MultipleEnemies)
            //{
            //    enemy.LaadContent(Content);
            //}

            background = Content.Load<Texture2D>("Background");
            backPos = new Vector2(0, 0);
            health = new HealthBar(Content);

            //camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                       
            //player.Update(gameTime);

            //foreach (Enemy enemy in MultipleEnemies) { enemy.Update(gameTime); }

            map.update(gameTime);

            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                //player.Collision(tile.Rectangle, map.Width, map.Height);

                //foreach (Enemy enemy in MultipleEnemies)
                //{
                //    enemy.Collision(tile.Rectangle, map.Width, map.Height);
                //    player.ColideBetweenPlayers(enemy.rectangle, player.rectangle);
                //}

                //camera.Update(player.position, map.Width, map.Height);

                map.NotSafeTiles(Content);

                //for (int i = 0; i < MultipleEnemies.Count; ++i)
                //{
                //    Enemy enemy = MultipleEnemies[i];
                //    if (player.rectangle.IsTouchingLeftOf(enemy.rectangle)) //determine if the sprite collided here
                //    {
                //        MultipleEnemies.RemoveAt(i);
                //        --i;
                //    }
                //}
            }

            //foreach (Enemy enemy in MultipleEnemies)
            //{
            //    if (player.rectangle.IsTouchingTopOf(enemy.rectangle))
            //    { player.position = new Vector2(0, 0); }

            //    map.Level1ToLevel2(player, enemy, Content);
            //}



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, 
                              BlendState.AlphaBlend,
                              null,null,null,null,
                              map.TheMatrix);
            spriteBatch.Draw(background, backPos, Color.White);

            map.Draw(spriteBatch);

            
            //player.Draw(spriteBatch);

            //foreach (Enemy enemy in MultipleEnemies)
            //{
            //    enemy.Draw(spriteBatch);
            //}

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
