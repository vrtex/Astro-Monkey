using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using AstroMonkey.Physics.Collider;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Physics
{
    public static class PhysicsManager
    {
        private static List<Collider.Collider> colliders = new List<Collider.Collider>();

        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public static void AddCollider(Collider.Collider collider)
        {
            colliders.Add(collider);
        }

        public static void RemoveCollider(Collider.Collider collider)
        {
            colliders.Remove(collider);
        }

        /// <summary>
        /// Rozwiązuje wszystkie kolizje.
        /// </summary>
        public static void ResolveAllCollision()
        {
            colliders.ForEach(c1 =>
            {
                if (CanMove(c1))
                {
                    colliders.ForEach(c2 =>
                    {
                        CheckColliderType(c1, c2);
                    });
                }
            });
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
            if (c1.radius + c2.radius < GetDistanceBetween(c1, c2))
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
                }

                if (IsOverlaping(c1, c2))
                {

                }
            }
        }

        private static void ResolveCollision(CircleCollider c1, BoxCollider c2)
        {

        }

        private static void ResolveCollision(BoxCollider c1, CircleCollider c2)
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
            return collider.Parent.GetComponent<Body>() != null && collider.Parent.GetComponent<Body>().movable;
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
            return c1.GetReaction(c2.GetCollisionChanell()).Equals(ReactType.Block);
        }

        /// <summary>
        /// Sprawdza, czy dane collidery reagują na najechanie na siebie.
        /// </summary>
        public static bool IsOverlaping(Collider.Collider c1, Collider.Collider c2)
        {
            return c1.GetReaction(c2.GetCollisionChanell()).Equals(ReactType.Overlap);
        }
    }
}