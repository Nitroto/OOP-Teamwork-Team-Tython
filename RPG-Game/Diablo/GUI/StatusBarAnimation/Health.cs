using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    class Health : StatusBar
    {
        private const string imgSource = @"res/bars/health.png";

        public Health(Vector2 position)
            :base(position, imgSource)
        {
        }

        public int Quantity { get; set; }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}
