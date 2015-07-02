using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using System;

namespace Diablo.GUI.GamePLayScreen.StatusBarAnimation
{
    public class Inventory : StatusBar
    {
        private const string InventoryImgPath = @"res/bars/inventory.png";
        private const string InventoryFrame = @"res/bars/inventoryFrame.png";

        public Inventory(Vector2 position, BaseCharacter character)
            :base(position, InventoryImgPath, InventoryFrame)
        {

        }
        public override void AnimationDone()
        {
            throw new NotImplementedException();
        }
    }
}
