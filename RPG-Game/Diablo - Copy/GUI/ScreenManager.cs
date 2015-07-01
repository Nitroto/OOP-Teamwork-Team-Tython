using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        private XmlManager<GameScreen> xmlGameScreenManager;


        public ScreenManager()
        {
            this.Dimensions = new Vector2(800, 480);
            this.currentScreen = new SplashScreen();
            this.xmlGameScreenManager = new XmlManager<GameScreen>();
            this.xmlGameScreenManager.Type = this.currentScreen.Type;
            this.currentScreen = this.xmlGameScreenManager.Load("Content/Load/SplashScreen.xml");
        }


        public GameScreen currentScreen { get; set; }
        public GameScreen newScreen { get; set; }
        public Image Image { get; set; }
        [XmlIgnore]
        public bool IsTransitioning { get; private set; }
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice { get; set; }
        [XmlIgnore]
        public ContentManager Content { get; private set; }
        [XmlIgnore]
        public SpriteBatch SpriteBatch { get; set; }
        [XmlIgnore]
        public Vector2 Dimensions { get; set; }


        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Content/Load/ScreenManager.xml");
                }
                return instance;
            }
        }


        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            this.currentScreen.LoadContent();
            this.Image.LoadContent();
        }

        public void UnloadContent()
        {
            this.currentScreen.UnloadContent();
            this.Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            this.currentScreen.Update(gameTime);
            this.Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.currentScreen.Draw(spriteBatch);
            if (this.IsTransitioning)
            {
                this.Image.Draw(spriteBatch);
            }
        }

        public void ChangeScreens(string screenName)
        {
            this.newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Game1." + screenName));
            this.Image.IsActive = true;
            this.Image.FadeEffect.Increase = true;
            this.Image.Alpha = 0.0f;
            this.IsTransitioning = true;
        }

        private void Transition(GameTime gameTime)
        {
            if (this.IsTransitioning)
            {
                this.Image.Update(gameTime);
                if (this.Image.Alpha == 1.0f)
                {
                    this.currentScreen.UnloadContent();
                    this.currentScreen = this.newScreen;
                    this.xmlGameScreenManager.Type = this.currentScreen.Type;
                    if (File.Exists(this.currentScreen.XmlPath))
                    {
                        this.currentScreen = this.xmlGameScreenManager.Load(this.currentScreen.XmlPath);
                    }
                    this.currentScreen.LoadContent();
                }
                else if (this.Image.Alpha == 0.0f)
                {
                    this.Image.IsActive = false;
                    this.IsTransitioning = false;
                }

            }

        }
    }
}
