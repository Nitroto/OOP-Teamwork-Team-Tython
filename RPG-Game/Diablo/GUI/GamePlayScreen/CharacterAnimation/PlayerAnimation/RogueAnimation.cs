using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation.PlayerAnimation
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
        public override void Update(GameTime gameTime)
        {
            if (dies)
            {
                this.RunAnimation("Die");

                this.frameIndex = this.frames[this.frames.Length - 1]-1;
                return;
            }
            base.Update(gameTime);
        }
    }
}
