using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class TitleScreen : GameScreen
    {
        private MenuManager menuManager;


        public TitleScreen()
        {
            this.menuManager = new MenuManager();
        }

        public Image Background { get; set; }
        public string Path { get; set; }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Background.LoadContent();
            this.menuManager.LoadContent(Path);// "Content/Load/TitleMenu.xml");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            this.Background.UnloadContent();
            this.menuManager.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.Background.Update(gameTime);
            this.menuManager.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.Background.Draw(spriteBatch);
            this.menuManager.Draw(spriteBatch);
        }
    }
}
