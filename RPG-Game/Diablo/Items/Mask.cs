using Diablo.Enums;

namespace Diablo.Items
{
    class Mask : Item
    {
        new private const int Health = 0;
        new private const int Mana = 0;

        public Mask(ItemSize maskSize)
            : base(maskSize.ToString(), Health, (int)maskSize, Mana)
        {
            this.ItemSize = maskSize;
        }
    }
}
