using Diablo.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation.EnemyAnimation
{
    public class GreyTrollAnimation:EnemyAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 13, 9, 1, 0, 17 };

        public GreyTrollAnimation(Vector2 position)
            : base(position, CharacterType.GreyTroll)
        {
            this.Frames = this.frames;
            this.InitializeAnimation();
        }

        protected override void HandleAnimation(KeyboardState keyState)
        {
        }
    }
}
