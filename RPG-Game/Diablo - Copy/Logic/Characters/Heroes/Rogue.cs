using Diablo.GUI.GamePLayScreen.CharacterAnimation.PlayerAnimation;
using Diablo.Interfaces;
using Microsoft.Xna.Framework;

namespace Diablo.Logic.Characters.Heroes
{
    public class Rogue : BaseCharacter, IShield
    {
        private const int DefaultHealth = 180;
        private const int DefaultDamage = 20;
        private const int DefInitialHealth = 180;
        private const int DefInitialMana = 90;
        private const int ManaCastCost = 10;

        public Rogue(string name) :
            base(name, DefaultHealth, DefaultDamage, DefInitialMana)
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
