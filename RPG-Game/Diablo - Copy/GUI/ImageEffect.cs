using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.GUI
{
    public class ImageEffect
    {
        protected Image image;


        public ImageEffect()
        {
            this.IsActive = false;
        }


        public bool IsActive { get; set; }

        public virtual void LoadContent(ref Image image)
        {
            this.image = image;
        }
        public virtual void UnloadContent()
        {
        }
        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
