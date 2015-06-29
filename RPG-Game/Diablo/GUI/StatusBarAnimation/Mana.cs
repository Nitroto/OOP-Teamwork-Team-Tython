﻿using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    public class Mana : StatusBar
    {
        private const string imgSource = @"res/bars/mana.png";

        public Mana(Vector2 position)
            : base(position, imgSource)
        {
        }

        public int Quantity { get; set; }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime, KeyboardState keyState)
        {
            int mana = 150;
            float percentage = (float)mana / (float)this.MaxQuantity;
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
