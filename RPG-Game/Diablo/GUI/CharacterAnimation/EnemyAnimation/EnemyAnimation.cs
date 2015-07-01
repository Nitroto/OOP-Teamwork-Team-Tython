using Diablo.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI.CharacterAnimation.EnemyAnimation
{
    public abstract class EnemyAnimation: CharacterAnimation
    {
        protected EnemyAnimation(Vector2 position, CharacterType characterType)
            : base(position)
        {
            this.CharacterType = characterType;
            this.ImgSource = @"res/characters/enemy/" + this.CharacterType.ToString().ToLower() + ".png";
        }
        public void UpdateAnimation(GameTime gameTime)
        {
            this.sDirection = Vector2.Zero;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.sDirection *= characterSpeed;
            this.sPosition += (this.sDirection * deltaTime);
        }
    }
}
