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
    public class Hero
    {
        Collision collision;
        public Vector2 position = new Vector2(54, 485);
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

        public bool LinkseStand = false;

        private Rectangle collisionRectangle;
        public Rectangle CollisionRectangle
        {
            get { return collisionRectangle; }
            protected set { collisionRectangle = value; }
        }

        public Hero()
        {
            _animation = new Animation(position, texture);

            _animation.AddAnimatie(4, 0, 0, "RechteIdle", 50, 35, new Vector2(0, 0));
            _animation.AddAnimatie(4, 34, 0, "LinkseIdle", 50, 35, new Vector2(0, 0));
            _animation.AddAnimatie(6, 72, 0, "Right", 50, 34, new Vector2(0, 0));
            _animation.AddAnimatie(6, 107, 0, "Left", 50, 40, new Vector2(0, 0));
            _animation.AddAnimatie(9, 144, 0, "Jump", 46, 41, new Vector2(0, 0));
            _animation.AddAnimatie(4, 220, 0, "Crouch", 50, 32, new Vector2(0, 0));
            _animation.AddAnimatie(7, 255, 0, "FirstAttack", 50, 45, new Vector2(0, 0));
            _animation.AddAnimatie(14, 300, 0, "ComboAttack", 50, 41, new Vector2(0, 0));
            _animation.AddAnimatie(5, 300, 0, "Dood", 50, 41, new Vector2(0, 0));

            _animation.AnimatieAfspelen("RechteIdle");

            _animation.FramesPerSec = 10;


        }

        public void Draw(SpriteBatch spritebatch)
        {
            _animation.Draw(spritebatch);
        }

        public void laadContent(ContentManager content)
        {
            _animation.LaadContent(content, "char");
        }

        public void Update(GameTime gameTime, Map map)
        {
            _animation.Update(gameTime);
            position += _animation.sDirection;

            inputH.update();

            collision = new Collision(_animation, map);

            collision.Update(inputH);
            Move(gameTime);

        }

        private void Move(GameTime gameTime)
        {
            if (inputH.Right)
            {
                _animation.AnimatieAfspelen("Right");
                _animation.sDirection.X = _animation.speed;

                LinkseStand = false;
            }
            else if (inputH.Left)
            {
                _animation.AnimatieAfspelen("Left");
                _animation.sDirection.X -= _animation.speed;

                LinkseStand = true;
            }
            else if (inputH.Up)
            {
                _animation.AnimatieAfspelen("Jump");
                _animation.sDirection.Y -= _animation.speed;
            }
            else if (inputH.NormalAttack)
            {
                _animation.AnimatieAfspelen("FirstAttack");
            }
            else if (inputH.ComboAttack)
            {
                _animation.AnimatieAfspelen("ComboAttack");
            }
            else
            {
                if (LinkseStand == true)
                    _animation.AnimatieAfspelen("LinkseIdle");
                else
                    _animation.AnimatieAfspelen("RechteIdle");
                _animation.sDirection.X = 0f;
            }
        }
    }
}
