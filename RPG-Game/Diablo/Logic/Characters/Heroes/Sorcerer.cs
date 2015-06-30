using Microsoft.Xna.Framework;
using Diablo.GUI.CharacterAnimation.PlayerAnimation;

namespace Diablo.Logic.Characters.Heroes
{
    public class Sorcerer : BaseCharacter
    {
        private const int Health = 120;
        private const int Damage = 8;
        private const int InitialMana = 400;

        public Sorcerer(string name)
            : base(name, Health, Damage, InitialMana)
        {
            this.CharacterAnimation = new SorcererAnimation(new Vector2(-30, -20));
        }

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
            this.ManaAnimation.Decrease(base.Mana, InitialMana);
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
