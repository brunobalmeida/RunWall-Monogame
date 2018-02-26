﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RunWall
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private StartScene startScene;
        private ActionScene actionScene;
        private CreditScene creditScene;
        private HighScoreScene highScoreScene;
        private HelpScene helpScene;
        private Song song;
        EndGameScene endGameScene;
        HowToPlayScene howToPlay;
        SpriteFont font;
        SpriteFont regularFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);




            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            Texture2D startTex = this.Content.Load<Texture2D>("Images/startScene");

            font = this.Content.Load<SpriteFont>("Fonts/titleFont");
            regularFont = this.Content.Load<SpriteFont>("Fonts/regularFont");


            //Code to add the scenes 
            startScene = new StartScene(this, startTex);
            this.Components.Add(startScene);
            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);
            creditScene = new CreditScene(this);
            this.Components.Add(creditScene);
            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);
            endGameScene = new EndGameScene(this, font);
            this.Components.Add(endGameScene);
            howToPlay = new HowToPlayScene(this);
            this.Components.Add(howToPlay);
            highScoreScene = new HighScoreScene(this, regularFont);
            this.Components.Add(highScoreScene);

            startScene.Show();
            song = this.Content.Load<Song>("Sounds/soundTrack");
            MediaPlayer.Play(song);
            

        }

        public void HideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.Hide();
                }
            }
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    actionScene.Show();
                    MediaPlayer.Stop();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    howToPlay.Show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    highScoreScene.Show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.Show();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    creditScene.Show();
                }
                else if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }

            }

            if (actionScene.Enabled )
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.Show();
                    MediaPlayer.Play(song);
                }
            }

            if (helpScene.Enabled || creditScene.Enabled || highScoreScene.Enabled || howToPlay.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.Show();
                }
            }
            if (endGameScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    Shared.score = 0;
                    HideAllScenes();
                    highScoreScene.Show();
                }
            }

            if (Shared.gameIsOver)
            {
                highScoreScene.SaveHighScore();
                highScoreScene.LoadHighScore();
                HideAllScenes();
                endGameScene.Show();
                Shared.gameIsOver = false;
                actionScene.Restart();
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
