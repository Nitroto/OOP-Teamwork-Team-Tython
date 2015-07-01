using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation.PlayerAnimation
{
    public class BarbarianAnimation : PlayerAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 11, 8, 1, 9, 11 };

        public BarbarianAnimation(Vector2 position)
            : base(position, CharacterType.Barbarian)
        {
            this.Frames = this.frames;
            this.InitializeAnimation();
        }
    }
}
