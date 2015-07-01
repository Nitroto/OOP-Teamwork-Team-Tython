using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Diablo.GUI
{
    public class MenuManager
    {
        private Menu menu;
        private bool isTransitioning;

        public MenuManager()
        {
            this.menu = new Menu();
            this.menu.OnMenuChange +=this.menu_OnMenuChange;
        }

        public void LoadContent(string menuPath)
        {
            if (menuPath != string.Empty)
            {
                this.menu.ID = menuPath;
            }
        }

        public void UnloadContent()
        {
            this.menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if (!this.isTransitioning)
            {
                this.menu.Update(gameTime);
            }
            if (InputManager.Instance.KeyPressed(Keys.Enter) && !this.isTransitioning)
            {
                if (this.menu.Items[this.menu.ItemNumber].LinkType == "Screen")
                {
                    ScreenManager.Instance.ChangeScreens(this.menu.Items[menu.ItemNumber].LinkID);
                }
                else
                {
                    this.isTransitioning = true;
                    this.menu.Transition(1.0f);
                    foreach (MenuItem item in this.menu.Items)
                    {
                        item.Image.StoreEffects();
                        item.Image.ActivateEffect("FadeEffect");
                    }
                }
            }
            this.Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.menu.Draw(spriteBatch);
        }

        private void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            this.menu.UnloadContent();
            this.menu = xmlMenuManager.Load(this.menu.ID);
            this.menu.LoadContent();
            this.menu.OnMenuChange += this.menu_OnMenuChange;
            this.menu.Transition(0.0f);

            foreach (MenuItem item in this.menu.Items)
            {
                item.Image.StoreEffects();
                item.Image.ActivateEffect("FadeEffect");
            }
        }
        private void Transition(GameTime gameTime)
        {
            if (this.isTransitioning)
            {
                for (int i = 0; i < this.menu.Items.Count; i++)
                {
                    this.menu.Items[i].Image.Update(gameTime);
                    float first = this.menu.Items[0].Image.Alpha;
                    float last = this.menu.Items[this.menu.Items.Count - 1].Image.Alpha;
                    if (first == 0.0f && last == 0.0f)
                    {
                        this.menu.ID = this.menu.Items[this.menu.ItemNumber].LinkID;
                    }
                    else if (first == 1.0f && last == 1.0f)
                    {
                        this.isTransitioning = false;
                        foreach (MenuItem item in this.menu.Items)
                        {
                            item.Image.RestoreEffects();
                        }
                    }
                }
            }
        }
    }
}
