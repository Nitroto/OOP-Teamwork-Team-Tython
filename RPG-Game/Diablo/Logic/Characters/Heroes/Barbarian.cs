using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes
{
    public class Barbarian : BaseCharacter, IShield
    {
        private new const int Health = 300;
        private new const int Damage = 32;
        private new const int Mana = 64;


        public Barbarian(string name) : base(name, Health, Damage, Mana)
        {
        }

        public int Shield { get; set; }
    }
}
