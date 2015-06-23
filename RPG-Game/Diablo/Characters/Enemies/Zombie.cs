namespace Diablo.Characters.Enemies
{
    class Zombie : BaseEnemy
    {
        private new const int Damage = 10;
        private new const int Health = 70;

        public Zombie() : base(Damage, Health)
        {
        }
    }
}
