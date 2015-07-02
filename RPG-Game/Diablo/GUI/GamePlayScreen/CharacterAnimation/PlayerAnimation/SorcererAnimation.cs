using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation.PlayerAnimation
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
        public override void Update(GameTime gameTime)
        {
            if (!dies)
            {
                base.Update(gameTime);
            }
            else
            {
                this.frameIndex = this.frames[this.frames.Length - 1];
            }
        }
    }
}
