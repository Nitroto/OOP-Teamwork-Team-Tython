using Diablo.Enums;

namespace Diablo.Logic.Items.Potion
{
    public class ManaPotion : Potion
    {
        private const int DefaultHealth = 0;

        public ManaPotion(ItemSize size)
            :base(size,DefaultHealth,(int)size)
        {
        }
    }
}
