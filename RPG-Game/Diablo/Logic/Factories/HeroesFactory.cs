using System;
using Diablo.Enums;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Heroes;

namespace Diablo.Logic.Factories
{
    class HeroesFactory
    {
        public ICharacter CreateHero(CharacterType heroe, string name)
        {
            switch (heroe)
            {
                case CharacterType.Barbarian: 
                    return new Barbarian(name);
                case CharacterType.Rogue:
                    return new Rogue(name);
                case CharacterType.Sorcerer:
                    return new Sorcerer(name);
                default:
                    throw new NotSupportedException("Heroe type not supported");
            }
        }
    }
}
