﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.GUI
{
    class HealthBar : AnimatedSprite
    {
        private Rectangle[] sRectangles;
        private int counter = 1;
        public HealthBar(Vector2 position) 
            :base(position)
        {
            this.sRectangles = new Rectangle[50];
            this.AddFrames(50, 0, 0, 50, 50, new Vector2(0, 0));
            this.FrameToShow = new Rectangle(0, 0, 50, 50);
            
        }
        public Rectangle FrameToShow { get; set; }
        public Rectangle Size { get; set; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.sTexture, sPosition, Color.Red);
            spriteBatch.Draw(this.sTexture, this.sPosition, this.FrameToShow, Color.Red);
        }
        public void AddFrames(int frames, int xPos, int xStartFrama, int width, int height, Vector2 offset)
        {
            for (int i = 0; i < frames; i++)
            {
                this.sRectangles[i] = new Rectangle(xPos, i, width, height-i);
            }

        }
        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(@"res/barbarian/health.png");
            //this.AddAnimation(8);
        }
        public override void Update(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (counter == 49)
            {
                counter = 0;
                this.sPosition.Y = 400;
            }
            this.FrameToShow = this.sRectangles[counter];
            this.sPosition.Y ++;
            counter++;

            //base.Update(gameTime);
        }

        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}