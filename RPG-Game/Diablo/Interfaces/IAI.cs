using Diablo.Logic.Characters.Enemies;
using Diablo.Logic.Characters.Heroes;

namespace Diablo.Interfaces
{
    interface IAI
    {
        BaseEnemy Enemy { get; }
        BaseCharacter Hero { get; }

        void Action();
    }
}
