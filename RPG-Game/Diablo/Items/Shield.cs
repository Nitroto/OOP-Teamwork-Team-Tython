
using Diablo.Enums;

namespace Diablo.Items
{
    class Shield : Item
    {
        new private const int Damage = 0;
        new private const int Mana = 0;

        public Shield(ItemSize shieldSize)
            : base(shieldSize.ToString(), (int)shieldSize, Damage, Mana)
        {
            this.ItemSize = shieldSize;
        }
    }
}
