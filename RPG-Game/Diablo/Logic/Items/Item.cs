using Diablo.Enums;
using Diablo.Interfaces;
using System;

namespace Diablo.Logic.Items
{
    public abstract class Item : GameObject, IItem
    {
        protected static readonly Random rnd = new Random();

        protected Item(string name, int health, int damage, int mana) : base(name)
        {
            this.Damage = damage;
            this.Health = health;
            this.Mana = mana;
        }


        public int Damage { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        //public ItemSize ItemSize { get; set; }
    }
}
