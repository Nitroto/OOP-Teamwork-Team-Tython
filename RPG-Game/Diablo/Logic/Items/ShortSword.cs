namespace Diablo.Logic.Items
{
    public class ShortSword : Item
    {
        private const int ExtraDamage = 0;

        public ShortSword()
            : base("sword"+Rnd.Next(0,1000), 0, ExtraDamage, 0)
        {
        }
    }
}
