using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class GameScreen
    {
        protected ContentManager content;
        [XmlIgnore]
        public Type Type;


        public GameScreen()
        {
            this.Type = this.GetType();
            this.XmlPath = "Content/load/" + this.Type.ToString().Replace("Diablo.GUI.", "") + ".xml";
        }

        public string XmlPath { get; set; }


        public virtual void LoadContent()
        {
            this.content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            this.content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
