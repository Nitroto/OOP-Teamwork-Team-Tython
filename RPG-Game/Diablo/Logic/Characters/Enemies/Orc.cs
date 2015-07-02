namespace Diablo.Logic.Characters.Enemies
{
    public class Orc : BaseEnemy
    {
        private new const int Damage = 2;
        private new const int Health = 48;

        public Orc() : base(Damage, Health)
        {
        }
    }
}
