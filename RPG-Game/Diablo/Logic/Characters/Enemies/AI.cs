using Diablo.Enums;
using Diablo.GUI.GamePLayScreen;
using Diablo.Interfaces;
using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Diablo.Logic.Characters.Enemies
{
    public class AI : IAI
    {
        private const int CharWidthHeigth = 96;
        private const int EnemyRange = CharWidthHeigth;
        private bool patrolLeft;

        public AI(BaseCharacter hero, BaseEnemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
            patrolLeft = false;
        }

        public BaseEnemy Enemy { get; private set; }
        public BaseCharacter Hero { get; private set; }
        public TimeSpan LastRotation { get; set; }
        public TimeSpan LastHit { get; set; }

        public void Action(GameTime gameTime)
        {

            if (HeroInRange())
            {
                GetCloserToHero(gameTime);
            }
            else
            {

                RotatePatrol(gameTime);
                //TODO ADD ANIMATION
                if (this.patrolLeft)
                {
                    this.Enemy.EnemyAnimation.MoveByY(gameTime, Direction.Up);
                }
                else
                {
                    this.Enemy.EnemyAnimation.MoveByY(gameTime, Direction.Down);
                }
            }
            ((AnimatedSprite)this.Enemy.EnemyAnimation).Update(gameTime, new KeyboardState());
        }

        private void GetCloserToHero(GameTime gameTime)
        {
            //TODO ADD ANIMATION
            if (this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.EnemyAnimation.sPosition.Y + 40)
            {
                this.Enemy.EnemyAnimation.MoveByY(gameTime, Direction.Down);
            }
            else if (this.Hero.CharacterAnimation.sPosition.Y < this.Enemy.EnemyAnimation.sPosition.Y - 40)
            {
                this.Enemy.EnemyAnimation.MoveByY(gameTime, Direction.Up);
            }

            //TODO ADD ANIMATION
            if (this.Hero.CharacterAnimation.sPosition.X > this.Enemy.EnemyAnimation.sPosition.X + 40)
            {
                this.Enemy.EnemyAnimation.MoveByX(gameTime, Direction.Down);
            }
            else if (this.Hero.CharacterAnimation.sPosition.X < this.Enemy.EnemyAnimation.sPosition.X - 40)
            {
                this.Enemy.EnemyAnimation.MoveByX(gameTime, Direction.Up);
            }

            bool inRangeToHit = this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.EnemyAnimation.sPosition.Y - 1
                                || this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.EnemyAnimation.sPosition.Y + 1
                                && this.Hero.CharacterAnimation.sPosition.X < this.Enemy.EnemyAnimation.sPosition.X - 1
                                || this.Hero.CharacterAnimation.sPosition.X < this.Enemy.EnemyAnimation.sPosition.X + 1;

            if (inRangeToHit)
            {
                HitTheHero(gameTime);
            }
        }

        private void RotatePatrol(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - this.LastRotation > new TimeSpan(0, 0, 2))
            {
                if (this.patrolLeft)
                {
                    this.patrolLeft = false;
                    this.LastRotation = gameTime.TotalGameTime;
                }
                else
                {
                    this.patrolLeft = true;
                    this.LastRotation = gameTime.TotalGameTime;
                }
            }
        }

        private void HitTheHero(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - this.LastHit > new TimeSpan(0, 0, 1))
            {
                this.Enemy.Attack(this.Hero);
                this.Enemy.EnemyAnimation.PlayAttackAnimation(gameTime);
                this.LastHit = gameTime.TotalGameTime;
                //this.Hero.CharacterAnimation.Update(gameTime, keyState.IsKeyDown(Keys.Up));
                //TODO ADD ANIMATION
            }
        }


        private bool HeroInRange()
        {
            float enemyX = this.Enemy.EnemyAnimation.sPosition.X;
            float enemyY = this.Enemy.EnemyAnimation.sPosition.Y;

            float heroX = this.Hero.CharacterAnimation.sPosition.X;
            float heroY = this.Hero.CharacterAnimation.sPosition.Y;


            bool isInRange = enemyX + EnemyRange > heroX && enemyX - EnemyRange < heroX
                             && enemyY + EnemyRange > heroY && enemyY - EnemyRange < heroY;

            return isInRange;
        }
    }
}
