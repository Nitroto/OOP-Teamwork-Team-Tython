using System;
using Diablo.Enums;
using Diablo.Interfaces;
using Diablo.Items;

namespace Diablo.Factories
{
    class ItemFactory
    {
        public IItem CreateItem()
        {
            Random rnd = new Random();
            switch (rnd.Next(1,17))
            {
                case 1:
                    return new Crown(ItemSize.Small);
                case 2:
                    return new Crown(ItemSize.Medium);
                case 3:
                    return new Crown(ItemSize.Large);
                case 4:
                    return new Crown(ItemSize.Superb);

                case 5:
                    return new Mask(ItemSize.Small);
                case 6:
                    return new Mask(ItemSize.Medium);
                case 7:
                    return new Mask(ItemSize.Large);
                case 8:
                    return new Mask(ItemSize.Superb);

                case 9:
                    return new Potion(ItemSize.Small);
                case 10:
                    return new Potion(ItemSize.Medium);
                case 11:
                    return new Potion(ItemSize.Large);
                case 12:
                    return new Potion(ItemSize.Superb);

                case 13:
                    return new Shield(ItemSize.Small);
                case 14:
                    return new Shield(ItemSize.Medium);
                case 15:
                    return new Shield(ItemSize.Large);

                default: return new Shield(ItemSize.Superb);
            }
        }
    }
}
