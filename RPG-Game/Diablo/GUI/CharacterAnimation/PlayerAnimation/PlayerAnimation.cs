using Diablo.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI.CharacterAnimation.PlayerAnimation
{
    public abstract class PlayerAnimation : CharacterAnimation
    {
        private bool castSpell;

        protected PlayerAnimation(Vector2 position, CharacterType characterType)
            : base(position)
        {
            this.castSpell = false;
            this.CharacterType = characterType;
            this.ImgSource = @"res/characters/player/" + this.CharacterType.ToString().ToLower() + ".png";
        }

        private void Move(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.W))
            {
                if (keyState.IsKeyDown(Keys.A))
                {
                    //move up-left
                    this.PositionAdjustment(new Vector2(-1, -1), AnimationType.MoveUpLeft, Direction.UpLeft);
                }
                else if (keyState.IsKeyDown(Keys.D))
                {
                    //move up-right
                    this.PositionAdjustment(new Vector2(1, -1), AnimationType.MoveUpRight, Direction.UpRight);
                }
                else if (keyState.IsKeyDown(Keys.S))
                {
                    //stop
                    this.sDirection += new Vector2(0, 0);
                }
                else
                {
                    //move up
                    this.PositionAdjustment(new Vector2(0, -1), AnimationType.MoveUp, Direction.Up);
                }
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                if (keyState.IsKeyDown(Keys.A))
                {
                    //move down-left
                    this.PositionAdjustment(new Vector2(-1, 1), AnimationType.MoveDownLeft, Direction.DownLeft);
                }
                else if (keyState.IsKeyDown(Keys.D))
                {
                    //moce down-rigt
                    this.PositionAdjustment(new Vector2(1, 1), AnimationType.MoveDownRight, Direction.DowRight);
                }
                else if (keyState.IsKeyDown(Keys.W))
                {
                    //stop
                    this.sDirection += new Vector2(0, 0);
                }
                else
                {
                    //move down
                    this.PositionAdjustment(new Vector2(0, 1), AnimationType.MoveDown, Direction.Down);
                }
            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                if (keyState.IsKeyDown(Keys.D))
                {
                    //stop
                    this.sDirection += new Vector2(0, 0);
                }
                else
                {
                    //move left
                    this.PositionAdjustment(new Vector2(-1, 0), AnimationType.MoveLeft, Direction.Left);
                }
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                if (keyState.IsKeyDown(Keys.A))
                {
                    //stop
                    this.sDirection += new Vector2(0, 0);
                }
                else
                {
                    //move right
                    this.PositionAdjustment(new Vector2(1, 0), AnimationType.MoveRight, Direction.Right);
                }
            }
        }

        protected override void HandleAnimation(KeyboardState keyState)
        {
            //KeyboardState keyState = Keyboard.GetState();
            if (!dies)
            {
                if (!isHitted)
                {
                    if (!attacking && !castSpell)
                    {
                        this.Move(keyState);
                    }
                    if (keyState.IsKeyDown(Keys.Space))
                    {
                        this.RunAnimation("Attack");
                        this.attacking = true;
                    }
                    else if (keyState.IsKeyDown(Keys.Up))
                    {
                        this.RunAnimation("CastSpell");
                        this.castSpell = true;
                    }
                    else if (!attacking && !castSpell && !isHitted)
                    {
                        this.RunAnimation("Idle");
                    }
                }
                else
                {
                    this.RunAnimation("Hitted");
                }
                this.currentDirection = Direction.None;
            }
            else
            {
                this.RunAnimation("Die");
                this.dies = true;
            }

            // To be removed
            if (keyState.IsKeyDown(Keys.Down))
            {
                this.dies = true;
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                this.isHitted = true;
            }
        }
        public override void AnimationDone()
        {
            string animationType = this.currentAnimation.ToString();
            if (animationType.Contains("CastSpell"))
            {
                this.castSpell = false;
            }
            else
            {
                base.AnimationDone();
            }
        }
    }
}
