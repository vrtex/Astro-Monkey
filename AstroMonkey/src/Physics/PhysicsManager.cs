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

        public static void AddCollider(Collider.Collider collider)
        {
            colliders.Add(collider);
        }

        public static void RemoveCollider(Collider.Collider collider)
        {
            colliders.Remove(collider);
        }

        public static void CheckAllCollision()
        {
            colliders.ForEach(collider1 =>
            {
                if (collider1.Parent.GetComponent<Body>() != null &&
                    collider1.Parent.GetComponent<Body>().movable) // przeszukiwanie tylko komponentów, które się poruszają
                {
                    colliders.ForEach(collider2 =>
                    {
                        if (!collider1.Equals(collider2)) // nie sprawdzamy kolizji obiektu z samym sobą
                        {
                            if (collider1.GetType().Equals(typeof(Collider.CircleCollider)))
                            {
                                CircleCollider Col1 = (CircleCollider) collider1;
                                if (collider2.GetType().Equals(typeof(Collider.CircleCollider)))
                                {
                                    CircleCollider Col2 = (CircleCollider) collider2;
                                    if (GetDistBetween(Col1, Col2) < Col1.radius + Col2.radius)
                                    {
                                        if (Col1.GetReaction(Col2.GetCollisionChanell()).Equals(ReactType.Block))
                                        {
                                            
                                        }
                                    }
                                }
                                else if (collider2.GetType().Equals(typeof(Collider.BoxCollider)))
                                {
                                    BoxCollider Col2 = (BoxCollider) collider2;
                                    if()
                                }
                            }
                            else if (collider1.GetType().Equals(typeof(Collider.BoxCollider)))
                            {
                                BoxCollider Col1 = (BoxCollider) collider1;
                                if (collider2.GetType().Equals(typeof(Collider.CircleCollider)))
                                {
                                    CircleCollider Col2 = (CircleCollider) collider2;

                                }
                                else if (collider2.GetType().Equals(typeof(Collider.BoxCollider)))
                                {
                                    BoxCollider Col2 = (BoxCollider) collider2;

                                }
                            }
                        }
                    });
                }
            });
        }

        private static void CheckCollision(Collider.Collider c1, Collider.Collider c2)
        {

        }

        public static float GetDistBetween(Collider.Collider c1, Collider.Collider c2)
        {
            return (float)Math.Sqrt(Math.Pow(c1.GetPosition().X - c2.GetPosition().X, 2) +
                                    Math.Pow(c1.GetPosition().Y - c2.GetPosition().Y, 2));
        }

        public static Vector2 GetPosDiff(Collider.Collider c1, Collider.Collider c2)
        {
            return new Vector2(
                MathHelper.Distance(
                    c1.GetPosition().X,
                    c2.GetPosition().X),
                MathHelper.Distance(
                    c1.GetPosition().Y,
                    c2.GetPosition().Y));
        }
    }


    //CircleCollider cr = (CircleCollider)collider1;
    //Debug.WriteLine("radius: " + cr.radius);

    
    //if (collider.GetType().Equals(typeof(Collider.CircleCollider)))
    //{
    //Debug.WriteLine("NO ELOSZKI");
    //}
    //else
    //{
    //Debug.WriteLine("SIEMANKO");

    //}
    //Debug.WriteLine(collider.GetType());
    //Debug.WriteLine(typeof(Collider.CircleCollider));
}