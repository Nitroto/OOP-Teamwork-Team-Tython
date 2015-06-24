using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    class Mana : StatusBar
    {
        private const string imgSource = @"res/bars/mana.png";

        public Mana(Vector2 position)
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
