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
    public class GameState : State
    {
        Map map;
        public SpriteFont Font;

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
            if(map.Ending == true || map.player.Health <= 0)
                _game.ChangeState(new GameOverState(_game, _graphicsDevice, _content));
        }

        public void load(ContentManager content)
        {

        }
    }
}