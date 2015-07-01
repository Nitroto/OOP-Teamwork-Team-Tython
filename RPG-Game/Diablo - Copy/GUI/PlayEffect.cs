using Microsoft.Xna.Framework;

namespace Diablo.GUI
{
    public class PlayEffect : ImageEffect
    {
        public PlayEffect()
        {
            this.FadeSpeed = 1f;
            this.Increase = false;
        }

        public float FramesPerSecond { get; set; }
        public bool Increase { get; set; }

        public override void LoadContent(ref Image image)
        {
            base.LoadContent(ref image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (this.image.IsActive)
            {
                if (!this.Increase)
                {
                    this.image.Alpha -= this.FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    this.image.Alpha += this.FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (this.image.Alpha < 0.0f)
                {
                    this.Increase = true;
                    this.image.Alpha = 0.0f;
                }
                else if (this.image.Alpha > 1.0f)
                {
                    this.Increase = false;
                    this.image.Alpha = 1.0f;
                }
            }
            else
            {
                this.image.Alpha = 1.0f;
            }
        }
    }
}
