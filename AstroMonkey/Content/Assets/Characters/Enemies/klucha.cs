using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Assets.Objects
{
    class Klucha: Core.GameObject
    {
        public Klucha()
        {
            Load(new Core.Transform(Vector2.Zero, Vector2.One, 0f));
        }
        public Klucha(Core.Transform _transform)
        {
            Load(_transform);
        }
        public Klucha(Vector2 position, Vector2 scale, float rotation = 0f)
        {
            Load(new Core.Transform(position, scale, rotation));
        }
        public Klucha(Vector2 position)
        {
            Load(new Core.Transform(position, Vector2.One, 0f));
        }

        private void Load(Core.Transform _transform)
        {
            transform = _transform;
            AddComponent(new Graphics.Sprite(this, "enemy", new Rectangle(32, 32, 32, 32)));
            AddComponent(new Graphics.Animator(this));

            //dodawanie animacji
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkUp",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 0, 32, 32),
                        new Rectangle(32, 0, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkRight",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 32, 32, 32),
                        new Rectangle(32, 32, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkDown",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 64, 32, 32),
                        new Rectangle(32, 64, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("IdleLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32)},
                    215,
                    false));
            GetComponent<Graphics.Animator>().AddAnimation(
                    new Graphics.Animation("WalkLeft",
                    GetComponent<Graphics.Sprite>(),
                    new List<Rectangle> {
                        new Rectangle(0, 96, 32, 32),
                        new Rectangle(32, 96, 32, 32)},
                    215,
                    true));
            GetComponent<Graphics.Animator>().SetAnimation("IdleDown");
        }
    }
}
