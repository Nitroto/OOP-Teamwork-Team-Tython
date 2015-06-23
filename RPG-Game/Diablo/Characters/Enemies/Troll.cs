namespace Diablo.Characters.Enemies
{
    public class Troll : BaseEnemy
    {

        private new const int Damage = 5;
        private new const int Health = 25;


        public Troll() : base(Damage, Health)
        {
        }
    }
}
