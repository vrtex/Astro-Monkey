using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using AstroMonkey.Physics.Collider;
using AstroMonkey.Core;

namespace AstroMonkey.Assets.Objects
{
    class Banana: Core.GameObject
    {
        private Gameplay.InteractComponent interactComponent;
        private Collider collider;

        public Banana(): this(new Core.Transform())
        {
        }

        public Banana(Core.Transform _transform): base(_transform)
        {
            Load(_transform);
        }

        public Banana(Vector2 position, Vector2 scale, float rotation = 0f): this(new Core.Transform(position, scale, rotation))
        {
        }

        public Banana(Vector2 position): this(new Core.Transform(position, Vector2.One, 0f))
        {
        }

        private int height = 16;
        private int size = 16;

        private void Load(Core.Transform _transform)
        {
            // Physics
            collider = AddComponent(new CircleCollider(this, CollisionChanell.Item, Vector2.Zero, size / 2));
            collider.OnBeginOverlap += CheckCollision;

            interactComponent = AddComponent(new Gameplay.InteractComponent(this));
            interactComponent.OnInteract += InteractHnadler;

            List<Rectangle> idle01 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle01.Add(new Rectangle(i * size, 0, size, size));
            AddComponent(new Graphics.Sprite(this, "banana", idle01));

            AddComponent(new Graphics.StackAnimator(this));

            List<Rectangle> idle02 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle02.Add(new Rectangle(i * size, size, size, size));
            List<Rectangle> idle03 = new List<Rectangle>();
            for(int i = 0; i < height; ++i) idle03.Add(new Rectangle(i * size, size * 2, size, size));
            GetComponent<Graphics.StackAnimator>().AddAnimation(
                new Graphics.StackAnimation("Idle",
                GetComponent<Graphics.Sprite>(),
                new List<List<Rectangle>> { idle01, idle02, idle03, idle02 },
                266,
                true));

            GetComponent<Graphics.StackAnimator>().SetAnimation("Idle");
        }

        private void CheckCollision(Collider thisCollider, Collider otherCollider)
        {
            GameObject other = otherCollider.Parent;
            Player player = other as Player;
            if(player == null)
                return;

            Gameplay.Health health = player.GetComponent<Gameplay.Health>();
            health.Restore(80);
            Destroy();
            
        }

        private void InteractHnadler(Gameplay.InteractComponent interactComponent, Core.GameObject interacting)
        {
            Core.Transform newTransofrm = new Core.Transform(transform);
            newTransofrm.position.X += 100;
            newTransofrm.position.Y += 100;
            Banana newBanana = new Banana(newTransofrm);
            Core.GameManager.SpawnObject(newBanana);
        }

        public override void Destroy()
        {
            interactComponent.OnInteract -= InteractHnadler;
            collider.OnBeginOverlap -= CheckCollision;
            collider.Destroy();
            base.Destroy();
        }
    }
}
