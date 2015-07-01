using Diablo.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Diablo.GUI
{
    public abstract class AnimatedSprite
    {
        protected const int FrameWidth = 96;
        protected const int FrameHeight = 96;
        public Vector2 sPosition;
        protected Texture2D sTexture;
        private Rectangle[] sRectangles;
        private int frameIndex;
        private double timeElapsed;
        private double timeToUpdate;
        protected Vector2 sDirection = Vector2.Zero;
        private Dictionary<AnimationType, Rectangle[]> sAnimations = new Dictionary<AnimationType, Rectangle[]>();
        protected AnimationType currentAnimation;
        protected Direction currentDirection = Direction.None;

        protected AnimatedSprite(Vector2 position)
        {
            this.sPosition = position;
        }

        public void AddAnimation(int frames, int yPos, AnimationType direction)
        {
            int xStartFrama = 0;
            Rectangle[] rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                rectangles[i] = new Rectangle((i + xStartFrama) * FrameWidth, yPos, FrameWidth, FrameHeight);
            }
            this.sAnimations.Add(direction, rectangles);

        }

        public int FramesPerSecond
        {
            set
            {
                this.timeToUpdate = (1d / value);
            }
        }

        public virtual void Update(GameTime gameTime, KeyboardState keyState)
        {
            this.timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timeElapsed > this.timeToUpdate)
            {
                this.timeElapsed -= this.timeToUpdate;
                if (this.frameIndex < this.sAnimations[currentAnimation].Length - 1)
                {
                    this.frameIndex++;
                }
                else
                {
                    this.AnimationDone();
                    this.frameIndex = 0;
                }
            }
        }

        public void PlayAnimation(AnimationType animation)
        {
            if (this.currentAnimation != animation && currentDirection == Direction.None)
            {
                this.currentAnimation = animation;
                this.frameIndex = 0;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sTexture, this.sPosition, this.sAnimations[currentAnimation][frameIndex], Color.White);
        }

        public abstract void AnimationDone();
    }
}
