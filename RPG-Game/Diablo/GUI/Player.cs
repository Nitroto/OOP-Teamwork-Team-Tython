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
        private bool isHitted = false;
        private bool isDead = false;
        private bool castSPell = false;

        public Player(Vector2 position)
            : base(position)
        {
            this.FramesPerSecond = 13;
            this.AddAnimation(8, (0 * FrameHeight), 0, AnimationType.MoveRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (1 * FrameHeight), 0, AnimationType.MoveLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (2 * FrameHeight), 0, AnimationType.MoveDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (3 * FrameHeight), 0, AnimationType.MoveUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (4 * FrameHeight), 0, AnimationType.MoveDownRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (5 * FrameHeight), 0, AnimationType.MoveDownLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (6 * FrameHeight), 0, AnimationType.MoveUpRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, (7 * FrameHeight), 0, AnimationType.MoveUpLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (8 * FrameHeight), 0, AnimationType.AttackRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (9 * FrameHeight), 0, AnimationType.AttackLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (10 * FrameHeight), 0, AnimationType.AttackDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (11 * FrameHeight), 0, AnimationType.AttackUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (12 * FrameHeight), 0, AnimationType.AttackDownRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (13 * FrameHeight), 0, AnimationType.AttackDownLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (14 * FrameHeight), 0, AnimationType.AttackUpRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(13, (15 * FrameHeight), 0, AnimationType.AttackUpLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (16 * FrameHeight), 0, AnimationType.HittedRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (17 * FrameHeight), 0, AnimationType.HittedLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (18 * FrameHeight), 0, AnimationType.HittedDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (19 * FrameHeight), 0, AnimationType.HittedUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (20 * FrameHeight), 0, AnimationType.HittedDownRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (21 * FrameHeight), 0, AnimationType.HittedDownLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (22 * FrameHeight), 0, AnimationType.HittedUpRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(9, (23 * FrameHeight), 0, AnimationType.HittedUpLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (24 * FrameHeight), 0, AnimationType.IdleRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (25 * FrameHeight), 0, AnimationType.IdleLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (26 * FrameHeight), 0, AnimationType.IdleDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (27 * FrameHeight), 0, AnimationType.IdleUp, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (28 * FrameHeight), 0, AnimationType.IdleDownRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (29 * FrameHeight), 0, AnimationType.IdledDownLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (30 * FrameHeight), 0, AnimationType.IdleUpRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(1, (31 * FrameHeight), 0, AnimationType.IdleUpLeft, FrameWidth, FrameHeight, new Vector2(0, 0));


            this.PlayAnimation(AnimationType.IdleDown);
        }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(@"res/characters/sorcerer.png");
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
            if (!attacking && !isHitted&&!isDead)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    if (keyState.IsKeyDown(Keys.A))
                    {
                        //move up-left
                        this.sDirection += new Vector2(-1, -1);
                        this.PlayAnimation(AnimationType.MoveUpLeft);
                        this.currentDirection = Direction.UpLeft;
                    }
                    else if (keyState.IsKeyDown(Keys.D))
                    {
                        //move up-right
                        this.sDirection += new Vector2(1, -1);
                        this.PlayAnimation(AnimationType.MoveUpRight);
                        this.currentDirection = Direction.UpRight;
                    }
                    else if (keyState.IsKeyDown(Keys.S))
                    {
                        //stop
                        this.sDirection += new Vector2(0, 0);
                    }
                    else
                    {
                        //move up
                        this.sDirection += new Vector2(0, -1);
                        this.PlayAnimation(AnimationType.MoveUp);
                        this.currentDirection = Direction.Up;
                    }
                }
                else if (keyState.IsKeyDown(Keys.S))
                {
                    if (keyState.IsKeyDown(Keys.A))
                    {
                        //move down-left
                        this.sDirection += new Vector2(-1, 1);
                        this.PlayAnimation(AnimationType.MoveDownLeft);
                        this.currentDirection = Direction.DownLeft;
                    }
                    else if (keyState.IsKeyDown(Keys.D))
                    {
                        //moce down-rigt
                        this.sDirection += new Vector2(1, 1);
                        this.PlayAnimation(AnimationType.MoveDownRight);
                        this.currentDirection = Direction.DowRight;
                    }
                    else if (keyState.IsKeyDown(Keys.W))
                    {
                        //stop
                        this.sDirection += new Vector2(0, 0);
                    }
                    else
                    {
                        //move down
                        this.sDirection += new Vector2(0, 1);
                        this.PlayAnimation(AnimationType.MoveDown);
                        this.currentDirection = Direction.Down;
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
                        this.sDirection += new Vector2(-1, 0);
                        this.PlayAnimation(AnimationType.MoveLeft);
                        this.currentDirection = Direction.Left;
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
                        this.sDirection += new Vector2(1, 0);
                        this.PlayAnimation(AnimationType.MoveRight);
                        this.currentDirection = Direction.Right;
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
                        this.PlayAnimation(AnimationType.IdledDownLeft);
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
