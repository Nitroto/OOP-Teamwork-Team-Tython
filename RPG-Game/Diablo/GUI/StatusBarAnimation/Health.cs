using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    public class Health : StatusBar
    {
        private const string ImgSource = @"res/bars/health.png";

        public Health(Vector2 position)
            : base(position, ImgSource)
        {
        }

        public int Quantity { get; set; }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime, KeyboardState keyState)
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
        public void ReRenderHealthBar(int health, int maxHealth)
        {
            float percentage = (float)health / (float)maxHealth;
            int frame = 49 - (int)(percentage * 49);

            this.FrameToShow = this.sRectangles[frame];
            this.sPosition.Y = 400 + frame;

        }
    }
}
