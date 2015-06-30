using Diablo.Enums;
using Diablo.GUI;
using Diablo.GUI.CharacterAnimation.EnemyAnimation;
using Diablo.GUI.CharacterAnimation.PlayerAnimation;
using Diablo.GUI.StatusBarAnimation;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Diablo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Diablo : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private const int maxEnemies = 10;
        private static Random Rnd = new Random();
        private PlayerAnimation player;
        private EnemyAnimation[] enemies;
        private List<AnimatedSprite> animations;
        public List<BaseCharacter> heroes;

        public Diablo()
        {
            animations = new List<AnimatedSprite>();
            heroes = new List<BaseCharacter>();
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }


        private ICharacter MainCharacter { get; set; }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.MainCharacter = new Rogue("rogue");
            //this.player = new SorcererAnimation(new Vector2(-30,-20));
            enemies = new EnemyAnimation[maxEnemies];
            for (int i = 0; i < this.enemies.Length; i++)
            {
                int x = Rnd.Next(0, 750);
                int y = Rnd.Next(0, 350);
                CharacterType enemyType = (CharacterType)Rnd.Next(3, 6);
                switch (enemyType)
                {
                    case CharacterType.GreyTroll: this.enemies[i] = new GreyTrollAnimation(new Vector2(x,y));break;
                    case CharacterType.Orc: this.enemies[i] = new OrcAnimation(new Vector2(x, y));break;
                    case CharacterType.Zombie: this.enemies[i] = new ZombieAnimation(new Vector2(x, y));break;
                }
                this.animations.Add(this.enemies[i]);
            }
            //this.health = new Health((new Vector2(10, 400)),this.mainCharacter as BaseCharacter);
            //this.mana = new Mana((new Vector2(740, 400)), this.mainCharacter as BaseCharacter);
            //this.animations.Add(this.health);
            //this.animations.Add(this.mana);
            this.animations.Add(this.MainCharacter.CharacterAnimation);
            //Load Content calls
            (this.MainCharacter as BaseCharacter).HealthAnimation.LoadContentent(Content);
            this.MainCharacter.CharacterAnimation.LoadContentent(Content);
            foreach(EnemyAnimation enemy in enemies)
            {
                enemy.LoadContentent(Content);
            }
            (this.MainCharacter as BaseCharacter).ManaAnimation.LoadContentent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this.MainCharacter.Update(gameTime);
            //foreach (AnimatedSprite animation in animations)
            //{
            //    animation.Update(gameTime);
            //}
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin();
            foreach (AnimatedSprite animation in animations)
            {
                animation.Draw(spriteBatch);
            }
            (this.MainCharacter as BaseCharacter).HealthAnimation.Draw(spriteBatch);
            (this.MainCharacter as BaseCharacter).ManaAnimation.Draw(spriteBatch);
            
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
