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
            this.AddAnimation(8, 0, 0, AnimationType.Right, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 96, 0, AnimationType.Left, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 192, 0, AnimationType.Down, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 288, 0, AnimationType.Up, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 0, 0, AnimationType.IdleRight, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 96, 0, AnimationType.IdleLeft, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 192, 0, AnimationType.IdleDown, FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 288, 0, AnimationType.IdleUp, FrameWidth, FrameHeight, new Vector2(0, 0));


            this.PlayAnimation(AnimationType.Down);
        }

        public void LoadContentent(ContentManager contentManager)
        {
            this.sTexture = contentManager.Load<Texture2D>(@"res\barbarian\barbarian-movements.png");
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
                    this.PlayAnimation(AnimationType.Up);
                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    //move left
                    this.sDirection += new Vector2(-1, 0);
                    this.PlayAnimation(AnimationType.Left);
                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    //move down
                    this.sDirection += new Vector2(0, 1);
                    this.PlayAnimation(AnimationType.Down);
                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    //move right
                    this.sDirection += new Vector2(1, 0);
                    this.PlayAnimation(AnimationType.Right);
                }
            }
            //if (keyState.IsKeyDown(Keys.Space))
            //{
            //    if (this.currentAnimation == AnimationType.Up)
            //    {
            //        this.PlayAnimation(AnimationType.AttackUp);
            //    }
            //    if (this.currentAnimation == AnimationType.Down)
            //    {
            //        this.PlayAnimation(AnimationType.AttackDown);
            //    }
            //    if (this.currentAnimation == AnimationType.Right)
            //    {
            //        this.PlayAnimation(AnimationType.AttackRight);
            //    }
            //    if (this.currentAnimation == AnimationType.Left)
            //    {
            //        this.PlayAnimation(AnimationType.AttackLeft);
            //    }
            //}
            //else if (!attacking)
            //{
            //    if (this.currentAnimation == AnimationType.Up)
            //    {
            //        this.PlayAnimation(AnimationType.IdleUp);
            //    }
            //    if (this.currentAnimation == AnimationType.Down)
            //    {
            //        this.PlayAnimation(AnimationType.IdleDown);
            //    }
            //    if (this.currentAnimation == AnimationType.Right)
            //    {
            //        this.PlayAnimation(AnimationType.IdleRight);
            //    }
            //    if (this.currentAnimation == AnimationType.Left)
            //    {
            //        this.PlayAnimation(AnimationType.IdleLeft);
            //    }
            //}
        }
    }
}
