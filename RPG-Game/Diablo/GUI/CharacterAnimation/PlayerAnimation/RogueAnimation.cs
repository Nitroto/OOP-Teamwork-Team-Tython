using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation.PlayerAnimation
{
    public class RogueAnimation : PlayerAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 11, 8, 1, 8, 12 }; 

        public RogueAnimation(Vector2 position)
            : base(position, CharacterType.Rogue)
        {
            this.Frames = this.frames;
            this.InitializeAnimation();
        }
    }
}
