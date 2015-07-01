using Diablo.GUI.CharacterAnimation.PlayerAnimation;
using Diablo.Interfaces;
using Microsoft.Xna.Framework;

namespace Diablo.Logic.Characters.Heroes
{
    public class Barbarian : BaseCharacter, IShield
    {
        private const int DefauldHealth = 300;
        private const int DefaultDamage = 32;
        private const int DefInitialMana = 64;
        private const int ManaCastCost = 8;


        public Barbarian(string name)
            : base(name, DefauldHealth, DefaultDamage, DefInitialMana)
        {
            this.CharacterAnimation = new BarbarianAnimation(new Vector2(-30, -20));
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
