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

namespace TheGame
{
    class Enemy
    {
        public Vector2 position = new Vector2(750, 205);
        public Vector2 Position
        {
            get { return position; }
        }

        public Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        public int Width { get; set; }
        public int Height { get; set; }

        private Animation _animation;
        private Inputs inputH = new Inputs();

        private Rectangle collisionRectangle;
        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            protected set { collisionRectangle = value; }
        }

        public Enemy()
        {
            _animation = new Animation(position, texture);
            _animation.AddAnimatie(6, 0, 0, "left", 32, 40, new Vector2(0, 0));
            _animation.AddAnimatie(6, 42, 0, "right", 32, 30, new Vector2(0, 0));
            _animation.AnimatieAfspelen("right");
            _animation.FramesPerSec = 8;


        }

        public void Draw(SpriteBatch spritebatch)
        {
            _animation.Draw(spritebatch);
        }

        public void laadContent(ContentManager content)
        {
            _animation.LaadContent(content, "enemy");
        }

        public void Update(GameTime gameTime, Map map)
        {
            _animation.Update(gameTime);
            position += _animation.sDirection;

            inputH.update();

            Move();

        }

        private void Move()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.D))
            {
                _animation.AnimatieAfspelen("right");
                _animation.sDirection.X = _animation.speed;
            }
            else if (keyState.IsKeyDown(Keys.Q))
            {
                _animation.AnimatieAfspelen("left");
                _animation.sDirection.X -= _animation.speed;
            }
        }
    }
}
