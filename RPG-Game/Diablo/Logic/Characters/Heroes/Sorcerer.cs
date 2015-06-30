using Microsoft.Xna.Framework;
using Diablo.GUI.CharacterAnimation.PlayerAnimation;

namespace Diablo.Logic.Characters.Heroes
{
    public class Sorcerer : BaseCharacter
    {
        private const int Health = 120;
        private const int Damage = 8;
        private const int InitialMana = 400;
        private const int ManaCastCost = 22;

        public Sorcerer(string name)
            : base(name, Health, Damage, InitialMana)
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
