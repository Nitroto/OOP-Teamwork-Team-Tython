using System;
using Diablo.Enums;
using Diablo.Interfaces;
using Diablo.Logic.Items;

namespace Diablo.Logic.Factories
{
    class ItemFactory
    {
        public IItem CreateItem()
        {
            Random rnd = new Random();
            switch (rnd.Next(1,17))
            {
                //case 1:
                //    return new ShortSword();
                //case 2:
                //    return new Crown(ItemSize.Medium);
                //case 3:
                //    return new Crown(ItemSize.Large);
                //case 4:
                //    return new Crown(ItemSize.Superb);

                //case 5:
                //    return new ShortSword(ItemSize.Small);
                //case 6:
                //    return new ShortSword(ItemSize.Medium);
                //case 7:
                //    return new ShortSword(ItemSize.Large);
                //case 8:
                //    return new ShortSword(ItemSize.Superb);

                //case 9:
                //    return new Potion(ItemSize.Small);
                //case 10:
                //    return new Potion(ItemSize.Medium);
                //case 11:
                //    return new Potion(ItemSize.Large);
                //case 12:
                //    return new Potion(ItemSize.Superb);

                //case 13:
                //    return new Staff(ItemSize.Small);
                //case 14:
                //    return new Staff(ItemSize.Medium);
                //case 15:
                //    return new Staff(ItemSize.Large);

                default: return new Staff();
            }
        }
    }
}
