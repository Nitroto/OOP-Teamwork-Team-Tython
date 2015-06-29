using System.Collections.Generic;
using Diablo.Interfaces;
using Diablo.Logic.Items;
using Diablo.GUI.CharacterAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Diablo.GUI.StatusBarAnimation;
using System;

namespace Diablo.Logic.Characters.Heroes
{
    public abstract class BaseCharacter : GameObject, ICharacter, IManaregenable
    {
        private List<IItem> items;

        protected BaseCharacter(string name, int health, int damage, int mana)
            : base(name)
        {
            this.Health = health;
            this.Damage = damage;
            this.Mana = mana;
            this.Items = new List<IItem>();
            this.IsAlive = true;
            this.HealthAnimation = new Health((new Vector2(10, 400)));
            this.ManaAnimation = new Mana((new Vector2(740, 400)));
        }


        public CharacterAnimation CharacterAnimation { get; set; }
        public Health HealthAnimation { get; set; }
        public Mana ManaAnimation { get; set; }
        public TimeSpan LastCast { get; set; }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            this.CharacterAnimation.Update(gameTime, keyState);
            this.HandleUserInput(keyState, gameTime);
            
            //regen mana
            this.ManaRegen(gameTime);
            this.DecreaseMana();
        }

        protected virtual void HandleUserInput(KeyboardState keyState, GameTime gameTime)
        {
            
            if (keyState.IsKeyDown(Keys.Up) && gameTime.TotalGameTime - this.LastCast > new TimeSpan(0,0,2))
            {
                this.CastSpell();
                this.DecreaseMana();
                this.LastCast = gameTime.TotalGameTime;
            }
        }



        public int Health { get; set; }
        public List<IItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        public int Mana { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        void IKillable.IsDead(ICharacter enemy)
        {
            IsDead(enemy);
        }


        public void Attack(ICharacter enemy)
        {
            enemy.Health -= this.Damage;

            IsDead(enemy);
        }

        public void ApplyItems(Item item)
        {
            this.Items.Add(item);
            this.Damage += item.Damage;
            this.Health += item.Health;
            this.Mana += item.Mana;

        }

        public void RemoveItems(Item item)
        {
            this.Items.Remove(item);
            this.Damage -= item.Damage;
            this.Health -= item.Health;
            this.Mana -= item.Mana;

            if (this.Health <= 0)
            {
                this.Health = 1;
            }
        }

        private static void IsDead(ICharacter enemy)
        {
            if (enemy.Health <= 0)
            {
                enemy.IsAlive = false;
            }
        }


        public abstract void CastSpell();
        public abstract void DecreaseMana();
        public abstract void IncreaseMana();

        public abstract void ManaRegen(GameTime gameTime);
    }
}
