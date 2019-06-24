using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Hero
    {
        public Vector2 Positie { get; set; }
        private Texture2D Texture { get; set; }
        private Rectangle _ShowRect;

        private Animation _animation;
        private Inputs inputH = new Inputs();

        public Vector2 VelocityX = new Vector2(2, 0);
        public bool LinkseStand = false;

        public Hero(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;//new Vector2(200, 200);
            _ShowRect = new Rectangle(0, 0, 64, 205);


            _animation = new Animation(Positie);

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

            _animation.FramesPerSec = 8;
        }


        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);

            inputH.update();
            Move();

        }

        private void Move()
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
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            _animation.Draw(spritebatch);
        }

        public void laadContent(ContentManager content)
        {
            _animation.LaadContent(content);
        }
    }
}
