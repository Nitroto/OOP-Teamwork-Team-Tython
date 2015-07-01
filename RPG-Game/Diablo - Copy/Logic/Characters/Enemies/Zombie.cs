namespace Diablo.Logic.Characters.Enemies
{
    public class Zombie : BaseEnemy
    {
        private new const int Damage = 1;
        private new const int Health = 70;

        public Zombie() : base(Damage, Health)
        {
        }
    }
}
