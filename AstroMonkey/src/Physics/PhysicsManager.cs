using System;
using System.Collections.Generic;
using AstroMonkey.Core;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AstroMonkey.Physics
{
    using ColliderEventInfo = Tuple<Collider.Collider, Collider.Collider, ColliderEventType>;
    enum ColliderEventType
    {
        BeginOverlap,
        EndOverlap,
        Block
    }

    public static class PhysicsManager
    {
        private static List<Collider.Collider> colliders = new List<Collider.Collider>();
        static GameObject tempGO = new GameObject(new Transform());
        private static CircleCollider tempCC =
            new CircleCollider(tempGO, CollisionChanell.Object, Vector2.Zero, 1, true);
        private static List<ColliderEventInfo> ColliderEvents = new List<ColliderEventInfo>();


        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public static void AddCollider(Collider.Collider collider)
        {
            lock(colliders)
                colliders.Add(collider);
        }

        public static void RemoveCollider(Collider.Collider collider)
        {
            lock(colliders)
                colliders.Remove(collider);
        }

        /// <summary>
        /// Rysuje wszystkie collidery z listy.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void DrawAllColliders(SpriteBatch spriteBatch)
        {
            lock(colliders)
                colliders.ForEach(c => c.DrawBorder(spriteBatch));
        }

        /// <summary>
        /// Rozwiązuje wszystkie kolizje.
        /// </summary>
        public static void ResolveAllCollision()
        {
            //Debug.WriteLine("RESOLVE");
            lock(colliders)
                colliders.ForEach(c1 =>
                {
                    if (CanMove(c1))
                    {
                        colliders.ForEach(c2 =>
                        {
                            if (!c1.Equals(c2))
                            {
                                CheckColliderType(c1, c2);
                            }
                        });
                    }
                });

            BroadcastEvetns();
        }

        private static void CheckColliderType(Collider.Collider movable, Collider.Collider stable)
        {
            if (IsCircle(movable)) // 1: CIR
            {
                Collider.CircleCollider c1 = (CircleCollider) movable;
                if (IsCircle(stable)) // 2: CIR
                {
                    Collider.CircleCollider c2 = (CircleCollider)stable;
                    ResolveCollision(c1, c2);
                }
                else // 2: REC
                {
                    Collider.BoxCollider c2 = (BoxCollider)stable;
                    ResolveCollision(c1, c2);
                }
                
            }
            else // 1: REC
            {
                Collider.BoxCollider c1 = (BoxCollider)movable;
                if (IsCircle(stable)) // 2: CIR
                {
                    Collider.CircleCollider c2 = (CircleCollider)stable;
                    ResolveCollision(c1, c2);
                }
                else // 2: REC
                {
                    Collider.BoxCollider c2 = (BoxCollider)stable;
                    ResolveCollision(c1, c2);
                }
            }
        }

        private static void ResolveCollision(CircleCollider c1, CircleCollider c2)
        {
            if (GetDistanceBetween(c1, c2) < c1.radius + c2.radius)
            {
                if (IsBlocking(c1, c2))
                {
                    Direction direction = CheckDirection(c1, c2);
                    switch (direction)
                    {
                        case Direction.LEFT:
                        {
                            float c = c1.radius + c2.radius;
                            float x = (float)Math.Sqrt(Math.Pow(c, 2) - 
                                                       Math.Pow(GetAbsolutePositionDifference(c1, c2).Y, 2));
                            c1.SetPosition(new Vector2(c2.GetPosition().X - x, c1.GetPosition().Y));
                            break;
                        }
                        case Direction.RIGHT:
                        {
                            float c = c1.radius + c2.radius;
                            float x = (float) Math.Sqrt(Math.Pow(c, 2) -
                                                        Math.Pow(GetAbsolutePositionDifference(c1, c2).Y, 2));
                            c1.SetPosition(new Vector2(c2.GetPosition().X + x, c1.GetPosition().Y));
                            break;
                        }
                        case Direction.UP:
                        {
                            float c = c1.radius + c2.radius;
                            float y = (float)Math.Sqrt(Math.Pow(c, 2) -
                                                       Math.Pow(GetAbsolutePositionDifference(c1, c2).X, 2));
                            c1.SetPosition(new Vector2(c1.GetPosition().X, c2.GetPosition().Y - y));
                            break;
                        }
                        case Direction.DOWN:
                        {
                            float c = c1.radius + c2.radius;
                            float y = (float)Math.Sqrt(Math.Pow(c, 2) -
                                                       Math.Pow(GetAbsolutePositionDifference(c1, c2).X, 2));
                            c1.SetPosition(new Vector2(c1.GetPosition().X, c2.GetPosition().Y + y));
                            break;
                        }
                    }
                    // Blocking events
                    ColliderEvents.Add(new ColliderEventInfo(c1, c2, ColliderEventType.Block));
                    //c1.OnBlockDetected(c2);
                    //c2.OnBlockDetected(c1);
                }

                if (IsOverlaping(c1, c2))
                {
                    ColliderEvents.Add(new ColliderEventInfo(c1, c2, ColliderEventType.BeginOverlap));

                    //c1.RunOnBeginOverlap(c2);
                    //c2.RunOnBeginOverlap(c1);
                }
            }
            else // jeżeli nie koliduje
            {
                ColliderEvents.Add(new ColliderEventInfo(c1, c2, ColliderEventType.EndOverlap));
                //if(c1.collisons.Contains(c2))
                //    c1.RunOnEndOverlap(c2);
                //if(c2.collisons.Contains(c1))
                //    c2.RunOnEndOverlap(c1);
            }

            
        }

        private static void ResolveCollision(CircleCollider c1, BoxCollider c2)
        {
            float pointX = MathHelper.Clamp(
                c1.GetPosition().X,
                c2.GetPosition().X - c2.width / 2,
                c2.GetPosition().X + c2.width / 2);

            float pointY = MathHelper.Clamp(
                c1.GetPosition().Y,
                c2.GetPosition().Y - c2.height / 2,
                c2.GetPosition().Y + c2.height / 2);

            Vector2 point = new Vector2(pointX, pointY);

            // hacki soł macz
            tempGO.transform.position = point;
            tempCC.SetCollisionChanell(c2.GetCollisionChanell());
            ResolveCollision(c1, tempCC);
        }

        

        private static void ResolveCollision(BoxCollider c2, CircleCollider c1)
        {
            
        }

        private static void ResolveCollision(BoxCollider c1, BoxCollider c2)
        {

        }

        /// <summary>
        /// Mówi po której stronie jest collider c1 względem collidera c2.
        /// </summary>
        public static Direction CheckDirection(Collider.Collider c1, Collider.Collider c2)
        {
            Vector2 absPos = GetAbsolutePositionDifference(c1, c2);
            Vector2 relPos = GetRelativePositionDifference(c1, c2);
            if (absPos.X > absPos.Y) // LEFT || RIGHT
            {
                if (relPos.X < 0) // LEFT
                {
                    return Direction.LEFT;
                }
                else // RIGHT
                {
                    return Direction.RIGHT;
                }
            }
            else // UP || DOWN gdzie jest obiekt, którym poruszamy względem tego statycznego.
            {
                if (relPos.Y < 0) // UP
                {
                    return Direction.UP;
                }
                else // DOWN
                {
                    return Direction.DOWN;
                }
            }
        }

        /// <summary>
        /// Zwraca odległość między dwoma colliderami.
        /// </summary>
        public static float GetDistanceBetween(Collider.Collider c1, Collider.Collider c2)
        {
            return (float)Math.Sqrt(Math.Pow(c1.GetPosition().X - c2.GetPosition().X, 2) +
                                    Math.Pow(c1.GetPosition().Y - c2.GetPosition().Y, 2));
        }

        /// <summary>
        /// Zwraca wektor różnicy odległości między colliderem pierwszym, a drugim. Odległości mogą być ujemne. c1 - c2
        /// </summary>
        public static Vector2 GetRelativePositionDifference(Collider.Collider c1, Collider.Collider c2)
        {
            return new Vector2(c1.GetPosition().X - c2.GetPosition().X,
                               c1.GetPosition().Y - c2.GetPosition().Y);
        }

        /// <summary>
        /// Zwraca wektor odległości między dwoma colliderami. Odległości są bezwzględne
        /// </summary>
        public static Vector2 GetAbsolutePositionDifference(Collider.Collider c1, Collider.Collider c2)
        {
            return new Vector2(
                MathHelper.Distance(
                    c1.GetPosition().X,
                    c2.GetPosition().X),
                MathHelper.Distance(
                    c1.GetPosition().Y,
                    c2.GetPosition().Y));
        }

        /// <summary>
        /// Sprawdza, czy dany collider ma ciało i ustawioną opcję, że może się poruszać.
        /// </summary>
        public static bool CanMove(Collider.Collider collider)
        {
            var body = collider.Parent.GetComponent<Body>();
            if(body == null)
                return false;
            return body.movable;
        }

        /// <summary>
        /// Sprawdza, czy dany collider jest kołem.
        /// </summary>
        public static bool IsCircle(Collider.Collider collider)
        {
            return collider.GetType() == typeof(Collider.CircleCollider);
        }

        /// <summary>
        /// Sprawdza, czy dany collider jest prostokątem.
        /// </summary>
        public static bool IsRectangle(Collider.Collider collider)
        {
            return collider.GetType() == typeof(Collider.BoxCollider);
        }

        /// <summary>
        /// Sprawdza, czy dane collidery blokują się ze sobą.
        /// </summary>
        public static bool IsBlocking(Collider.Collider c1, Collider.Collider c2)
        {
            bool reaction1 = c1.GetReaction(c2.GetCollisionChanell()).Equals(ReactType.Block);
            bool reaction2 = c2.GetReaction(c1.GetCollisionChanell()).Equals(ReactType.Block);
            return (reaction1 == reaction2) && reaction1;
        }

        /// <summary>
        /// Sprawdza, czy dane collidery reagują na najechanie na siebie.
        /// </summary>
        public static bool IsOverlaping(Collider.Collider c1, Collider.Collider c2)
        {
            return !IsBlocking(c1, c2) && !IsIgnoring(c1, c2);
        }

        public static bool IsIgnoring(Collider.Collider c1, Collider.Collider c2)
        {
            ReactType reaction1 = c1.GetReaction(c2.GetCollisionChanell());
            ReactType reaction2 = c2.GetReaction(c1.GetCollisionChanell());

            return reaction1 == ReactType.Ignore || reaction2 == ReactType.Ignore;
        }

        private static void BroadcastEvetns()
        {
            foreach(ColliderEventInfo info in ColliderEvents)
            {
                switch(info.Item3)
                {
                    case ColliderEventType.EndOverlap:
                        info.Item1.RunOnEndOverlap(info.Item2);
                        info.Item2.RunOnEndOverlap(info.Item1);
                        break;
                    case ColliderEventType.BeginOverlap:
                        info.Item1.RunOnBeginOverlap(info.Item2);
                        info.Item2.RunOnBeginOverlap(info.Item1);
                        break;
                    case ColliderEventType.Block:
                        info.Item1.OnBlockDetected(info.Item2);
                        info.Item2.OnBlockDetected(info.Item1);
                        break;
                }

            }

            ColliderEvents.Clear();
        }
    }
}