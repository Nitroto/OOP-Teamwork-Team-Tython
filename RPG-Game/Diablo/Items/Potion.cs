using Diablo.Items.Enums;

namespace Diablo.Items
{
    class Potion : Item
    {
        new private const int Health = 0;
        new private const int Damage = 0;

        public Potion(Color potionColor)
            : base(potionColor.ToString(), Health, Damage, (int)potionColor)
        {
            this.Color = potionColor;
        }
    }
}
