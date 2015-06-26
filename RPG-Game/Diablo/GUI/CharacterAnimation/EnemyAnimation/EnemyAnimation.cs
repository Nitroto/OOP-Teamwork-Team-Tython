using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.CharacterAnimation.EnemyAnimation
{
    public abstract class EnemyAnimation: CharacterAnimation
    {
        public EnemyAnimation(Vector2 position, CharacterType characterType)
            : base(position)
        {
            this.CharacterType = characterType;
            this.ImgSource = @"res/characters/enemy/" + this.CharacterType.ToString().ToLower() + ".png";
        }
    }
}
