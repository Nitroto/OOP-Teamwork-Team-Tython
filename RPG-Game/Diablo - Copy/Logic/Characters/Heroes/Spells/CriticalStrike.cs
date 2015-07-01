using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes.Spells
{
    public class CriticalStrike : Spell
    {
        public CriticalStrike() : base("Critical Strike", 50)
        {
        }

        public override void ApplySpell(ICharacter caster, ICharacter targetEnemy)
        {
            caster.Damage *= 2;
        }
    }
}
