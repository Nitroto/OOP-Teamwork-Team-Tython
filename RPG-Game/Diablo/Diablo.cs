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

        private const int maxEnemis = 10;
        private static Random rnd = new Random();
        private ICharacter mainCharacter;
        private PlayerAnimation player;
        private EnemyAnimation[] enemys;
        private List<AnimatedSprite> animations = new List<AnimatedSprite>();
        private StatusBar health;
        private StatusBar mana;

        public Diablo()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

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
            this.mainCharacter = new Sorcerer("sorcerer");
            //this.player = new SorcererAnimation(new Vector2(-30,-20));
            enemys = new EnemyAnimation[maxEnemis];
            for (int i = 0; i < this.enemys.Length; i++)
            {
                int x = rnd.Next(0, 750);
                int y = rnd.Next(0, 350);
                CharacterType enemyType = (CharacterType)rnd.Next(3, 6);
                switch (enemyType)
                {
                    case CharacterType.GreyTroll: this.enemys[i] = new GreyTrollAnimation(new Vector2(x,y));break;
                    case CharacterType.Orc: this.enemys[i] = new OrcAnimation(new Vector2(x, y));break;
                    case CharacterType.Zombie: this.enemys[i] = new ZombieAnimation(new Vector2(x, y));break;
                }
                this.animations.Add(this.enemys[i]);
            }
            this.health = new Health((new Vector2(10, 400)),this.mainCharacter as BaseCharacter);
            this.mana = new Mana((new Vector2(740, 400)), this.mainCharacter as BaseCharacter);
            this.animations.Add(this.health);
            this.animations.Add(this.mana);
            this.animations.Add(this.mainCharacter.CharacterAnimation);
            //Load Content calls
            this.health.LoadContentent(Content);
            this.mainCharacter.CharacterAnimation.LoadContentent(Content);
            foreach(EnemyAnimation enemy in enemys)
            {
                enemy.LoadContentent(Content);
            }
            this.mana.LoadContentent(Content);
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
            //this.player.Update(gameTime);
            foreach (AnimatedSprite animation in animations)
            {
                animation.Update(gameTime);
            }
           // this.health.Update(gameTime);
           // this.mana.Update(gameTime);
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
            //this.health.Draw(spriteBatch);
            //this.player.Draw(spriteBatch);
            foreach (AnimatedSprite animation in animations)
            {
                animation.Draw(spriteBatch);
            }
           // this.mana.Draw(spriteBatch);
            
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
