using Diablo.Interfaces;

namespace Diablo.Characters
{
    public abstract class BaseCharacter : GameObject, ICharacter
    {

        protected BaseCharacter(string name,int health,int damage, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Mana = mana;
        }

        public int Health { get; private set; }
        public int Mana { get; private set; }
        public int Damage { get; private set; }

        public abstract void Attack(ICharacter enemy);
    }
}
