﻿using Diablo.GUI.GamePLayScreen.CharacterAnimation;
using Diablo.GUI.GamePLayScreen.StatusBarAnimation;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Enemies;
using Diablo.Logic.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Diablo.Logic.Characters.Heroes
{
    public delegate void OnHealthOrManaChangeEventHandler(BaseCharacter sender, HealthChangedEventArgs args);
    public abstract class BaseCharacter : GameObject, ICharacter, IManaregenable
    {
        public event OnHealthOrManaChangeEventHandler HealthChange;
        public event OnHealthOrManaChangeEventHandler ManaChange;
        private int health;
        private int mana;
        private List<IItem> items;
        private List<BaseEnemy> enemiesToFight;

        protected BaseCharacter(string name, int health, int damage, int mana)
            : base(name)
        {
            this.Health = health;
            this.InitialHealth = health;
            this.Damage = damage;
            this.Mana = mana;
            this.InitialMana = mana;
            this.Items = new List<IItem>();
            this.IsAlive = true;
            this.HealthAnimation = new Health((new Vector2(10, 400)));
            this.ManaAnimation = new Mana((new Vector2(740, 400)));
            this.HealthChange += BaseCharacter_HealthChange;
            this.ManaChange += BaseCharacter_ManaChange;

        }

        public List<BaseEnemy> EnemiesToFight
        {
            get { return this.enemiesToFight; }
            set
            {
                this.enemiesToFight = new List<BaseEnemy>(value);
            }
        }
        public CharacterAnimation CharacterAnimation { get; set; }
        public Health HealthAnimation { get; set; }
        public Mana ManaAnimation { get; set; }
        public TimeSpan LastCast { get; set; }
        public TimeSpan LastHitTaken { get; set; }
        public int InitialHealth { get; set; }
        public int InitialMana { get; set; }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            this.HandleUserInput(keyState, gameTime);
            this.CharacterAnimation.Update(gameTime);


            //regen mana
            this.ManaRegen(gameTime);
        }

        protected virtual void HandleUserInput(KeyboardState keyState, GameTime gameTime)
        {

            if (keyState.IsKeyDown(Keys.Space))
            {
                //var enemyToHit = this.EnemiesToFight.Where(enemy => (this.CharacterAnimation.sPosition.Y > enemy.EnemyAnimation.sPosition.Y - 1
                //                || this.CharacterAnimation.sPosition.Y > enemy.EnemyAnimation.sPosition.Y + 1
                //                && this.CharacterAnimation.sPosition.X < enemy.EnemyAnimation.sPosition.X - 1
                //                || this.CharacterAnimation.sPosition.X < enemy.EnemyAnimation.sPosition.X + 1) == true);
                //foreach (var enemy in enemyToHit)
                //{
                //    this.Attack(enemy);

                //}
                //int number
                for (int i = 0; i < this.EnemiesToFight.Count; i++)
                {
                    BaseEnemy enemy = this.EnemiesToFight[i];
                    bool isInRange = this.CharacterAnimation.sPosition.Y > enemy.EnemyAnimation.sPosition.Y - 1
            || this.CharacterAnimation.sPosition.Y > enemy.EnemyAnimation.sPosition.Y + 1
            && this.CharacterAnimation.sPosition.X < enemy.EnemyAnimation.sPosition.X - 1
            || this.CharacterAnimation.sPosition.X < enemy.EnemyAnimation.sPosition.X + 1;
                    if (isInRange)
                    {
                        this.Attack(enemy);
                        if (!enemy.IsAlive)
                        {
                            this.EnemiesToFight.Remove(enemy);
                        }
                    }
                }
                //foreach (var enemy in enemyToHit)
                //{
                //    if (!enemy.IsAlive)
                //    {
                //        this.EnemiesToFight.Remove(enemy);
                //    }
                //}
            }
            if (keyState.IsKeyDown(Keys.Up) && gameTime.TotalGameTime - this.LastCast > new TimeSpan(0, 0, 2))
            {
                this.CastSpell();
                this.LastCast = gameTime.TotalGameTime;
            }
            if (keyState.IsKeyDown(Keys.Left) && gameTime.TotalGameTime - this.LastHitTaken > new TimeSpan(0, 0, 0, 0, 400))
            {
                // for test
                this.Health -= 10;
                this.LastHitTaken = gameTime.TotalGameTime;
            }
        }

        /*
         * bool inRangeToHit = this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.EnemyAnimation.sPosition.Y - 1
                                || this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.EnemyAnimation.sPosition.Y + 1
                                && this.Hero.CharacterAnimation.sPosition.X < this.Enemy.EnemyAnimation.sPosition.X - 1
                                || this.Hero.CharacterAnimation.sPosition.X < this.Enemy.EnemyAnimation.sPosition.X + 1;
         */

        public int Health
        {
            get { return this.health; }
            set
            {
                if (this.HealthChange != null)
                {
                    this.HealthChange(this,
                        new HealthChangedEventArgs(value, this.InitialHealth));
                }

                if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }

            }
        }

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

        public int Mana
        {
            get { return this.mana; }
            set
            {
                if (this.ManaChange != null)
                {
                    this.ManaChange(this,
                        new HealthChangedEventArgs(value, this.InitialMana));
                }
                if (value < 0)
                {
                    this.mana = 0;
                }
                else
                {
                    this.mana = value;
                }

            }
        }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        public TimeSpan TimeSinceLastRegen { get; set; }
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

        public void ManaRegen(GameTime gameTime)
        {

            if (this.Mana < InitialMana && gameTime.TotalGameTime - TimeSinceLastRegen > new TimeSpan(0, 0, 2))
            {
                this.Mana++;
                TimeSinceLastRegen = gameTime.TotalGameTime;
            }
        }
        private void BaseCharacter_HealthChange(BaseCharacter sender, HealthChangedEventArgs args)
        {
            this.HealthAnimation.ReRenderHealthBar(this.Health, this.InitialHealth);
        }
        private void BaseCharacter_ManaChange(BaseCharacter sender, HealthChangedEventArgs args)
        {
            this.ManaAnimation.ReRenderManaBar(this.Mana, this.InitialMana);
        }
    }
}
