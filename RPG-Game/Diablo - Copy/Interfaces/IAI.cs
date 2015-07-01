using Diablo.Logic.Characters.Enemies;
using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;

namespace Diablo.Interfaces
{
    interface IAI
    {
        BaseEnemy Enemy { get; }
        BaseCharacter Hero { get; }

        void Action(GameTime gameTime);
    }
}
