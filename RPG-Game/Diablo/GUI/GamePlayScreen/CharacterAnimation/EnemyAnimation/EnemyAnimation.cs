using Diablo.Enums;
using Microsoft.Xna.Framework;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation.EnemyAnimation
{
    public abstract class EnemyAnimation : CharacterAnimation
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
        public void MoveByY(GameTime gameTime, Direction direction)
        {
            if (direction == Direction.Up)
            {
                this.sPosition.Y--;
                this.PositionAdjustment(new Vector2(0, -1), AnimationType.MoveUp, direction);
                ((AnimatedSprite)this).Update(gameTime);
                this.currentDirection = Direction.None;
            }

            else
            {
                this.sPosition.Y++;
                this.PositionAdjustment(new Vector2(0, +1), AnimationType.MoveDown, Direction.Down);
                ((AnimatedSprite)this).Update(gameTime);
                this.currentDirection = Direction.None;
            }
        }
        public void MoveByX(GameTime gameTime, Direction direction)
        {
            if (direction == Direction.Up)
            {
                this.sPosition.X--;
                this.PositionAdjustment(new Vector2(+1, 0), AnimationType.MoveUp, direction);
                ((AnimatedSprite)this).Update(gameTime);
                this.currentDirection = Direction.None;
            }

            else
            {
                this.sPosition.X++;
                this.PositionAdjustment(new Vector2(-1, 0), AnimationType.MoveDown, Direction.Down);
                ((AnimatedSprite)this).Update(gameTime);
                this.currentDirection = Direction.None;
            }
        }
        public void PlayAttackAnimation(GameTime gameTime)
        {
            this.RunAnimation("Attack");
        }
    }
}
