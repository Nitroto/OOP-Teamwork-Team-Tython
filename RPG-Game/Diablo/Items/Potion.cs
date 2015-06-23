
using Diablo.Enums;

namespace Diablo.Items
{
    class Potion : Item
    {
        new private const int Health = 0;
        new private const int Damage = 0;

        public Potion(ItemSize potionSize)
            : base(potionSize.ToString(), Health, Damage, (int)potionSize)
        {
            this.ItemSize = potionSize;
        }
    }
}
