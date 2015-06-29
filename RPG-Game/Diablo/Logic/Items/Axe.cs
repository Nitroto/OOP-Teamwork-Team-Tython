namespace Diablo.Logic.Items
{
    public class Axe : Item
    {
        private const int ExtraDamage = 0;

        public Axe()
            : base("axe"+Rnd.Next(0,1000), 0, ExtraDamage, 0)
        {
        }
    }
}
