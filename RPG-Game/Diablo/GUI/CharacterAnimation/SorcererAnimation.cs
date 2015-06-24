using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation
{
    class SorcererAnimation : CharacterAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        readonly int[] frames = new int[] { 8, 13, 9, 1, 13, 13 };
        public SorcererAnimation(Vector2 position, CharactersType charType)
            : base(position, CharactersType.Sorcerer)
        {
            this.Frames = this.frames;
            this.HandleAnimation();
        }
    }
}
