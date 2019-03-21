using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AstroMonkey.Physics.Collider;

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

        public static void CheckCollision()
        {
            colliders.ForEach(collider1 =>
            {
                colliders.ForEach(collider2 =>
                {
                    if (!collider1.Equals(collider2))
                    {
                        if (collider1.GetType().Equals(typeof(Collider.CircleCollider)))
                        {
                            CircleCollider Col1 = (CircleCollider)collider1;
                            if (collider2.GetType().Equals(typeof(Collider.CircleCollider)))
                            {
                                CircleCollider Col2 = (CircleCollider)collider2;
                                
                            }
                            else if (collider2.GetType().Equals(typeof(Collider.BoxCollider)))
                            {
                                BoxCollider Col2 = (BoxCollider)collider2;

                            }
                        }
                        else if(collider1.GetType().Equals(typeof(Collider.BoxCollider)))
                        {
                            BoxCollider Col1 = (BoxCollider)collider1;
                            if (collider2.GetType().Equals(typeof(Collider.CircleCollider)))
                            {
                                CircleCollider Col2 = (CircleCollider)collider2;

                            }
                            else if (collider2.GetType().Equals(typeof(Collider.BoxCollider)))
                            {
                                BoxCollider Col2 = (BoxCollider)collider2;

                            }
                        }
                    }
                });
            });
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