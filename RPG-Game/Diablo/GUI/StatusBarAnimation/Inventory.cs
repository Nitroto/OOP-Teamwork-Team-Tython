using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.StatusBarAnimation
{
    public class Inventory : StatusBar
    {
        private const string imgSource = @"res/bars/inventory.png";

        public Inventory(Vector2 position, BaseCharacter character)
            :base(position, imgSource)
        {

        }
        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}
