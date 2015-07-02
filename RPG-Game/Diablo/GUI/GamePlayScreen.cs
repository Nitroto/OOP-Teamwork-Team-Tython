using Diablo.Enums;
using Diablo.GUI.GamePLayScreen;
using Diablo.GUI.GamePLayScreen.CharacterAnimation.EnemyAnimation;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Enemies;
using Diablo.Logic.Characters.Heroes;
using Diablo.Logic.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Diablo.GUI
{
    public class GamePlayScreen : GameScreen
    {
        private List<BaseEnemy> Enemies;
        private BaseEnemy TestEnemy;
        private List<AI> AI;

        private const int maxEnemies = 4;
        private static Random Rnd = new Random();

        public GamePlayScreen()
        {
            this.Animations = new List<AnimatedSprite>();
        }


        private List<AnimatedSprite> Animations { get; set; }
        private ICharacter MainCharacter { get; set; }
        public string CharacterChoice { get; set; }
        public Image Map { get; set; }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Map.LoadContent();
            switch (this.CharacterChoice)
            {
                case "Rogue": this.MainCharacter = new Rogue("rogue"); break;
                case "Barbarian": this.MainCharacter = new Barbarian("Barbarian"); break;
                case "Sorcerer": this.MainCharacter = new Sorcerer("Sorcerer"); break;
            }
            
            //this.player = new SorcererAnimation(new Vector2(-30,-20));
            this.TestEnemy = EnemyFactory.CreateCharacter();
            this.AI = new List<AI>();
            this.AI.Add(new AI(this.MainCharacter as BaseCharacter, this.TestEnemy));
            this.TestEnemy.EnemyAnimation = new OrcAnimation(new Vector2(300, -20));
            
            this.Enemies = new List<BaseEnemy>();
            for (int i = 0; i < maxEnemies; i++)
            {
                int x = Rnd.Next(0, 750);
                int y = Rnd.Next(0, 350);
                //CharacterType enemyType = (CharacterType)Rnd.Next(3, 6);

                //initialize enemy
                this.Enemies.Add(EnemyFactory.CreateCharacter());
                this.AI.Add(new AI(this.MainCharacter as BaseCharacter, this.Enemies[i]));
                CharacterType enemyType = (CharacterType)Enum.Parse(typeof(CharacterType), this.Enemies[i].GetType().Name);
                switch (enemyType)
                {
                    case CharacterType.GreyTroll:
                        this.Enemies[i].EnemyAnimation = new GreyTrollAnimation(new Vector2(x, y));
                        this.Animations.Add(this.Enemies[i].EnemyAnimation); break;
                    case CharacterType.Orc:
                        this.Enemies[i].EnemyAnimation = new OrcAnimation(new Vector2(x, y));
                        this.Animations.Add(this.Enemies[i].EnemyAnimation); break;
                    case CharacterType.Zombie:
                        this.Enemies[i].EnemyAnimation = new ZombieAnimation(new Vector2(x, y));
                        this.Animations.Add(this.Enemies[i].EnemyAnimation); break;
                }
            }
            ((BaseCharacter)this.MainCharacter).EnemiesToFight = this.Enemies;

            this.Animations.Add(this.MainCharacter.CharacterAnimation);

            //Load Content calls
            (this.MainCharacter as BaseCharacter).HealthAnimation.LoadContentent(content);
            this.MainCharacter.CharacterAnimation.LoadContentent(content);
            foreach (BaseEnemy enemy in this.Enemies)
            {
                enemy.EnemyAnimation.LoadContentent(content);
            }
            (this.MainCharacter as BaseCharacter).ManaAnimation.LoadContentent(content);
            this.TestEnemy.EnemyAnimation.LoadContentent(content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.Map.Update(gameTime);
            this.MainCharacter.Update(gameTime);
            foreach (AI ai in AI)
            {
                ai.Action(gameTime);
            }
            for (int i = 0; i < this.Enemies.Count; i++)
            {
                var enemy = this.Enemies[i];
                if (!((BaseCharacter)this.MainCharacter).EnemiesToFight.Contains(enemy))
                {
                    this.Enemies.Remove(enemy);
                }
            }
            //this.AI.Action(gameTime);
            //foreach (AnimatedSprite animation in animations)
            //{
            //    animation.Update(gameTime);
            //}
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.Map.Draw(spriteBatch);
            foreach (AnimatedSprite animation in this.Animations)
            {
                animation.Draw(spriteBatch);
            }
            (this.MainCharacter as BaseCharacter).HealthAnimation.Draw(spriteBatch);
            (this.MainCharacter as BaseCharacter).ManaAnimation.Draw(spriteBatch);
            this.TestEnemy.EnemyAnimation.Draw(spriteBatch);
        }
    }
}
