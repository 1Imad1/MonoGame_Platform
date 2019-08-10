using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using A_NewBegining.States;

namespace A_NewBegining
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D GameBackground;
        Vector2 GameBackgroundPosition;

        private State _currentState;

        private State _nextState;

        //bool paused;
        //Texture2D pausedTexture;
        //Rectangle pausedRect;
        //Button Btnpl, Btnqt;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);

            GameBackground = Content.Load<Texture2D>("BG");
            GameBackgroundPosition = new Vector2(0, 0);

            //pausedTexture = Content.Load<Texture2D>("paused");
            //pausedRect = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if (Keyboard.GetState().IsKeyDown(Keys.B))
            //    paused = true;

            //if (Keyboard.GetState().IsKeyDown(Keys.N))
            //    paused = false
;
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }



            _currentState.Update(gameTime, Content);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(GameBackground, GameBackgroundPosition, Color.White);
            spriteBatch.End();
            
            _currentState.Draw(gameTime, spriteBatch);

            //if (paused == true)
            //{
            //    spriteBatch.Begin();
            //    spriteBatch.Draw(pausedTexture, pausedRect, Color.White);
            //    spriteBatch.End();
            //}

            base.Draw(gameTime);
        }
    }
}
