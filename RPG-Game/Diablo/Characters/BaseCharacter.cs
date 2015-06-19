using System.Collections.Generic;
using Diablo.Interfaces;
using Diablo.Items;

namespace Diablo.Characters
{
    public abstract class BaseCharacter : GameObject, ICharacter
    {
        public List<Item> items;


        protected BaseCharacter(string name,int health,int damage, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Mana = mana;
            this.items = new List<Item>();
        }


        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }


        public void Attack(ICharacter enemy)
        {
            if (enemy is Barbarian)
            {
                Barbarian barbarian = enemy as Barbarian;
                barbarian.Shield -= this.Damage;
                if (barbarian.Shield < 0)
                {
                    barbarian.Health -= barbarian.Shield;
                    barbarian.Shield = 0;
                }
            }
            else
            {
                enemy.Health -= this.Damage;
            }
        }

        public void ApplyItems(Item item)
        {
            this.items.Add(item);
            this.Damage += item.Damage;
            this.Health += item.Health;
            this.Mana += item.Mana;

        }

        public void RemoveItems(Item item)
        {
            this.items.Remove(item);
            this.Damage -= item.Damage;
            this.Health -= item.Health;
            this.Mana -= item.Mana;
        }
    }
}
