using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.GamePLayScreen.StatusBarAnimation
{
    public class Inventory : StatusBar
    {
        private const string ImgSource = @"res/bars/inventory.png";

        public Inventory(Vector2 position, BaseCharacter character)
            :base(position, ImgSource)
        {

        }
        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}
