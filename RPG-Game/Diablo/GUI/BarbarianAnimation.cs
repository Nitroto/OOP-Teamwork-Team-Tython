using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.GUI
{
    class BarbarianAnimation : AnimationsDetails
    {
        readonly int[] frames = new int[] { 8, 11, 8, 1, 9, 11 };
        public BarbarianAnimation(Vector2 position, CharactersType charType)
            : base(position, CharactersType.Barbarian)
        {
            this.HandleAnimation();
        }

        public override void HandleAnimation()
        {
            var allAnimations = Enum.GetNames(typeof(AnimationType)).Length;
            int counter = 0;
            for (int i = 0; i < frames.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    this.AddAnimation(frames[i], this.FrameHeight * counter, (AnimationType)(counter));
                    counter++;
                }
            }
        }
    }
}
