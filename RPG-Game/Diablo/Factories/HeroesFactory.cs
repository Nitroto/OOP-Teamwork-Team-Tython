using System;
using Diablo.Characters.Heroes;
using Diablo.Enums;
using Diablo.Interfaces;

namespace Diablo.Factories
{
    class HeroesFactory
    {
        public ICharacter CreateHero(HeroType heroe, string name)
        {
            switch (heroe)
            {
                case HeroType.Berberian: 
                    return new Barbarian(name);
                case HeroType.Rogue:
                    return new Rogue(name);
                case HeroType.Sorcerer:
                    return new Sorcerer(name);
                default:
                    throw new NotSupportedException("Heroe type not supported");
            }
        }
    }
}
