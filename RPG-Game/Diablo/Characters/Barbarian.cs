using Diablo.Interfaces;

namespace Diablo.Characters
{
    public class Barbarian : BaseCharacter, IShield
    {
        //TODO constant name,health,damage,mana,shield...

        public Barbarian(string name, int health, int damage, int mana) : base(name, health, damage, mana)
        {
        }

        public int Shield { get; set; }
    }
}
