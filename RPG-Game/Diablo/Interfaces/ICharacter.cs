using Diablo.Items;

namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack
    {
        int Mana { get; set; }
        int Damage { get; set; }
        int Health { get; set; }

        void ApplyItems(Item item);
        void RemoveItems(Item item);
    }
}
