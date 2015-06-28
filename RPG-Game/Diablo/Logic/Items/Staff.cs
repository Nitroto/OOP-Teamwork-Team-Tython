namespace Diablo.Logic.Items
{
    public class Staff : Item
    {
        private const int ExtraMana = 0;

        public Staff()
            : base("staff"+rnd.Next(0,1000), 0, 0, ExtraMana)
        {
        }
    }
}
