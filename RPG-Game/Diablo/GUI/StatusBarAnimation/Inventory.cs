using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    class Inventory : StatusBar
    {
        private const string imgSource = @"res/bars/inventory.png";

        public Inventory(Vector2 position)
            :base(position, imgSource)
        {

        }
        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}
