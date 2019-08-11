using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace A_NewBegining.States
{
    /// <summary>
    /// the gamestate class shows the game in prograss, everything we created in the map class wil be shown after this class is been called
    /// </summary>
    public class GameState : State
    {
        Map map;
        public SpriteFont Font;

        //Everything needed so you can pause the game at playtime
        bool paused;
        Texture2D pausedTexture;
        Rectangle pausedRect;

        private List<Component> _components;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {

            map = new Map(content, graphicsDevice);

            var buttonTexture = _content.Load<Texture2D>("TestButton");
            var buttonFont = _content.Load<SpriteFont>("Font");

            var PlayButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Play",
            };

            PlayButton.Click += Play_Click;

            _components = new List<Component>()
            {
                PlayButton,
            };

            pausedTexture = content.Load<Texture2D>("paused");
            pausedRect = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);

            map.LoadContent(content);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            paused = false;
        }

        public override void Update(GameTime gameTime, ContentManager content)
        {
            foreach (var component in _components)
                component.Update(gameTime);

            //if you didn't klik p, then you can still press it and if you press the game won't update unless you klick play again
            if (!paused)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                    paused = true;

                map.update(gameTime, content);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);

            //pause screen wil come on
            if (paused == true)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(pausedTexture, pausedRect, Color.White);

                foreach (var component in _components)
                    component.Draw(gameTime, spriteBatch);

                spriteBatch.End();
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
            if (map.YouLose == true || map.player.healthBar.CurrentHealth <= 0)
                _game.ChangeState(new GameOverState(_game, _graphicsDevice, _content));

            else if(map.YouWon == true || map.player.healthBar.CurrentHealth <= 0)
                _game.ChangeState(new YouWonState(_game, _graphicsDevice, _content));
        }
    }
}