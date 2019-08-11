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
    public class MenuState : State
    {
        private readonly List<Component> _components;

        readonly GameState  currentState;
        public SpriteFont Font;

        Random rand = new Random();

        string[] RandomGameFacts;
        readonly int RndmGameFactsIndex;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            RandomGameFacts = new string[] { "Hint: if you hit the enemey, you will also lose health!",
                                             "Hint: if you fall in water, your position wil reset and \r\n you wil lose a big amount of health!",
                                             "Hint: If you have over 30 or just 30 coins, \r\n and you finish the last level you win, else you lose!",
                                             "Hint: you lose health and COINS if you get hit by FIREBALL!"};
            RndmGameFactsIndex = rand.Next(RandomGameFacts.Length);

            var buttonTexture = _content.Load<Texture2D>("TestButton");
            var buttonFont = _content.Load<SpriteFont>("Font");

            Font = content.Load<SpriteFont>("Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;


            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };

            currentState = new GameState(game, graphicsDevice, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(Font, "Press Z to Attack", new Vector2(200, 300), Color.Black);
            spriteBatch.DrawString(Font, "Press P to Pause Game", new Vector2(400, 300), Color.Black);
            spriteBatch.DrawString(Font, RandomGameFacts[RndmGameFactsIndex], new Vector2(200, 350), Color.Black);

            spriteBatch.End();
        }

        //Loads New Game
        public void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(currentState);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
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