using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diablo.Items.Enums;

namespace Diablo.Items
{
    class Crown : Item
    {
        new private const int Health = 0;

        public Crown(Color crownColor)
            : base(crownColor.ToString(), Health, (int)crownColor, (int)crownColor)
        {
            this.Color = crownColor;
        }
    }
}
