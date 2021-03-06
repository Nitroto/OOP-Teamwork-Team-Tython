﻿using Diablo.GUI.GamePLayScreen.CharacterAnimation.PlayerAnimation;
using Microsoft.Xna.Framework;

namespace Diablo.Logic.Characters.Heroes
{
    public class Sorcerer : BaseCharacter
    {
        private const int DefaultHealth = 120;
        private const int DefaultDamage = 8;
        private const int DefInitialMana = 400;
        private const int ManaCastCost = 22;

        public Sorcerer(string name)
            : base(name, DefaultHealth, DefaultDamage, DefInitialMana)
        {
            this.CharacterAnimation = new SorcererAnimation(new Vector2(-30, -20));
        }

        public override void CastSpell()
        {
            if (base.Mana >= ManaCastCost)
            {
                base.Mana -= ManaCastCost;
            }
        }
    }
}
