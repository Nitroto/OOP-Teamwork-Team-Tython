namespace Diablo.Items
{
    abstract public class Item : GameObject
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
    }
}
