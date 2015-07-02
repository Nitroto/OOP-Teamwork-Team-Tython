using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class SplashScreen : GameScreen
    {
        private int currentElement;
        private double currentTime;

        public SplashScreen()
        {
            this.currentElement = 0;
        }

        [XmlElement("Slide")]
        public List<Image> Images { get; set; }
        public double AnimationTime { get; set; }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Images[this.currentElement].LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Images[this.currentElement].UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.currentTime += gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
            this.Images[this.currentElement].Update(gameTime);
            if (this.Images[this.currentElement].Alpha == 1.0f && this.currentElement < this.Images.Count - 1)
            {
                this.Images[this.currentElement].IsActive = false;
                this.currentElement++;
                this.Images[this.currentElement].LoadContent();
            }
            else if (this.Images[this.currentElement].Alpha == 1.0f)
            {
                this.Images[this.currentElement].FadeEffect.IsActive = false;
                if (this.currentTime > this.AnimationTime)
                {
                    ScreenManager.Instance.ChangeScreens("TitleScreen");
                    //this.Images[this.currentElement].UnloadContent();
                }
            }
            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Space))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Images[this.currentElement].Draw(spriteBatch);

        }
    }
}
