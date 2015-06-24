using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation
{
    class BarbarianAnimation : CharacterAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 11, 8, 1, 9, 11 };

        public BarbarianAnimation(Vector2 position, CharactersType charType)
            : base(position, CharactersType.Barbarian)
        {
            this.Frames = this.frames;
            this.HandleAnimation();
        }
    }
}
