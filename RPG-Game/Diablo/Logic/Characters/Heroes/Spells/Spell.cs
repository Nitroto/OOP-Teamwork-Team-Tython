using Diablo.Interfaces;

namespace Diablo.Logic.Characters.Heroes.Spells
{
    public abstract class Spell
    {
        protected Spell(string name, int manaCost)
        {
            this.Name = name;
            this.ManaCost = manaCost;
        }

        public int ManaCost { get; set; }

        public string Name { get; set; }

        public void Cast(ICharacter caster, ICharacter targetEnemy)
        {
            caster.CastSpell();
            ApplySpell(caster, targetEnemy);
        }

        public abstract void ApplySpell(ICharacter caster, ICharacter targetEnemy);
    }
}
