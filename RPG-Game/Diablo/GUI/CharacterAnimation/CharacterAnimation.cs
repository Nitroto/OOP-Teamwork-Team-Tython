using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.RegularExpressions;

namespace Diablo.GUI.CharacterAnimation
{
    public delegate void AddAnimationDelegate();
    abstract class CharacterAnimation : AnimatedSprite
    {
        public readonly int FrameWidth = 96;
        public readonly int FrameHeight = 96;
        float characterSpeed = 100f;
        private bool attacking = false;
        private bool isHitted = false;
        private bool dies = false;
        private bool isAlive = true;
        private bool castSpell = false;

        public CharacterAnimation(Vector2 position, CharactersType characterType)
            : base(position)
        {
            this.CharacterType = characterType;
            this.FramesPerSecond = 13;
            this.ImgSource = @"res/characters/" + this.CharacterType.ToString().ToLower() + ".png";
            this.PlayAnimation(AnimationType.IdleDown);
        }

        public string ImgSource { get; set; }
        public CharactersType CharacterType { get; set; }
        public int[] Frames { get; set; }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(this.ImgSource);
        }
        public override void Update(GameTime gameTime)
        {
            this.sDirection = Vector2.Zero;
            //if (this.isAlive)
            //{
            this.HandleInput(Keyboard.GetState());
            //}

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.sDirection *= characterSpeed;

            this.sPosition += (this.sDirection * deltaTime);

            base.Update(gameTime);
        }
        public override void AnimationDone()
        {
            string animationType = this.currentAnimation.ToString();
            if (animationType.Contains("Attack"))
            {
                this.attacking = false;
            }
            else if (animationType.Contains("CastSpell"))
            {
                this.castSpell = false;
            }
            else if (animationType.Contains("Hitted"))
            {
                this.isHitted = false;
            }
            // To be removed
            else if (animationType.Contains("Die"))
            {
                this.dies = false;
                this.isAlive = false;

            }

        }
        public void HandleAnimation()
        {
            var allAnimations = Enum.GetNames(typeof(AnimationType)).Length;
            int counter = 0;
            for (int i = 0; i < this.Frames.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.AddAnimation(this.Frames[i], this.FrameHeight * counter, (AnimationType)(counter));
                    counter++;
                }
            }
        }
        private void PositionAdjustment(Vector2 positionCorrection, AnimationType animType, Direction newDirection)
        {
            this.sDirection += positionCorrection;
            this.PlayAnimation(animType);
            this.currentDirection = newDirection;
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
        private void InitializeAnimation(string command)
        {
            var direction = Regex.Match(this.currentAnimation.ToString(), @"(DownRight|DownLeft|UpRight|UpLeft|Up|Down|Right|Left)");
            string animation = command + direction.Value;
            AnimationType animationType = (AnimationType)Enum.Parse(typeof(AnimationType), animation);
            this.PlayAnimation(animationType);
        }
        private void HandleInput(KeyboardState keyState)
        {
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
                        this.InitializeAnimation("Attack");
                        this.attacking = true;
                    }
                    else if (keyState.IsKeyDown(Keys.Up))
                    {
                        this.InitializeAnimation("CastSpell");
                        this.castSpell = true;
                    }
                    else if (!attacking && !castSpell && !isHitted)
                    {
                        this.InitializeAnimation("Idle");
                    }
                }
                else
                {
                    this.InitializeAnimation("Hitted");
                }
                this.currentDirection = Direction.None;
            }
            else
            {
                this.InitializeAnimation("Die");
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
            //
        }


    }
}
