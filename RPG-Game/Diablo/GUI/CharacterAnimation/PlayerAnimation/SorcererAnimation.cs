using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation.PlayerAnimation
{
    public class SorcererAnimation : PlayerAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        readonly int[] frames = new int[] { 8, 13, 9, 1, 13, 13 };
        public SorcererAnimation(Vector2 position)
            : base(position, CharacterType.Sorcerer)
        {
            this.Frames = this.frames;
            this.InitializeAnimation();
        }
    }
}
