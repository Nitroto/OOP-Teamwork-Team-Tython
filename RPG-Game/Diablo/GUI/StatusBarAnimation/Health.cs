using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    public class Health : StatusBar
    {
        private const string imgSource = @"res/bars/health.png";

        public Health(Vector2 position, BaseCharacter character)
            : base(position, imgSource, character)
        {
            this.MaxQuantity = this.Character.Health;
        }

        public int Quantity { get; set; }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            int health = 50;
            float percentage = (float)health / (float)this.MaxQuantity;
            int frame = (int)(percentage * 49);
            if (counter < frame)
            {
                this.FrameToShow = this.sRectangles[this.counter];
                this.sPosition.Y++;
                this.counter++;
            }

        }
    }
}
