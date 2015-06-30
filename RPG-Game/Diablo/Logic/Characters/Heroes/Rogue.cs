﻿using Diablo.GUI.CharacterAnimation.PlayerAnimation;
using Diablo.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.Logic.Characters.Heroes
{
    public class Rogue : BaseCharacter, IShield
    {
        private const int InitialHealth = 180;
        private const int Damage = 20;
        private const int InitialMana = 90;
        private const int ManaCastCost = 10;
        private Random rnd = new Random();

        public Rogue(string name) :
            base(name, InitialHealth, Damage, InitialMana)
        {
            this.CharacterAnimation = new RogueAnimation(new Vector2(-30, -20));
        }

        public int Shield { get; set; }

        public TimeSpan TimeSinceLastRegen { get; set; }

        public override void CastSpell()
        {
            if (base.Mana >= ManaCastCost)
            {
                base.Mana -= ManaCastCost;
            }
        }

        public override void DecreaseMana()
        {
            if (base.Mana >= ManaCastCost)
            {
                this.ManaAnimation.ReRenderManaBar(base.Mana, InitialMana);
            }

        }
        public override void IncreaseMana()
        {
            this.ManaAnimation.ReRenderManaBar(base.Mana, InitialMana);
        }
        public override void ManaRegen(GameTime gameTime)
        {

            if (base.Mana < InitialMana && gameTime.TotalGameTime - TimeSinceLastRegen > new TimeSpan(0, 0, 2))
            {
                base.Mana++;
                TimeSinceLastRegen = gameTime.TotalGameTime;
            }
        }
        protected override void BaseCharacter_HealthChange(BaseCharacter sender, HealthChangedEventArgs args)
        {
            this.HealthAnimation.ReRenderHealthBar(base.Health, base.InitialHealth);
        }
    }
}
