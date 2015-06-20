using Diablo.Items.Enums;

namespace Diablo.Items
{
    public interface IItem
    {
        int Damage { get; set; }
        int Health { get; set; }
        int Mana { get; set; }
        Color Color { get; set; }
    }
}
