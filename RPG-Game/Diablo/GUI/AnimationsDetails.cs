using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI
{
    public delegate void AddAnimationDelegate();
    abstract class AnimationsDetails : AnimatedSprite
    {
        public readonly int FrameWidth = 96;
        public readonly int FrameHeight = 96;
        float playerSpeed = 100f;
        private bool attacking = false;
        private bool isHitted = false;
        private bool isDead = false;
        private bool castSPell = false;

        public abstract void HandleAnimation();
        public AnimationsDetails(Vector2 position, CharactersType characterType)
            : base(position)
        {
            this.CharacterType = characterType;
            this.FramesPerSecond = 13;
            this.ImgSource = @"res/characters/" + this.CharacterType.ToString().ToLower() + ".png";

            this.PlayAnimation(AnimationType.IdleDown);
        }
        public string ImgSource { get; set; }
        public CharactersType CharacterType { get; set; }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(this.ImgSource);
        }
        public override void Update(GameTime gameTime)
        {
            this.sDirection = Vector2.Zero;
            this.HandleInput(Keyboard.GetState());

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.sDirection *= playerSpeed;

            this.sPosition += (this.sDirection * deltaTime);

            base.Update(gameTime);
        }
        private void Move(Vector2 positionCorrection, AnimationType animType, Direction newDirection)
        {
            this.sDirection += positionCorrection;
            this.PlayAnimation(animType);
            this.currentDirection = newDirection;
        }
        private void HandleInput(KeyboardState keyState)
        {
            if (!attacking && !isHitted&&!isDead)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    if (keyState.IsKeyDown(Keys.A))
                    {
                        //move up-left
                        this.Move(new Vector2(-1, -1), AnimationType.MoveUpLeft, Direction.UpLeft);
                    }
                    else if (keyState.IsKeyDown(Keys.D))
                    {
                        //move up-right
                        this.Move(new Vector2(1, -1), AnimationType.MoveUpRight, Direction.UpRight);
                    }
                    else if (keyState.IsKeyDown(Keys.S))
                    {
                        //stop
                        this.sDirection += new Vector2(0, 0);
                    }
                    else
                    {
                        //move up
                        this.Move(new Vector2(0, -1), AnimationType.MoveUp, Direction.Up);
                    }
                }
                else if (keyState.IsKeyDown(Keys.S))
                {
                    if (keyState.IsKeyDown(Keys.A))
                    {
                        //move down-left
                        this.Move(new Vector2(-1, 1), AnimationType.MoveDownLeft, Direction.DownLeft);
                    }
                    else if (keyState.IsKeyDown(Keys.D))
                    {
                        //moce down-rigt
                        this.Move(new Vector2(1, 1), AnimationType.MoveDownRight, Direction.DowRight);
                    }
                    else if (keyState.IsKeyDown(Keys.W))
                    {
                        //stop
                        this.sDirection += new Vector2(0, 0);
                    }
                    else
                    {
                        //move down
                        this.Move(new Vector2(0, 1), AnimationType.MoveDown, Direction.Down);
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
                        this.Move(new Vector2(-1, 0), AnimationType.MoveLeft, Direction.Left);
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
                        this.Move(new Vector2(1, 0), AnimationType.MoveRight, Direction.Right);
                    }
                }
            }
            if (keyState.IsKeyDown(Keys.Space) && !isHitted && !isDead)
            {
                if (this.currentAnimation.ToString().Contains("Up"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.AttackUpLeft);
                        this.currentDirection = Direction.UpLeft;
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.AttackUpRight);
                        this.currentDirection = Direction.UpRight;
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.AttackUp);
                        this.currentDirection = Direction.Up;
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Down"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.AttackDownLeft);
                        this.currentDirection = Direction.DownLeft;
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.AttackDownRight);
                        this.currentDirection = Direction.DowRight;
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.AttackDown);
                        this.currentDirection = Direction.Down;
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Right"))
                {
                    this.PlayAnimation(AnimationType.AttackRight);
                    this.currentDirection = Direction.Right;
                }
                else if (this.currentAnimation.ToString().Contains("Left"))
                {
                    this.PlayAnimation(AnimationType.AttackLeft);
                    this.currentDirection = Direction.Left;
                }
                this.attacking = true;
            }
            else if (!attacking && !isHitted && !isDead)
            {
                if (this.currentAnimation.ToString().Contains("Up"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.IdleUpLeft);
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.IdleUpRight);
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.IdleUp);
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Down"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.IdleDownLeft);
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.IdleDownRight);
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.IdleDown);
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Right"))
                {
                    this.PlayAnimation(AnimationType.IdleRight);
                }
                else if (this.currentAnimation.ToString().Contains("Left"))
                {
                    this.PlayAnimation(AnimationType.IdleLeft);
                }
            }
            else if (isHitted && !attacking && !isDead)
            {
                if (this.currentAnimation.ToString().Contains("Up"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.HittedUpLeft);
                        this.currentDirection = Direction.UpLeft;
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.HittedUpRight);
                        this.currentDirection = Direction.UpRight;
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.HittedUp);
                        this.currentDirection = Direction.Up;
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Down"))
                {
                    if (this.currentAnimation.ToString().Contains("Left"))
                    {
                        this.PlayAnimation(AnimationType.HittedDownLeft);
                        this.currentDirection = Direction.DownLeft;
                    }
                    else if (this.currentAnimation.ToString().Contains("Right"))
                    {
                        this.PlayAnimation(AnimationType.HittedDownRight);
                        this.currentDirection = Direction.DowRight;
                    }
                    else
                    {
                        this.PlayAnimation(AnimationType.HittedDown);
                        this.currentDirection = Direction.Down;
                    }
                }
                else if (this.currentAnimation.ToString().Contains("Right"))
                {
                    this.PlayAnimation(AnimationType.HittedRight);
                    this.currentDirection = Direction.Right;
                }
                else if (this.currentAnimation.ToString().Contains("Left"))
                {
                    this.PlayAnimation(AnimationType.HittedLeft);
                    this.currentDirection = Direction.Left;
                }
            }
            else if (isDead)
            {

            }
            this.currentDirection = Direction.None;
            if (keyState.IsKeyDown(Keys.Down))
            {
                this.isHitted = true;
            }
        }

        public override void AnimationDone()
        {
            string animationType = this.currentAnimation.ToString();
            if (animationType.Contains("Attack"))
            {
                this.attacking = false;
            }
            else if (animationType.Contains("Hitted"))
            {
                this.isHitted = false;
            }
        }
    }
}
