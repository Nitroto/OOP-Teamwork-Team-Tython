using System;
using Diablo.Characters.Enemies;
using Diablo.Characters.Heroes;
using Diablo.Interfaces;

namespace Diablo.Factories
{
    class EnemyFactory
    {
        public ICharacter CreateCharacter()
        {
            Random rnd = new Random();
            switch (rnd.Next(1,4))
            {
                case 1: 
                    return new Orc();
                case 2:
                    return new Troll();
                default:
                    return new Zombie();
            }
        }
    }
}
