using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.GamePLayScreen.StatusBarAnimation
{
    public class Mana : StatusBar
    {
        private const string ManaBarImgSource = @"res/bars/mana.png";
        private const string ManaBarFrame = @"res/bars/frame.png";

        public Mana(Vector2 position)
            : base(position, ManaBarImgSource, ManaBarFrame)
        {
        }

        public int Quantity { get; set; }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            //int mana = 150;
            //float percentage = (float)mana / (float)this.MaxQuantity;
            //int frame = (int)(percentage * 49);

            //if (counter < frame)
            //{
            //    this.FrameToShow = this.sRectangles[this.counter];
            //    this.sPosition.Y++;
            //    this.counter++;
            //}
        }
        public void ReRenderManaBar(int mana, int maxMana)
        {
            float percentage = (float)mana / (float)maxMana;
            int frame = 49 - (int)(percentage * 49);

            this.FrameToShow = this.sRectangles[frame];
            this.sPosition.Y = 400 + frame;

        }
    }
}
