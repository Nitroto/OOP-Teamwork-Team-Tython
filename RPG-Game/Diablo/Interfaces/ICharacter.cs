using System.Collections.Generic;
using Diablo.Items;

namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack, IKillable
    {
        int Damage { get; set; }
        int Health { get; set; }
        List<IItem> Items { get; set; } 

        void ApplyItems(Item item);
        void RemoveItems(Item item);
    }
}
