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

namespace A_NewBegining
{
    class States
    {

        Map map;

        //Background textures for the various screens in the game
        Texture2D mControllerDetectScreenBackground;
        Texture2D mTitleScreenBackground;

        //Screen State variables to indicate what is the current screen
        public bool mIsControllerDetectScreenShown;
        public bool mIsTitleScreenShown;

        public void LoadContent(ContentManager Content, GraphicsDevice graphics)
        {
            //Load the screen backgrounds
            mControllerDetectScreenBackground = Content.Load<Texture2D>("Tile1");
            mTitleScreenBackground = Content.Load<Texture2D>("Tile5");

            map = new Map(Content, graphics);

            map.LoadContent(Content);



            //Initialize the screen state variables
            mIsTitleScreenShown = false;
            mIsControllerDetectScreenShown = true;

        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            if (mIsControllerDetectScreenShown)
            {
                UpdateControllerDetectScreen();
                map.Unload();

            }
            else if (mIsTitleScreenShown)
            {
                UpdateTitleScreen();
                map.Unload();
                map.level_two(content);
            }
        }

        private void UpdateControllerDetectScreen()
        {
            //Poll all the gamepads (and the keyboard) to check to see
            //which controller will be the player one controller
            for (int aPlayer = 0; aPlayer < 4; aPlayer++)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
                {
                    mIsTitleScreenShown = true;
                    mIsControllerDetectScreenShown = false;
                    return;
                }
            }
        }

        private void UpdateTitleScreen()
        {
            //Move back to the Controller detect screen if the player moves
            //back (using B) from the Title screen (this is typical game behavior
            //and is used to switch to a new player one controller)
            if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                mIsTitleScreenShown = false;
                mIsControllerDetectScreenShown = true;
                return;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            //Based on the screen state variables, call the
            //Draw method associated with the current screen
            if (mIsControllerDetectScreenShown)
            {
                DrawControllerDetectScreen(spriteBatch);
            }
            else if (mIsTitleScreenShown)
            {
                DrawTitleScreen(spriteBatch);
            }

            //spriteBatch.End();
        }

        private void DrawControllerDetectScreen(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
        }

        private void DrawTitleScreen(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
        }
    }
}
