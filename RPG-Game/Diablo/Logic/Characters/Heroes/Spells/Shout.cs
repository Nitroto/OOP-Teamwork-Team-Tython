using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes.Spells
{
    public class Shout : Spell
    {
        public Shout() : base("Shout", 40)
        {
        }

        public override void ApplySpell(ICharacter caster, ICharacter targetEnemy)
        {
            caster.Health += 20;
        }
    }
}
