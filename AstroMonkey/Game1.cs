﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AstroMonkey.Input;

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
            // TODO: Add your initialization logic here
            Core.GameManager.Instance.InitializeGame(this);
            base.Initialize();

            // add interesting buttons. Duplicates are ignored
            //inputManager.AddObservedKey(Keys.W);
            //inputManager.AddObservedKey(Keys.S);

            // hook up events
            //inputManager.OnKeyReleased += TestKey;
            //inputManager.OnMouseMove += TestMouse;
            //inputManager.OnMouseButtonPressed += TestMouse;
            //inputManager.OnMouseButtonReleased += TestMouse;

            // add action binding
            //ActionBinding testBingind = new ActionBinding(Keys.K);
            //inputManager.AddActionBinding("", testBingind);

            // add axis bindings
            //AxisBinding axisBinding = new AxisBinding(Keys.X, Keys.Z);
            //inputManager.AddAxisBinding("", axisBinding);
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

            Graphics.AnimationManager.Instance.Update(gameTime.ElapsedGameTime.TotalSeconds);
            foreach(Core.GameObject go in Core.SceneManager.Instance.currScene.objects)
            {
                go.Update(gameTime);
            }

            // TODO: Add your update logic here

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
            spriteBatch.Begin(SpriteSortMode.Deferred,
                            null, null, null, null, null,
                            Matrix.CreateTranslation(
                                -Graphics.ViewManager.playerTransform.position.X + graphics.PreferredBackBufferWidth / 2,
                                -Graphics.ViewManager.playerTransform.position.Y + graphics.PreferredBackBufferHeight / 2, 0));
            Graphics.ViewManager.Instance.Render(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        protected override void OnExiting(object sender, System.EventArgs args)
        {
            base.OnExiting(sender, args);
            // very fucking important
            inputManager.End();
        }

        private void TestKey(KeyInputEventArgs args)
        {
            System.Console.WriteLine(args);
        }

        private void TestMouse(MouseInputEventArgs args)
        {
            System.Console.WriteLine(args);
        }
    }
}
