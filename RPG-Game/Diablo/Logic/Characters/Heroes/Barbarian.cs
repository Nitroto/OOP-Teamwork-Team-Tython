using Diablo.GUI.CharacterAnimation.PlayerAnimation;
using Diablo.Interfaces;
using Microsoft.Xna.Framework;

namespace Diablo.Logic.Characters.Heroes
{
    public class Barbarian : BaseCharacter, IShield
    {
        private const int DefauldHealth = 300;
        private const int DefaultDamage = 32;
        private const int InitialMana = 64;


        public Barbarian(string name)
            : base(name, DefauldHealth, DefaultDamage, InitialMana)
        {
            this.CharacterAnimation = new BarbarianAnimation(new Vector2(-30, -20));
        }

        public int Shield { get; set; }

        public override void CastSpell()
        {
            throw new System.NotImplementedException();
        }

        public override void DecreaseMana()
        {
            throw new System.NotImplementedException();
        }
        public override void IncreaseMana()
        {
            this.ManaAnimation.ReRenderManaBar(base.Mana, InitialMana);
        }
        public override void ManaRegen(GameTime gameTime)
        {
            if (base.Mana < InitialMana)
            {
                base.Mana++;
            }
        }
    }
}
