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
        GraphicsDeviceManager		graphics;
        SpriteBatch					spriteBatch;
        InputManager				inputManager;
		RenderTarget2D              sceneContents;
        public static Game1 self;
        public static System.TimeSpan totalGameTime;
        Texture2D blood_screen;

        public Game1()
        {
            self = this;

            graphics = new GraphicsDeviceManager(this);
			graphics.HardwareModeSwitch = true;
			graphics.SynchronizeWithVerticalRetrace = true;
			Content.RootDirectory = "Content";
            inputManager = InputManager.Manager;
        }

        public void Quit()
        {
            Exit();
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
			int resolution = 0;
            int sound = 0;
            int music = 0;
            
			foreach(string line in lines)
			{
                Debug.WriteLine(line);
                Regex regexFullscreen = new Regex(@"fullscreen=[0-1]");
				Regex regexResolution = new Regex(@"resolution=[0-9]");
				Regex regexSound = new Regex(@"sound=[0-9]{1,3}");
				Regex regexMusic = new Regex(@"music=[0-9]{1,3}");

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
					resolution = int.Parse(g1.Value.Replace("resolution=", ""));
				}

                MatchCollection soundMatch = regexSound.Matches(line);
                foreach (Match m in soundMatch)
                {
                    Group g1 = m.Groups[0];
                    sound = int.Parse(g1.Value.Replace("sound=", ""));
                }

                MatchCollection musicMatch = regexMusic.Matches(line);
                foreach (Match m in musicMatch)
                {
                    Group g1 = m.Groups[0];
                    music = int.Parse(g1.Value.Replace("music=", ""));
                }
            }

            Util.Statics.soundVolume = Util.Statics.Map((float)sound, 0f, 100f, 0f, 1f);
            Util.Statics.musicVolume = Util.Statics.Map((float)music, 0f, 100f, 0f, 1f);

            if (fullscreen == 1)
				graphics.IsFullScreen = true;

			Vector2 res = Util.Statics.GetResolition(resolution);

			graphics.PreferredBackBufferWidth = (int)res.X;
            graphics.PreferredBackBufferHeight = (int)res.Y;
            graphics.ApplyChanges();

            Graphics.ViewManager.Instance.ScreenSize = resolution;
            IsMouseVisible = true;

			Core.GameManager.Instance.InitializeGame(this, graphics);
			sceneContents = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            float ratio = ((float)graphics.PreferredBackBufferWidth) / ((float)graphics.PreferredBackBufferHeight);
			Graphics.EffectContainer.Instance.GetEffect("LightOff").Parameters["aspectRatio"].SetValue(ratio);

            //Dodawanie aktywnych efektów do renderowania
            //Graphics.ViewManager.Instance.activeEffects.Add(Graphics.EffectContainer.Instance.GetEffect("LightOff"));

            //Graphics.Widget widget = new Graphics.Widget(new Vector2(), new Vector2(1, 0.5f));
            //widget.Texture = Graphics.SpriteContainer.Instance.GetImage("bar");
            //widget.SourceRectangle = new Rectangle(0, 2, 40, 2);

            Graphics.TextWidget textWidget = new Graphics.TextWidget(new Vector2(0.9f, 0.9f), new Vector2(0.1f, 0.1f));
            textWidget.Value = "hellO";

            Graphics.WidgetManager.AddWidget(textWidget);

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
            blood_screen = Content.Load<Texture2D>(@"gfx/Projectiles/BloodScreen");
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
            totalGameTime = gameTime.TotalGameTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Core.GameManager.UpdateScene();
            Core.GameManager.FinalizeSpwaning();
            Graphics.AnimationManager.Instance.Update(gameTime.ElapsedGameTime.TotalSeconds);            

            foreach(Core.GameObject go in Core.SceneManager.Instance.currScene.objects)
            {
                go.Update(gameTime);
            }

            Graphics.EffectContainer.Instance.GetEffect("BloodScreen").Parameters["currTime"].SetValue((float)totalGameTime.TotalSeconds);
            var a = blood_screen;
            //Graphics.EffectContainer.Instance.GetEffect("BloodScreen").Parameters["blood_screen"].SetValue(blood_screen);


            //Debug.WriteLine(xxx);

            PhysicsManager.ResolveAllCollision();
            base.Update(gameTime);
        }

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		/// 
		protected override void Draw(GameTime gameTime)
        {


            Graphics.ViewManager.Instance.Render(spriteBatch, GraphicsDevice, sceneContents);

            Graphics.WidgetManager.Render(spriteBatch, GraphicsDevice);
        }

    }
}
