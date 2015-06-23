using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diablo.Enums;

namespace Diablo.Items
{
    class Crown : Item
    {
        new private const int Health = 0;

        public Crown(ItemSize crownSize)
            : base(crownSize.ToString(), Health, (int)crownSize, (int)crownSize)
        {
            this.ItemSize = crownSize;
        }

    }
}
