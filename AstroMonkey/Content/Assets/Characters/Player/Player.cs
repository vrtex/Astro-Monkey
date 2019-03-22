using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace AstroMonkey.Assets.Objects
{
    class Player: Core.GameObject
    {
        public Audio.AudioSource testSource;

        public Player(): this(new Core.Transform())
        {
        }
        public Player(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }
        public Player(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }
        public Player(Vector2 position): this(new Core.Transform(position, Vector2.One))
        {
        }

        private void Load(Core.Transform _transform)
        {
            AddComponent(new Navigation.MovementComponent(this));
            AddComponent(new Input.InputCompoent(this));
            testSource = (Audio.AudioSource)AddComponent(new Audio.AudioSource(this, Audio.SoundContainer.Instance.GetSoundEffect("test")));

            AddComponent(new Graphics.Sprite(this, "monkey", new List<Rectangle> {
                new Rectangle(0, 0, 21, 21),
                new Rectangle(21, 0, 21, 21),
                new Rectangle(42, 0, 21, 21),
                new Rectangle(63, 0, 21, 21),
                new Rectangle(84, 0, 21, 21),
                new Rectangle(105, 0, 21, 21),
                new Rectangle(126, 0, 21, 21),
                new Rectangle(147, 0, 21, 21),
                new Rectangle(168, 0, 21, 21),
                new Rectangle(189, 0, 21, 21),
                new Rectangle(210, 0, 21, 21),
                new Rectangle(231, 0, 21, 21),
                new Rectangle(252, 0, 21, 21),
                new Rectangle(273, 0, 21, 21),
                new Rectangle(294, 0, 21, 21),
                new Rectangle(315, 0, 21, 21),
                new Rectangle(336, 0, 21, 21),
                new Rectangle(357, 0, 21, 21),
                new Rectangle(378, 0, 21, 21),
                new Rectangle(399, 0, 21, 21),
                new Rectangle(420, 0, 21, 21)}));

            AddComponent(new Graphics.StackAnimator(this));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Idle",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
                        new List<Rectangle> {
                            new Rectangle(0, 0, 21, 21),
                            new Rectangle(21, 0, 21, 21),
                            new Rectangle(42, 0, 21, 21),
                            new Rectangle(63, 0, 21, 21),
                            new Rectangle(84, 0, 21, 21),
                            new Rectangle(105, 0, 21, 21),
                            new Rectangle(126, 0, 21, 21),
                            new Rectangle(147, 0, 21, 21),
                            new Rectangle(168, 0, 21, 21),
                            new Rectangle(189, 0, 21, 21),
                            new Rectangle(210, 0, 21, 21),
                            new Rectangle(231, 0, 21, 21),
                            new Rectangle(252, 0, 21, 21),
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 21, 21, 21),
                            new Rectangle(21, 21, 21, 21),
                            new Rectangle(42, 21, 21, 21),
                            new Rectangle(63, 21, 21, 21),
                            new Rectangle(84, 21, 21, 21),
                            new Rectangle(105, 21, 21, 21),
                            new Rectangle(126, 21, 21, 21),
                            new Rectangle(147, 21, 21, 21),
                            new Rectangle(168, 21, 21, 21),
                            new Rectangle(189, 21, 21, 21),
                            new Rectangle(210, 21, 21, 21),
                            new Rectangle(231, 21, 21, 21),
                            new Rectangle(252, 21, 21, 21),
                            new Rectangle(273, 21, 21, 21),
                            new Rectangle(294, 21, 21, 21),
                            new Rectangle(315, 21, 21, 21),
                            new Rectangle(336, 21, 21, 21),
                            new Rectangle(357, 21, 21, 21),
                            new Rectangle(378, 21, 21, 21),
                            new Rectangle(399, 21, 21, 21),
                            new Rectangle(420, 21, 21, 21),
                        }},
                    266,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Walk",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
                        new List<Rectangle> {
                            new Rectangle(0, 63, 21, 21),
                            new Rectangle(21, 63, 21, 21),
                            new Rectangle(42, 63, 21, 21),
                            new Rectangle(63, 63, 21, 21),
                            new Rectangle(84, 63, 21, 21),
                            new Rectangle(105, 63, 21, 21),
                            new Rectangle(126, 63, 21, 21),
                            new Rectangle(147, 63, 21, 21),
                            new Rectangle(168, 63, 21, 21),
                            new Rectangle(189, 63, 21, 21),
                            new Rectangle(210, 63, 21, 21),
                            new Rectangle(231, 63, 21, 21),
                            new Rectangle(252, 63, 21, 21),
                            new Rectangle(273, 63, 21, 21),
                            new Rectangle(294, 63, 21, 21),
                            new Rectangle(315, 63, 21, 21),
                            new Rectangle(336, 63, 21, 21),
                            new Rectangle(357, 63, 21, 21),
                            new Rectangle(378, 63, 21, 21),
                            new Rectangle(399, 63, 21, 21),
                            new Rectangle(420, 63, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 0, 21, 21),
                            new Rectangle(21, 0, 21, 21),
                            new Rectangle(42, 0, 21, 21),
                            new Rectangle(63, 0, 21, 21),
                            new Rectangle(84, 0, 21, 21),
                            new Rectangle(105, 0, 21, 21),
                            new Rectangle(126, 0, 21, 21),
                            new Rectangle(147, 0, 21, 21),
                            new Rectangle(168, 0, 21, 21),
                            new Rectangle(189, 0, 21, 21),
                            new Rectangle(210, 0, 21, 21),
                            new Rectangle(231, 0, 21, 21),
                            new Rectangle(252, 0, 21, 21),
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 42, 21, 21),
                            new Rectangle(21, 42, 21, 21),
                            new Rectangle(42, 42, 21, 21),
                            new Rectangle(63, 42, 21, 21),
                            new Rectangle(84, 42, 21, 21),
                            new Rectangle(105, 42, 21, 21),
                            new Rectangle(126, 42, 21, 21),
                            new Rectangle(147, 42, 21, 21),
                            new Rectangle(168, 42, 21, 21),
                            new Rectangle(189, 42, 21, 21),
                            new Rectangle(210, 42, 21, 21),
                            new Rectangle(231, 42, 21, 21),
                            new Rectangle(252, 42, 21, 21),
                            new Rectangle(273, 42, 21, 21),
                            new Rectangle(294, 42, 21, 21),
                            new Rectangle(315, 42, 21, 21),
                            new Rectangle(336, 42, 21, 21),
                            new Rectangle(357, 42, 21, 21),
                            new Rectangle(378, 42, 21, 21),
                            new Rectangle(399, 42, 21, 21),
                            new Rectangle(420, 42, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 0, 21, 21),
                            new Rectangle(21, 0, 21, 21),
                            new Rectangle(42, 0, 21, 21),
                            new Rectangle(63, 0, 21, 21),
                            new Rectangle(84, 0, 21, 21),
                            new Rectangle(105, 0, 21, 21),
                            new Rectangle(126, 0, 21, 21),
                            new Rectangle(147, 0, 21, 21),
                            new Rectangle(168, 0, 21, 21),
                            new Rectangle(189, 0, 21, 21),
                            new Rectangle(210, 0, 21, 21),
                            new Rectangle(231, 0, 21, 21),
                            new Rectangle(252, 0, 21, 21),
                            new Rectangle(273, 0, 21, 21),
                            new Rectangle(294, 0, 21, 21),
                            new Rectangle(315, 0, 21, 21),
                            new Rectangle(336, 0, 21, 21),
                            new Rectangle(357, 0, 21, 21),
                            new Rectangle(378, 0, 21, 21),
                            new Rectangle(399, 0, 21, 21),
                            new Rectangle(420, 0, 21, 21),
                        },},
                    216,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Hold",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
                        new List<Rectangle> {
                            new Rectangle(0, 84, 21, 21),
                            new Rectangle(21, 84, 21, 21),
                            new Rectangle(42, 84, 21, 21),
                            new Rectangle(63, 84, 21, 21),
                            new Rectangle(84, 84, 21, 21),
                            new Rectangle(105, 84, 21, 21),
                            new Rectangle(126, 84, 21, 21),
                            new Rectangle(147, 84, 21, 21),
                            new Rectangle(168, 84, 21, 21),
                            new Rectangle(189, 84, 21, 21),
                            new Rectangle(210, 84, 21, 21),
                            new Rectangle(231, 84, 21, 21),
                            new Rectangle(252, 84, 21, 21),
                            new Rectangle(273, 84, 21, 21),
                            new Rectangle(294, 84, 21, 21),
                            new Rectangle(315, 84, 21, 21),
                            new Rectangle(336, 84, 21, 21),
                            new Rectangle(357, 84, 21, 21),
                            new Rectangle(378, 84, 21, 21),
                            new Rectangle(399, 84, 21, 21),
                            new Rectangle(420, 84, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 105, 21, 21),
                            new Rectangle(21, 105, 21, 21),
                            new Rectangle(42, 105, 21, 21),
                            new Rectangle(63, 105, 21, 21),
                            new Rectangle(84, 105, 21, 21),
                            new Rectangle(105, 105, 21, 21),
                            new Rectangle(126, 105, 21, 21),
                            new Rectangle(147, 105, 21, 21),
                            new Rectangle(168, 105, 21, 21),
                            new Rectangle(189, 105, 21, 21),
                            new Rectangle(210, 105, 21, 21),
                            new Rectangle(231, 105, 21, 21),
                            new Rectangle(252, 105, 21, 21),
                            new Rectangle(273, 105, 21, 21),
                            new Rectangle(294, 105, 21, 21),
                            new Rectangle(315, 105, 21, 21),
                            new Rectangle(336, 105, 21, 21),
                            new Rectangle(357, 105, 21, 21),
                            new Rectangle(378, 105, 21, 21),
                            new Rectangle(399, 105, 21, 21),
                            new Rectangle(420, 105, 21, 21),
                        }},
                    266,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("HoldWalk",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
                        new List<Rectangle> {
                            new Rectangle(0, 84, 21, 21),
                            new Rectangle(21, 84, 21, 21),
                            new Rectangle(42, 84, 21, 21),
                            new Rectangle(63, 84, 21, 21),
                            new Rectangle(84, 84, 21, 21),
                            new Rectangle(105, 84, 21, 21),
                            new Rectangle(126, 84, 21, 21),
                            new Rectangle(147, 84, 21, 21),
                            new Rectangle(168, 84, 21, 21),
                            new Rectangle(189, 84, 21, 21),
                            new Rectangle(210, 84, 21, 21),
                            new Rectangle(231, 84, 21, 21),
                            new Rectangle(252, 84, 21, 21),
                            new Rectangle(273, 84, 21, 21),
                            new Rectangle(294, 84, 21, 21),
                            new Rectangle(315, 84, 21, 21),
                            new Rectangle(336, 84, 21, 21),
                            new Rectangle(357, 84, 21, 21),
                            new Rectangle(378, 84, 21, 21),
                            new Rectangle(399, 84, 21, 21),
                            new Rectangle(420, 84, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 126, 21, 21),
                            new Rectangle(21, 126, 21, 21),
                            new Rectangle(42, 126, 21, 21),
                            new Rectangle(63, 126, 21, 21),
                            new Rectangle(84, 126, 21, 21),
                            new Rectangle(105, 126, 21, 21),
                            new Rectangle(126, 126, 21, 21),
                            new Rectangle(147, 126, 21, 21),
                            new Rectangle(168, 126, 21, 21),
                            new Rectangle(189, 126, 21, 21),
                            new Rectangle(210, 126, 21, 21),
                            new Rectangle(231, 126, 21, 21),
                            new Rectangle(252, 126, 21, 21),
                            new Rectangle(273, 126, 21, 21),
                            new Rectangle(294, 126, 21, 21),
                            new Rectangle(315, 126, 21, 21),
                            new Rectangle(336, 126, 21, 21),
                            new Rectangle(357, 126, 21, 21),
                            new Rectangle(378, 126, 21, 21),
                            new Rectangle(399, 126, 21, 21),
                            new Rectangle(420, 126, 21, 21),
                        },
                    new List<Rectangle> {
                            new Rectangle(0, 84, 21, 21),
                            new Rectangle(21, 84, 21, 21),
                            new Rectangle(42, 84, 21, 21),
                            new Rectangle(63, 84, 21, 21),
                            new Rectangle(84, 84, 21, 21),
                            new Rectangle(105, 84, 21, 21),
                            new Rectangle(126, 84, 21, 21),
                            new Rectangle(147, 84, 21, 21),
                            new Rectangle(168, 84, 21, 21),
                            new Rectangle(189, 84, 21, 21),
                            new Rectangle(210, 84, 21, 21),
                            new Rectangle(231, 84, 21, 21),
                            new Rectangle(252, 84, 21, 21),
                            new Rectangle(273, 84, 21, 21),
                            new Rectangle(294, 84, 21, 21),
                            new Rectangle(315, 84, 21, 21),
                            new Rectangle(336, 84, 21, 21),
                            new Rectangle(357, 84, 21, 21),
                            new Rectangle(378, 84, 21, 21),
                            new Rectangle(399, 84, 21, 21),
                            new Rectangle(420, 84, 21, 21),
                        },
                        new List<Rectangle> {
                            new Rectangle(0, 147, 21, 21),
                            new Rectangle(21, 147, 21, 21),
                            new Rectangle(42, 147, 21, 21),
                            new Rectangle(63, 147, 21, 21),
                            new Rectangle(84, 147, 21, 21),
                            new Rectangle(105, 147, 21, 21),
                            new Rectangle(126, 147, 21, 21),
                            new Rectangle(147, 147, 21, 21),
                            new Rectangle(168, 147, 21, 21),
                            new Rectangle(189, 147, 21, 21),
                            new Rectangle(210, 147, 21, 21),
                            new Rectangle(231, 147, 21, 21),
                            new Rectangle(252, 147, 21, 21),
                            new Rectangle(273, 147, 21, 21),
                            new Rectangle(294, 147, 21, 21),
                            new Rectangle(315, 147, 21, 21),
                            new Rectangle(336, 147, 21, 21),
                            new Rectangle(357, 147, 21, 21),
                            new Rectangle(378, 147, 21, 21),
                            new Rectangle(399, 147, 21, 21),
                            new Rectangle(420, 147, 21, 21),
                        }},
                    266,
                    true));

            GetComponent<Graphics.StackAnimator>().AddAnimation(
                    new Graphics.StackAnimation("Dead",
                    GetComponent<Graphics.Sprite>(),
                    new List<List<Rectangle>> {
                        new List<Rectangle> {
                            new Rectangle(0, 168, 21, 21),
                            new Rectangle(21, 168, 21, 21),
                            new Rectangle(42, 168, 21, 21),
                            new Rectangle(63, 168, 21, 21),
                            new Rectangle(84, 168, 21, 21),
                            new Rectangle(105, 168, 21, 21),
                            new Rectangle(126, 168, 21, 21),
                            new Rectangle(147, 168, 21, 21),
                            new Rectangle(168, 168, 21, 21),
                            new Rectangle(189, 168, 21, 21),
                            new Rectangle(210, 168, 21, 21),
                            new Rectangle(231, 168, 21, 21),
                            new Rectangle(252, 168, 21, 21),
                            new Rectangle(273, 168, 21, 21),
                            new Rectangle(294, 168, 21, 21),
                            new Rectangle(315, 168, 21, 21),
                            new Rectangle(336, 168, 21, 21),
                            new Rectangle(357, 168, 21, 21),
                            new Rectangle(378, 168, 21, 21),
                            new Rectangle(399, 168, 21, 21),
                            new Rectangle(420, 168, 21, 21),
                        },
                    new List<Rectangle> {
                            new Rectangle(0, 189, 21, 21),
                            new Rectangle(21, 189, 21, 21),
                            new Rectangle(42, 189, 21, 21),
                            new Rectangle(63, 189, 21, 21),
                            new Rectangle(84, 189, 21, 21),
                            new Rectangle(105, 189, 21, 21),
                            new Rectangle(126, 189, 21, 21),
                            new Rectangle(147, 189, 21, 21),
                            new Rectangle(168, 189, 21, 21),
                            new Rectangle(189, 189, 21, 21),
                            new Rectangle(210, 189, 21, 21),
                            new Rectangle(231, 189, 21, 21),
                            new Rectangle(252, 189, 21, 21),
                            new Rectangle(273, 189, 21, 21),
                            new Rectangle(294, 189, 21, 21),
                            new Rectangle(315, 189, 21, 21),
                            new Rectangle(336, 189, 21, 21),
                            new Rectangle(357, 189, 21, 21),
                            new Rectangle(378, 189, 21, 21),
                            new Rectangle(399, 189, 21, 21),
                            new Rectangle(420, 189, 21, 21),
                        }},
                    298,
                    false));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Hold");
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var c in components)
                c.Update(gameTime);

            // move this mess somewhere else. Or don't I don't care
            Vector2 currVel = GetComponent<Navigation.MovementComponent>().CurrentVelocity;
            if(Util.Statics.IsNearlyEqual(currVel.Length(), 0, 0.001))
            {
                GetComponent<Graphics.AnimatorContainer>().SetAnimation("Hold");
            }
            else
            {
                transform.rotation = (float)Math.PI * 0.5f + GetComponent<Navigation.MovementComponent>().CurrentDirection;
                GetComponent<Graphics.AnimatorContainer>().SetAnimation("HoldWalk");
            }
        }
    }
}
