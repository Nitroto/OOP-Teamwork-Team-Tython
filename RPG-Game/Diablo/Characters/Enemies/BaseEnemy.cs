using System;
using System.Collections.Generic;
using Diablo.Characters.Heroes;
using Diablo.Interfaces;
using Diablo.Items;

namespace Diablo.Characters.Enemies
{
    public abstract class BaseEnemy : GameObject, ICharacter
    {
        private static readonly string[] enemyNames = new string[] {"Angel", "Nasko", "Bogomil", "Filip"};
        static readonly Random Rnd = new Random();

        protected BaseEnemy(int damage,int health) : base(enemyNames[Rnd.Next(0,enemyNames.Length)])
        {
            this.Health = health;
            this.Damage = damage;
            this.IsAlive = true;
            this.Items = new List<IItem>();
        }


        public bool IsAlive { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public List<IItem> Items { get; set; }


        public void Attack(ICharacter hero)
        {
            hero.Health -= this.Damage;
            IsDead(hero);
        }

        public void ApplyItems(Item item)
        {
            this.Items.Add(item);
        }

        public void RemoveItems(Item item)
        {
            this.Items.Remove(item);
        }

        public void IsDead(ICharacter hero)
        {
            if (hero.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
