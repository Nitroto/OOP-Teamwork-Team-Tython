using Diablo.Enums;

namespace Diablo.Logic.Items.Potion
{
    public class HealthPotion : Potion
    {
        private const int DefaultMana = 0;

        public HealthPotion(ItemSize size)
            : base(size, (int)size, DefaultMana)
        {
        }
    }
}
