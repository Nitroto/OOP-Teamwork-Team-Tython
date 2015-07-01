using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.Xml.Serialization;

namespace Diablo.GUI
{
    public class Menu
    {
        public event EventHandler OnMenuChange;

        private int itemNumber;
        private string id;

        public Menu()
        {
            this.id = string.Empty;
            this.ItemNumber = 0;
            this.Effects = string.Empty;
            this.Axis = "Y";
            this.Items = new List<MenuItem>();
        }


        public string Axis { get; set; }
        public string Effects { get; set; }
        [XmlElement("Item")]
        public List<MenuItem> Items { get; set; }
        [XmlIgnore]
        public int ItemNumber
        {
            get
            {
                return this.itemNumber;
            }
            private set
            {
                this.itemNumber = value;
            }
        }


        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                //if (OnMenuChange != null)
                this.OnMenuChange(this, new EventArgs());
            }
        }


        public void Transition(float alpha)
        {
            foreach (MenuItem item in Items)
            {
                item.Image.IsActive = true;
                item.Image.Alpha = alpha;
                if (alpha == 0.0f)
                {
                    item.Image.FadeEffect.Increase = true;
                }
                else
                {
                    item.Image.FadeEffect.Increase = false;
                }
            }
        }

        public void LoadContent()
        {

            string[] split = this.Effects.Split(':');
            foreach (MenuItem item in this.Items)
            {
                item.Image.LoadContent();
                foreach (string s in split)
                {
                    item.Image.ActivateEffect(s);
                }
            }
            this.AlignMenuItems();
        }

        public void UnloadContent()
        {
            foreach (MenuItem item in this.Items)
            {
                item.Image.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.Axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right))
                {
                    this.ItemNumber++;
                }
                else if (InputManager.Instance.KeyPressed(Keys.Left))
                {
                    this.ItemNumber--;
                }
            }
            else if (this.Axis == "Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down))
                {
                    this.ItemNumber++;
                }
                else if (InputManager.Instance.KeyPressed(Keys.Up))
                {
                    this.ItemNumber--;
                }
            }
            if (this.ItemNumber < 0)
            {
                this.ItemNumber = 0;
            }
            else if (this.itemNumber > this.Items.Count - 1)
            {
                this.ItemNumber = this.Items.Count - 1;
            }
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (i == this.ItemNumber)
                {
                    this.Items[i].Image.IsActive = true;
                }
                else
                {
                    this.Items[i].Image.IsActive = false;
                }
                this.Items[i].Image.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in this.Items)
            {
                item.Image.Draw(spriteBatch);
            }
        }

        private void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach (MenuItem item in this.Items)
            {
                dimensions += new Vector2(item.Image.SourceRect.Width,
                    item.Image.SourceRect.Height);
            }
            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X - dimensions.X) / 2,
                (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);
            foreach (MenuItem item in this.Items)
            {
                if (this.Axis == "X")
                {
                    item.Image.Postition = new Vector2(dimensions.X,
                        (ScreenManager.Instance.Dimensions.Y - item.Image.SourceRect.Height) / 2);
                }
                else if (this.Axis == "Y")
                {
                    item.Image.Postition = new Vector2((ScreenManager.Instance.Dimensions.X - item.Image.SourceRect.Width) / 2,
                        dimensions.Y);
                }
                dimensions += new Vector2(item.Image.SourceRect.Width,
                                 item.Image.SourceRect.Height);
            }
        }
    }
}
