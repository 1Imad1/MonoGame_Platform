using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace A_NewBegining.States
{
    /// <summary>
    /// The screen You get when you win the game
    /// </summary>
    class YouWonState : State
    {
        private List<Component> _components;

        MenuState currentState;

        public Texture2D YOUWON;
        public Texture2D YOUWON2Trophie;

        public YouWonState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("TestButton");
            var buttonFont = _content.Load<SpriteFont>("Font");

            YOUWON = content.Load<Texture2D>("YouWon");
            YOUWON2Trophie = content.Load<Texture2D>("YouWon");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Return To Main Menu",
            };

            newGameButton.Click += BackToMenu;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };

            //Menu Will be created and wil be seen at the end of the game IF you win
            currentState = new MenuState(game, graphicsDevice, content);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(YOUWON, new Vector2(20, 50), Color.White);
            spriteBatch.Draw(YOUWON2Trophie, new Vector2(500, 50), Color.White);

            spriteBatch.End();
        }

        /// <summary>
        /// Send You back to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BackToMenu(object sender, EventArgs e)
        {
            _game.ChangeState(currentState);
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime, ContentManager content)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
