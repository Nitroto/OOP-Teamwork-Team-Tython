﻿using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation.EnemyAnimation
{
    public class OrcAnimation:EnemyAnimation
    {
        // frames for correct animate character {Move, Attack, Hitted, Idle, Cast Spell, Dies}
        private readonly int[] frames = new int[] { 8, 13, 9, 1, 0, 13 };

        public OrcAnimation(Vector2 position)
            : base(position, CharacterType.Orc)
        {
            this.Frames = this.frames;
            this.InitializeAnimation();
        }

        protected override void HandleAnimation()
        {
        }
    }
}
