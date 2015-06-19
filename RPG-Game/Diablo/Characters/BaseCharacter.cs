using Diablo.Interfaces;

namespace Diablo.Characters
{
    public abstract class BaseCharacter : ICharacter
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Mana { get; private set; }
        public void Attack(ICharacter enemy)
        {
            throw new System.NotImplementedException();
        }

        int IKillable.Health
        {
            get { return Health; }
            set { Health = value; }
        }
    }
}
