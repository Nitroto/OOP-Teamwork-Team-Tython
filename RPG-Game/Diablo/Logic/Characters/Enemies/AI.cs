using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diablo.Logic.Characters.Heroes;
using Microsoft.Xna.Framework.Input;

namespace Diablo.Logic.Characters.Enemies
{
    public class AI
    {
        private const int CharWidthHeigth = 96;
        private const int EnemyRange = CharWidthHeigth*2;
        private int positionCounter;
        private bool patrolLeft = false;

        public AI(Diablo diablo,BaseEnemy enemy, Vector2 currentPosition)
        {
            this.Diablo = diablo;
            this.Enemy = enemy;
            this.CurrentPosition = currentPosition;
            positionCounter = 0;
        }


        public Diablo Diablo { get; private set; }
        public BaseEnemy Enemy { get;private set; }
        public Vector2 CurrentPosition { get; private set; }
        public BaseCharacter Hero { get; private set; }

        public void GetNewPosition()
        {
            if (HeroInRange())
            {
                GetCloserToHero();
            }
            else
            {
                RotatePatrol();

                if (this.patrolLeft)
                {
                    this.Enemy.CharacterAnimation.sPosition.Y--;
                }
                else
                {
                    this.Enemy.CharacterAnimation.sPosition.Y++;
                }

                this.positionCounter++;
            }
        }

        private void GetCloserToHero()
        {
            if (this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.CharacterAnimation.sPosition.Y)
            {
                this.Enemy.CharacterAnimation.sPosition.Y++;
            }
            else if (this.Hero.CharacterAnimation.sPosition.Y < this.Enemy.CharacterAnimation.sPosition.Y)
            {
                this.Enemy.CharacterAnimation.sPosition.Y--;
            }


            if (this.Hero.CharacterAnimation.sPosition.X > this.Enemy.CharacterAnimation.sPosition.X)
            {
                this.Enemy.CharacterAnimation.sPosition.X++;
            }
            else if (this.Hero.CharacterAnimation.sPosition.X < this.Enemy.CharacterAnimation.sPosition.X)
            {
                this.Enemy.CharacterAnimation.sPosition.X--;
            }

            bool inRangeToHit = this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.CharacterAnimation.sPosition.Y - 1
                                || this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.CharacterAnimation.sPosition.Y + 1
                                && this.Hero.CharacterAnimation.sPosition.X < this.Enemy.CharacterAnimation.sPosition.X - 1
                                || this.Hero.CharacterAnimation.sPosition.X < this.Enemy.CharacterAnimation.sPosition.X + 1;

            if (inRangeToHit)
            {
                HittingTheHero();
            }
        }

        private void RotatePatrol()
        {
            if (this.positionCounter%5 == 0)
            {
                if (this.patrolLeft)
                {
                    this.patrolLeft = false;
                }
                else
                {
                    this.patrolLeft = true;
                }
            }
        }

        private void HittingTheHero()
        {
            this.Enemy.Attack(this.Hero);
            //TODO ADD ANIMATION
        }


        private bool HeroInRange()
        {
            float enemyX = this.Enemy.CharacterAnimation.sPosition.X;
            float enemyY = this.Enemy.CharacterAnimation.sPosition.X;

            bool isInRange = enemyX * enemyX + enemyY * enemyY <= EnemyRange * EnemyRange;

            return isInRange;
        }
    }
}
