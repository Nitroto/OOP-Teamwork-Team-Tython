using System;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Enemies;

namespace Diablo.Logic.Factories
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
                    return new GreyTroll();
                default:
                    return new Zombie();
            }
        }
    }
}
