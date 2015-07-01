using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes.Spells
{
    public class FireBolt : Spell
    {
        public FireBolt() : base("Fire Bolt", 45)
        {
        }

        public override void ApplySpell(ICharacter caster, ICharacter targetEnemy)
        {
            targetEnemy.Health -= 14;
        }
    }
}
