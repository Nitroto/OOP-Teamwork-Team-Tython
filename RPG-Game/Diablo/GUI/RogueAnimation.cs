using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI
{
    class RogueAnimation : AnimationsDetails
    {
        readonly int[] frames = new int[] { 8, 11, 8, 1, 8, 12 }; 
        public RogueAnimation(Vector2 position, CharactersType charType)
            : base(position, CharactersType.Rogue)
        {
            this.HandleAnimation();
        }
        
        public override void HandleAnimation()
        {
            var allAnimations = Enum.GetNames(typeof(AnimationType)).Length;
            int counter = 0;
            for (int i = 0; i < frames.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.AddAnimation(frames[i], this.FrameHeight * counter, (AnimationType)(counter));
                    counter++;
                }
            }
        }
    }
}
