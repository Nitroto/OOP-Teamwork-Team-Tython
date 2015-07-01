using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class Image
    {
        private Vector2 origin;
        private ContentManager content;
        private RenderTarget2D renderTarget;
        private Dictionary<string, ImageEffect> effectList;
        //private SpriteFont font;

        public float Alpha { get; set; }
        public string Text { get; set; }
        public string FontName { get; set; }
        public string Path { get; set; }
        public Vector2 Postition { get; set; }
        public Vector2 Scale { get; set; }
        public Rectangle SourceRect { get; set; }


        [XmlIgnore]
        public Texture2D Texture { get; set; }
        public string Effects;
        public bool IsActive { get; set; }
        public FadeEffect FadeEffect;

        public Image()
        {
            this.Path = string.Empty;
            this.Text = string.Empty;
            this.Effects = string.Empty;
            this.FontName = "Font/Arial";
            this.Postition = Vector2.Zero;
            this.Scale = Vector2.One;
            this.Alpha = 1.0f;
            this.SourceRect = Rectangle.Empty;
            this.effectList = new Dictionary<string, ImageEffect>();
        }


        public void LoadContent()
        {
            this.content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");

            if (this.Path != string.Empty)
            {
                this.Texture = this.content.Load<Texture2D>(Path);
            }
            //this.font = this.content.Load<SpriteFont>(FontName);
            Vector2 dimensions = Vector2.Zero;
            if (this.Texture != null)
            {
                dimensions.X += this.Texture.Width;
            }
            //dimensions.X += this.font.MeasureString(this.Text).X;

            if (this.Texture != null)
            {
                dimensions.Y = this.Texture.Height; //Math.Max( ..., this.font.MeasureString(this.Text).Y);
            }
            //else
            //{
            //    dimensions.Y = this.font.MeasureString(this.Text).Y;
            //}

            if (this.SourceRect == Rectangle.Empty)
            {
                this.SourceRect = new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y);
            }

            this.renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice,
                    (int)dimensions.X, (int)dimensions.Y);
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            ScreenManager.Instance.SpriteBatch.Begin();
            if (this.Texture != null)
            {
                ScreenManager.Instance.SpriteBatch.Draw(this.Texture, Vector2.Zero, Color.White);
            }
            //ScreenManager.Instance.SpriteBatch.DrawString(this.font, this.Text, Vector2.Zero, Color.White);
            ScreenManager.Instance.SpriteBatch.End();
            this.Texture = this.renderTarget;
            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);

            this.SetEffect<FadeEffect>(ref FadeEffect);
            if (this.Effects != string.Empty)
            {
                string[] split = this.Effects.Split(':');
                foreach (string item in split)
                {
                    this.ActivateEffect(item);
                }
            }
        }

        public void UnloadContent()
        {
            this.content.Unload();
            foreach (var effect in this.effectList)
            {
                this.DeactivateEffect(effect.Key);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var effect in this.effectList)
            {
                if (effect.Value.IsActive)
                {
                    effect.Value.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.origin = new Vector2(this.SourceRect.Width / 2, this.SourceRect.Height / 2);
            spriteBatch.Draw(this.Texture, this.Postition + this.origin, this.SourceRect, Color.White * this.Alpha,
                0.0f, this.origin, this.Scale, SpriteEffects.None, 0.0f);
        }

        public void ActivateEffect(string effect)
        {
            if (this.effectList.ContainsKey(effect))
            {
                this.effectList[effect].IsActive = true;
                var obj = this;
                this.effectList[effect].LoadContent(ref obj);
            }
        }
        public void DeactivateEffect(string effect)
        {
            this.Effects = string.Empty;
            if (this.effectList.ContainsKey(effect))
            {
                this.effectList[effect].IsActive = false;
                this.effectList[effect].UnloadContent();
            }
        }

        public void StoreEffects()
        {
            this.Effects = string.Empty;
            foreach (var effect in this.effectList)
            {
                if (effect.Value.IsActive)
                {
                    this.Effects += effect.Key + ":";
                }
            }
            if (this.Effects != string.Empty)
            {
                this.Effects.Remove(this.Effects.Length - 1);
            }
        }

        public void RestoreEffects()
        {
            foreach (var effect in this.effectList)
            {
                this.DeactivateEffect(effect.Key);
            }
            string[] split = this.Effects.Split(':');
            foreach (string s in split)
            {
                this.ActivateEffect(s);
            }
        }

        private void SetEffect<T>(ref T effect)
        {
            if (effect == null)
            {
                effect = (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                (effect as ImageEffect).IsActive = true;
                var obj = this;
                (effect as ImageEffect).LoadContent(ref obj);
            }
            this.effectList.Add(effect.GetType().ToString().Replace("Game1.", ""), (effect as ImageEffect));
        }
    }
}
