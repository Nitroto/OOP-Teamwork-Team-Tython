using Diablo.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.RegularExpressions;

namespace Diablo.GUI.GamePLayScreen.CharacterAnimation
{
    public abstract class CharacterAnimation : AnimatedSprite
    {
        protected float characterSpeed = 100f;
        protected bool attacking = false;
        protected bool isHitted = false;
        protected bool dies = false;
        protected bool isAlive = true;

        protected CharacterAnimation(Vector2 position)
            : base(position)
        {
            this.FramesPerSecond = 13;
            this.PlayAnimation(AnimationType.IdleDown);

        }

        public string ImgSource { get; set; }
        public CharacterType CharacterType { get; set; }
        public int[] Frames { get; set; }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(this.ImgSource);
        }

        public override void Update(GameTime gameTime, KeyboardState keyState)
        {
            this.sDirection = Vector2.Zero;
            
            this.HandleAnimation(keyState);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.sDirection *= characterSpeed;
            this.sPosition += (this.sDirection * deltaTime);
            base.Update(gameTime, keyState);
        }

        public void PositionAdjustment(Vector2 positionCorrection, AnimationType animType, Direction newDirection)
        {
            this.sDirection += positionCorrection;
            this.PlayAnimation(animType);
            this.currentDirection = newDirection;
        }
        public void InitializeAnimation()
        {
            var allAnimations = Enum.GetNames(typeof(AnimationType)).Length;
            int counter = 0;
            for (int i = 0; i < this.Frames.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.AddAnimation(this.Frames[i], FrameHeight * counter, (AnimationType)(counter));
                    counter++;
                }
            }
        }

        protected abstract void HandleAnimation(KeyboardState keyState);

        public void RunAnimation(string command)
        {
            var direction = Regex.Match(this.currentAnimation.ToString(), @"(DownRight|DownLeft|UpRight|UpLeft|Up|Down|Right|Left)");
            string animation = command + direction.Value;
            AnimationType animationType = (AnimationType)Enum.Parse(typeof(AnimationType), animation);
            this.PlayAnimation(animationType);
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
            // To be removed
            else if (animationType.Contains("Die"))
            {
                this.dies = false;
                this.isAlive = false;
            }
        }
    }
}
