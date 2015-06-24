using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation
{
    class RogueAnimation : CharacterAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 11, 8, 1, 8, 12 }; 

        public RogueAnimation(Vector2 position, CharactersType charType)
            : base(position, CharactersType.Rogue)
        {
            this.Frames = this.frames;
            this.HandleAnimation();
        }
    }
}
