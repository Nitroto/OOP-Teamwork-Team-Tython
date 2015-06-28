using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes
{
    public class Rogue : BaseCharacter, IShield
    {
        private new const int Health = 180;
        private new const int Damage = 20;
        private new const int Mana = 90;

        public Rogue(string name) :
            base(name, Health, Damage, Mana)
        {
        }

        public int Shield { get; set; }
    }
}
