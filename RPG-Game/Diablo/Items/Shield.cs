using Diablo.Items.Enums;

namespace Diablo.Items
{
    class Shield : Item
    {
        new private const int Damage = 0;
        new private const int Mana = 0;

        public Shield(Color shieldColor)
            : base(shieldColor.ToString(), (int)shieldColor, Damage, Mana)
        {
            this.Color = shieldColor;
        }
    }
}
