﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        

        Graphics.SpriteContainer spriteContainer;
        Core.GameObject             testGameObject;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            inputManager = InputManager.manager;
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
            Graphics.SpriteContainer.Instance.LoadTextures(this);
            testGameObject = new Core.GameObject();
            testGameObject.AddComponent(new Graphics.Sprite(testGameObject, "enemy", new Util.Rect(0, 0, 32, 32)));
            System.Console.WriteLine(testGameObject.GetComponents<Graphics.Sprite>().Count);
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw((testGameObject.Components[0] as Graphics.Sprite).image, testGameObject.transform.position, Color.Wheat);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void TestKey(KeyInputEventArgs args)
        {
            System.Console.WriteLine(args);
        }

        private void TestMouse(MouseInputEventArgs args)
        {
            System.Console.WriteLine(args);
        }

        protected override void OnExiting(object sender, System.EventArgs args)
        {
            // very fucking important
            inputManager.End();
        }
    }
}
