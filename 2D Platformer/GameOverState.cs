﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace _2D_Platformer
{
    public class GameOverState : _2D_Platformer.State
    {
        bool isLoaded = false;
        SpriteFont font = null;
        KeyboardState oldState;

        public GameOverState() : base()
        {
        }

        public override void Update(ContentManager Content, GameTime gameTime)
        {
            if (isLoaded == false)
            {
                isLoaded = true;
                font = Content.Load<SpriteFont>("Arial");
                oldState = Keyboard.GetState();
            }

            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Enter) == true)
            {
                if (oldState.IsKeyDown(Keys.Enter) == false)
                {
                    _2D_Platformer.StateManager.ChangeState("SPLASH");
                    GameState.score = 0;
                    isLoaded = false;
                }
            }
            oldState = newState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(200, 200), Color.OrangeRed);
            spriteBatch.DrawString(font, "Score : " + GameState.score.ToString(), new Vector2(200, 240), Color.OrangeRed);
            spriteBatch.DrawString(font, "Retry (Enter)", new Vector2(200, 460), Color.OrangeRed);
            spriteBatch.DrawString(font, "Quit (Esc)", new Vector2(450, 460), Color.OrangeRed);
            spriteBatch.End();
        }

        public override void CleanUp()
        {
            font = null;
            isLoaded = false;
        }
    }
}
