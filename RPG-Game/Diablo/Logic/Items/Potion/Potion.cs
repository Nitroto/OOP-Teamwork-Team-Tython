using Diablo.Enums;
using Diablo.Interfaces;

namespace Diablo.Logic.Items.Potion
{
    public abstract class Potion : Item, ISizeable
    {
        private const int DefaultDamage = 0;

        protected Potion(ItemSize size, int health, int mana)
            : base("potion" + Rnd.Next(1000, 2000), health, DefaultDamage, mana)
        {
            this.Size = size;
        }

        public ItemSize Size { get; private set; }
    }
}
