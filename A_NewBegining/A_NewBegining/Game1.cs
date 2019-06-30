﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace A_NewBegining
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Map map;

        Player player;
        Enemy enemy;
        Camera camera;

        Texture2D background;
        Vector2 backPos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            map = new Map();

            enemy = new Enemy(80);
            player = new Player();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LaadContent(Content);
            enemy.LaadContent(Content);
                       
            background = Content.Load<Texture2D>("Background");
            backPos = new Vector2(0, 0);

            Tiles.Content = Content;

            if(player.Position.X > 1300)
                map.level_two(Content);

            map.level_one(Content);

            camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void UnloadContent()
        {
            if(player.Position.X == 1300)
            {
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            enemy.Update(gameTime);

            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                player.Collision(tile.Rectangle, map.Width, map.Height);
                enemy.Collision(tile.Rectangle, map.Width, map.Height);
                camera.Update(player.Position, map.Width, map.Height);
                player.ColideBetweenPlayers(enemy.rectangle, player.rectangle);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, 
                              BlendState.AlphaBlend,
                              null,null,null,null,
                              camera.Transform);
            spriteBatch.Draw(background, backPos, Color.White);

            map.Draw(spriteBatch);

            
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
