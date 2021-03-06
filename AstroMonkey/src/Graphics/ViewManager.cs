﻿using System.Collections.Generic;
using System.Linq;
using AstroMonkey.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Graphics
{
    class ViewManager
    {
        public static ViewManager			Instance { get; private set; } = new ViewManager();
        public List<Core.GameObject>		sprites = new List<Core.GameObject>();
        public List<Core.GameObject>		floor = new List<Core.GameObject>();
		public List<UI.UIElement>			ui = new List<UI.UIElement>();
		private Core.Transform _playerTransform;
        public Core.Transform PlayerTransform {
            get => _playerTransform ?? new Core.Transform();
            set => _playerTransform = value;
        }

		public List<Effect>                 activeEffects = new List<Effect>();

		public GraphicsDeviceManager        graphics;

        public int ScreenSize;

        private Util.ViewComparable vc = new Util.ViewComparable();

        private ViewManager()
        {

        }

		public Vector2 WinSize()
		{
			return new Vector2(Instance.graphics.PreferredBackBufferWidth, Instance.graphics.PreferredBackBufferHeight);
		}

		public void AddSprite(UI.UIElement sprite)
		{
			ui.Add(sprite);
		}

		public void AddSprite(Core.GameObject sprite)
        {
            if(sprite is Assets.Objects.Floor) floor.Add(sprite);
            else
                lock(sprites)
                {
                    sprites.Add(sprite);
                }
        }

		public void RemoveSprite(UI.UIElement sprite)
		{
			ui.Remove(sprite);
		}

        public void RemoveSprite(Core.GameObject sprite)
        {
            floor.RemoveAll( x => x.Equals(sprite));
            sprites.RemoveAll( x => x.Equals(sprite));
        }

        public void Render(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, RenderTarget2D renderTarget2D, RenderTarget2D supportTarget2D)
        {
			graphicsDevice.SetRenderTarget(renderTarget2D);
			graphicsDevice.Clear(Util.Statics.Colors.BLACK);

			spriteBatch.Begin(SpriteSortMode.Deferred,
                            BlendState.AlphaBlend,
                            SamplerState.PointClamp, 
							null, null, null,
							Matrix.CreateTranslation(
                                -PlayerTransform.position.X + spriteBatch.GraphicsDevice.Viewport.Width / 2,
                                -PlayerTransform.position.Y + spriteBatch.GraphicsDevice.Viewport.Height / 2, 0));
            
            
            foreach(Core.GameObject s in floor)
            {
                Sprite sprite = s.GetComponent<Graphics.Sprite>();
                spriteBatch.Draw(
                    sprite.image,
                    new Vector2(
                        s.transform.position.X + sprite.anchor.X * s.transform.scale.X,
                        s.transform.position.Y + sprite.anchor.Y * s.transform.scale.Y),
                    null,
                    sprite.rect[0],
                    new Vector2(
                        sprite.rect[0].Width / 2,
                        sprite.rect[0].Height / 2),
                    s.transform.rotation,
                    s.transform.scale,
                    sprite.color);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred,
                            BlendState.AlphaBlend, 
                            SamplerState.PointClamp,
							null, null, null,
							Matrix.CreateTranslation(
                                -PlayerTransform.position.X + spriteBatch.GraphicsDevice.Viewport.Width / 2,
                                -PlayerTransform.position.Y + spriteBatch.GraphicsDevice.Viewport.Height / 2, 0));

            sprites.Sort(vc);

            foreach(Core.GameObject s in sprites)
            {
                Sprite sprite = s.GetComponent<Graphics.Sprite>();
                for(int i = 0; i < sprite.rect.Count; ++i)
                {
                    spriteBatch.Draw(
                        sprite.image,
                        new Vector2(
                            s.transform.position.X + sprite.anchor.X * s.transform.scale.X,
                            s.transform.position.Y - sprite.stackOffset * i * s.transform.scale.Y + sprite.anchor.Y * s.transform.scale.Y),
                        null,
                        sprite.rect[i],
                        sprite.origin,
                        s.transform.rotation,
                        s.transform.scale,
                        sprite.color);
                }
            }

			ui.Sort();
			foreach(UI.UIElement s in ui)
			{
				s.Draw(spriteBatch, PlayerTransform.position);
			}
#if DRAW_COLLISIONS
            // Rysowanie colliderów
            PhysicsManager.DrawAllColliders(spriteBatch);
#endif
            spriteBatch.End();

			graphicsDevice.SetRenderTarget(null);

			Texture2D result = renderTarget2D;

			if(activeEffects.Count == 0)
			{
				spriteBatch.Begin();
					spriteBatch.Draw(result, Vector2.Zero, Color.White);
				spriteBatch.End();
			}
			else
			{
				List<Texture2D> texureList = new List<Texture2D>();

				//foreach(Effect e in activeEffects)
				//{
                for(int i = 0; i < activeEffects.Count; i++) { 
					spriteBatch.GraphicsDevice.SetRenderTarget(supportTarget2D);
					spriteBatch.GraphicsDevice.Clear(new Color(0, 0, 0, 0));

					spriteBatch.Begin(SpriteSortMode.Texture, effect: activeEffects[i]);
						spriteBatch.Draw(renderTarget2D, new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height), null, Color.White);
					spriteBatch.End();

					Util.Statics.Swap(ref supportTarget2D, ref renderTarget2D);
				}

				spriteBatch.GraphicsDevice.SetRenderTarget(null);

				spriteBatch.Begin(SpriteSortMode.Immediate);
					spriteBatch.Draw(renderTarget2D, new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height), null, Color.White);
				spriteBatch.End();
			}
		}

		void DrawEffect(Texture2D texture, List<RenderTarget2D> targetList)
		{

		}
	}
}
