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
    class Collision
    {
        public Animation _animation;
        public Map map;

        public Collision(Animation animation, Map _map)
        {
            _animation = animation;
            map = _map;
        }

        public Collision() { }

        public void Update(Inputs inputH)
        {
            int y = _animation.BoxRondCharachter.Y;

            foreach (var item in map.CollisionTiles)
                if (item.Rectangle.Intersects(_animation.BoxRondCharachter))
                {
                    if (_animation.BoxRondCharachter.IsTouchingLeftOf(item.Rectangle) && inputH.Right)
                    {
                        _animation.sPosition.X = item.Rectangle.X - 40;
                        Debug.WriteLine("hit left");
                        break;
                    }
                    else if (_animation.BoxRondCharachter.IsTouchingRightOf(item.Rectangle) && inputH.Left)
                    {
                        _animation.sPosition.X = item.Rectangle.X + 60;

                        Debug.WriteLine("hit right");
                        break;
                    }
                    else if (_animation.BoxRondCharachter.IsTouchingBottom(item.Rectangle))
                    {
                        _animation.sDirection.Y = 5;
                        Debug.WriteLine("hit Bottom");
                        break;
                    }
                    else if (_animation.BoxRondCharachter.TouchTopOf(item.Rectangle))
                    {

                        y  = item.Rectangle.Y - item.Rectangle.Height;

                        _animation.sDirection.Y = 0f;
                        Debug.WriteLine("hit top");
                        break;
                    }

                    if (_animation.sPosition.X < 0) _animation.sPosition.X = 0;
                    if (_animation.sPosition.X > map.Width - _animation.BoxRondCharachter.Width) _animation.sPosition.X = map.Width - _animation.BoxRondCharachter.Width;
                    if (_animation.sPosition.Y < 0) _animation.sDirection.Y = 1f;
                    if (_animation.sPosition.Y > map.Height - _animation.BoxRondCharachter.Height) _animation.sPosition.X = map.Height - _animation.BoxRondCharachter.Height;
                }
        }

        public void ColideBetweenPlayers(Rectangle enemy, Rectangle player)
        {
            if (player.Intersects(enemy))
            {
                if (player.IsTouchingLeftOf(enemy))
                {
                    Debug.WriteLine("hit left of enemy");
                }
                else if (player.IsTouchingRightOf(enemy))
                {
                

                    Debug.WriteLine("hit right of enemy");
                }
                else if (player.TouchTopOf(enemy))
                {
                    //_animation.sDirection.Y = f;
                    Debug.WriteLine("hit top of enemy");
                }
            }
        }
    }
}
