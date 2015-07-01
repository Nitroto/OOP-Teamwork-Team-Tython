using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    public class Mana : StatusBar
    {
        private const string ImgSource = @"res/bars/mana.png";

        public Mana(Vector2 position)
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
