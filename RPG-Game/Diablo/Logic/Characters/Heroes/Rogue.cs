using Diablo.GUI.CharacterAnimation.PlayerAnimation;
using Diablo.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.Logic.Characters.Heroes
{
    public class Rogue : BaseCharacter, IShield
    {
        private const int DefaultHealth = 180;
        private const int DefaultDamage = 20;
        private const int InitialHealth = 180;
        private const int InitialMana = 90;
        private const int ManaCastCost = 10;
        private Random rnd = new Random();

        public Rogue(string name) :
            base(name, DefaultHealth, DefaultDamage, InitialMana)
        {
            this.CharacterAnimation = new RogueAnimation(new Vector2(-30, -20));
        }

        public int Shield { get; set; }

        public override void CastSpell()
        {
            if (base.Mana >= ManaCastCost)
            {
                base.Mana -= ManaCastCost;
            }
        }
    }
}
