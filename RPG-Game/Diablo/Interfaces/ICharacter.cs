using Diablo.GUI.CharacterAnimation;
using Diablo.Logic.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack, IKillable
    {
        int Damage { get; set; }
        int Health { get; set; }
        List<IItem> Items { get; set; }

        void ApplyItems(Item item);
        void RemoveItems(Item item);
        CharacterAnimation CharacterAnimation { get; set; }
        void Update(GameTime gameTime);
        void CastSpell();
    }
}
