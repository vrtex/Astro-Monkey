using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Graphics
{
    class ProgressBarWidget : Widget
    {
        private float Progress = 1f;

        public ProgressBarWidget(Vector2 position) : base(position)
        {
        }

        public ProgressBarWidget(Vector2 position, Vector2 size) : base(position, size)
        {
        }

        public override Rectangle GetDestinationRectangle()
        {
            var Base = base.GetDestinationRectangle();
            Base.Width = (int)(Base.Width * Progress);
            return Base;
        }

        public void SetProgress(float alpha)
        {
            Progress = alpha;
            SourceRectangle.Width = (int)(SourceRectangle.Width * Progress);
        }

    }
}
