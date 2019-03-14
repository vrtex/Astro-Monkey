using AstroMonkey.Core;

namespace AstroMonkey.Physics
{
    public class Body : Component
    {
        public bool movable { get; set; }

        public Body(GameObject parent, bool movable = true) : base(parent)
        {
            this.movable = movable;
        }
    }
}