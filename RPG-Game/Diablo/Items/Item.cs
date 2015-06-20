using Diablo.Items.Enums;

namespace Diablo.Items
{
    public abstract class Item : GameObject, IItem
    {

        protected Item(string name,int health,int damage,int mana) : base(name)
        {
            this.Damage = damage;
            this.Health = health;
            this.Mana = mana;
        }


        public int Damage { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public Color Color { get; set; }
    }
}
