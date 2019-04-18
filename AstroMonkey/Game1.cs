using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AstroMonkey.Input;
using AstroMonkey.Physics;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AstroMonkey
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputManager inputManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
			graphics.HardwareModeSwitch = true;
			graphics.SynchronizeWithVerticalRetrace = true;
			Content.RootDirectory = "Content";
            inputManager = InputManager.Manager;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			string[] lines = File.ReadAllLines("Content/settings/settings.ini");
			int fullscreen = 0;
			int resorution = 0;
			foreach(string line in lines)
			{
				Regex regexFullscreen = new Regex(@"fullscreen=[0-1]");
				Regex regexResolution = new Regex(@"resolution=[0-9]");
				MatchCollection fullscreenMatch = regexFullscreen.Matches(line);
				foreach(Match m in fullscreenMatch)
				{
					Group g1 = m.Groups[0];
					fullscreen = int.Parse(g1.Value.Replace("fullscreen=", ""));
				}
				MatchCollection resolutionMatch = regexResolution.Matches(line);
				foreach(Match m in resolutionMatch)
				{
					Group g1 = m.Groups[0];
					resorution = int.Parse(g1.Value.Replace("resolution=", ""));
				}
			}

			if(fullscreen == 1)
				graphics.IsFullScreen = true;

			Vector2 res = Util.Statics.GetResolition(resorution);

			graphics.PreferredBackBufferWidth = (int)res.X;
            graphics.PreferredBackBufferHeight = (int)res.Y;
            graphics.ApplyChanges();

            Graphics.ViewManager.Instance.ScreenSize = resorution;
            IsMouseVisible = true;

			Core.GameManager.Instance.InitializeGame(this, graphics);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Core.GameManager.UpdateScene();
            Core.GameManager.FinalizeSpwaning();
            Graphics.AnimationManager.Instance.Update(gameTime.ElapsedGameTime.TotalSeconds);
            foreach(Core.GameObject go in Core.SceneManager.Instance.currScene.objects)
            {
                go.Update(gameTime);
            }


            PhysicsManager.ResolveAllCollision();
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
            Graphics.ViewManager.Instance.Render(spriteBatch);

            base.Draw(gameTime);
        }

    }
}
