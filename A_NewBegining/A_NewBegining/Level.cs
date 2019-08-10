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
    class Level : MapEngine
    {
        Player player;
        Coin Coin;

        Camera camera;
        GraphicsDevice Graphics;
        public Matrix TheMatrix;

        public Level(GraphicsDevice graphics)
        {

            Graphics = graphics;
            player = new Player();

            Coin = new Coin(new Vector2(200, 0));
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Coin.Update(gameTime);

            foreach (CollisionTiles tile in CollisionTiles)
            {
                player.Collision(tile.Rectangle, Width, Height);
                Coin.Collision(tile.Rectangle, Width, Height);

                camera.Update(player.position, Width, Height);
                TheMatrix = camera.Transform;
            }
        }

        public void FirstMisison(ContentManager content)
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            //base.Draw(spriteBatch);
            player.Draw(spriteBatch);
            Coin.Draw(spriteBatch);
        }

        public override void LoadContent(ContentManager content)
        {
            //base.LoadContent(content);
            player.LaadContent(content);
            Coin.LaadContent(content);


            camera = new Camera(Graphics.Viewport);
        }

        public override void Unload()
        {
            base.Unload();
        }
    }
}
