using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Diablo.GUI
{
    class Player : AnimatedSprite
    {
        private const int FrameWidth = 96;
        private const int FrameHeight = 96;
        float playerSpeed = 100f;
        private bool attacking = false;

        public Player(Vector2 position)
            : base(position)
        {
            this.FramesPerSecond = 12;
            this.AddAnimation(8, (0 * FrameHeight), 0, AnimationType.MoveRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (1 * FrameHeight), 0, AnimationType.MoveLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (2 * FrameHeight), 0, AnimationType.MoveDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (3 * FrameHeight), 0, AnimationType.MoveUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(11, (8 * FrameHeight), 0, AnimationType.AttackRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(11, (9 * FrameHeight), 0, AnimationType.AttackLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(11, (10 * FrameHeight), 0, AnimationType.AttackDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(11, (11 * FrameHeight), 0, AnimationType.AttackUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (24 * FrameHeight), 0, AnimationType.IdleRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (25 * FrameHeight), 0, AnimationType.IdleLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (26 * FrameHeight), 0, AnimationType.IdleDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (27 * FrameHeight), 0, AnimationType.IdleUp, FrameWidth, FrameHeight, new Vector2(0, 0));


            this.PlayAnimation(AnimationType.IdleDown);
        }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(@"res/barbarian/barbarian.png");
            //this.AddAnimation(8);
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
        private void HandleInput(KeyboardState keyState)
        {
            if (!attacking)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    //move up
                    this.sDirection += new Vector2(0, -1);
                    this.PlayAnimation(AnimationType.MoveUp);
                    this.currentDirection = Direction.Up;
                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    //move left
                    this.sDirection += new Vector2(-1, 0);
                    this.PlayAnimation(AnimationType.MoveLeft);
                    this.currentDirection = Direction.Left;
                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    //move down
                    this.sDirection += new Vector2(0, 1);
                    this.PlayAnimation(AnimationType.MoveDown);
                    this.currentDirection = Direction.Down;
                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    //move right
                    this.sDirection += new Vector2(1, 0);
                    this.PlayAnimation(AnimationType.MoveRight);
                    this.currentDirection = Direction.Right;
                }
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                if (this.currentAnimation.ToString().Contains("Up"))
                {
                    this.PlayAnimation(AnimationType.AttackUp);
                    this.currentDirection = Direction.Up;
                }
                if (this.currentAnimation.ToString().Contains("Down"))
                {
                    this.PlayAnimation(AnimationType.AttackDown);
                    this.currentDirection = Direction.Down;
                }
                if (this.currentAnimation.ToString().Contains("Right"))
                {
                    this.PlayAnimation(AnimationType.AttackRight);
                    this.currentDirection = Direction.Right;
                }
                if (this.currentAnimation.ToString().Contains("Left"))
                {
                    this.PlayAnimation(AnimationType.AttackLeft);
                    this.currentDirection = Direction.Left;
                }
                this.attacking = true;
            }
            else if (!attacking)
            {
                if (this.currentAnimation.ToString().Contains("Up"))
                {
                    this.PlayAnimation(AnimationType.IdleUp);
                }
                if (this.currentAnimation.ToString().Contains("Down"))
                {
                    this.PlayAnimation(AnimationType.IdleDown);
                }
                if (this.currentAnimation.ToString().Contains("Right"))
                {
                    this.PlayAnimation(AnimationType.IdleRight);
                }
                if (this.currentAnimation.ToString().Contains("Left"))
                {
                    this.PlayAnimation(AnimationType.IdleLeft);
                }
            }
            this.currentDirection = Direction.None;
        }

        public override void AnimationDone()
        {
            string animationType = this.currentAnimation.ToString();
            if (animationType.Contains("Attack"))
            {
                this.attacking = false;
            }
        }
    }
}
