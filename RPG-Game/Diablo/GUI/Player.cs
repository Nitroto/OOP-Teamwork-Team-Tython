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

        public Player(Vector2 position)
            : base(position)
        {
            this.FramesPerSecond = 12;
            this.AddAnimation(8, 0, 0, "Right", FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 96, 0, "Left", FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 192, 0, "Down", FrameWidth, FrameHeight, new Vector2(0, 0));
            this.AddAnimation(8, 288, 0, "Up", FrameWidth, FrameHeight, new Vector2(0, 0));
            //this.AddAnimation(1, 0, 0, "IdleRight", FrameWidth, FrameHeight, new Vector2(0, 0));
            //this.AddAnimation(1, 96, 0, "IdleLeft", FrameWidth, FrameHeight, new Vector2(0, 0));
            //this.AddAnimation(1, 192, 0, "IdleDown", FrameWidth, FrameHeight, new Vector2(0, 0));
            //this.AddAnimation(1, 288, 0, "IdleUp", FrameWidth, FrameHeight, new Vector2(0, 0));


            this.PlayAnimation("Right");
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
            if (keyState.IsKeyDown(Keys.W))
            {
                //move up
                this.sDirection += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                //move left
                this.sDirection += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                //move down
                this.sDirection += new Vector2(0, 1);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                //move right
                this.sDirection += new Vector2(1, 0);
            }

        }
    }
}
