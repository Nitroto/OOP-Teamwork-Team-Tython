using Diablo.Enums;
using Diablo.Interfaces;

namespace Diablo.Logic.Items.Potion
{
    public abstract class Potion : Item, ISizeable
    {
        new private const int Health = 0;
        new private const int Mana = 0;

        protected Potion(ItemSize size)
            : base("potion" + Rnd.Next(1000, 2000), Health, 0, Mana)
        {
            this.Size = size;
        }

        public ItemSize Size { get; private set; }
    }
}
