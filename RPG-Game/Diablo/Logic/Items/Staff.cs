namespace Diablo.Logic.Items
{
    public class Staff : Item
    {
        private const int ExtraMana = 50;

        public Staff()
            : base("staff"+Rnd.Next(0,1000), 0, 0, ExtraMana)
        {
        }
    }
}
