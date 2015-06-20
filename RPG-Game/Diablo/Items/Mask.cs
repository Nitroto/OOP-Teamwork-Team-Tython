using Diablo.Items.Enums;

namespace Diablo.Items
{
    class Mask : Item
    {
        new private const int Health = 0;
        new private const int Mana = 0;

        public Mask(Color maskColor)
            : base(maskColor.ToString(), Health, (int)maskColor, Mana)
        {
            this.Color = maskColor;
        }
    }
}
