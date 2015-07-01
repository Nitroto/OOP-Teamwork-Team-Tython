using Diablo.Interfaces;
using Diablo.Logic.Characters.Heroes;

namespace Diablo.Logic.Characters.Enemies
{
    public class AI : IAI
    {
        private const int CharWidthHeigth = 96;
        private const int EnemyRange = CharWidthHeigth*2;
        private int positionCounter;
        private bool patrolLeft;

        public AI(BaseCharacter hero,BaseEnemy enemy)
        {
            this.Hero = hero;
            this.Enemy = enemy;
            positionCounter = 0;
            patrolLeft = false;
        }

        public BaseEnemy Enemy { get;private set; }
        public BaseCharacter Hero { get; private set; }

        public void Action()
        {
            if (HeroInRange())
            {
                GetCloserToHero();
            }
            else
            {
                RotatePatrol();

                //TODO ADD ANIMATION
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
            //TODO ADD ANIMATION
            if (this.Hero.CharacterAnimation.sPosition.Y > this.Enemy.CharacterAnimation.sPosition.Y)
            {
                this.Enemy.CharacterAnimation.sPosition.Y++;
            }
            else if (this.Hero.CharacterAnimation.sPosition.Y < this.Enemy.CharacterAnimation.sPosition.Y)
            {
                this.Enemy.CharacterAnimation.sPosition.Y--;
            }

            //TODO ADD ANIMATION
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
                HitTheHero();
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

        private void HitTheHero()
        {
            this.Enemy.Attack(this.Hero);
            //TODO ADD ANIMATION
        }


        private bool HeroInRange()
        {
            float enemyX = this.Enemy.CharacterAnimation.sPosition.X;
            float enemyY = this.Enemy.CharacterAnimation.sPosition.X;

            float heroX = this.Hero.CharacterAnimation.sPosition.X;
            float heroY = this.Hero.CharacterAnimation.sPosition.Y;


            bool isInRange = enemyX + EnemyRange > heroX && enemyX - EnemyRange < heroX
                             && enemyY + EnemyRange > heroY && enemyY - EnemyRange < heroY;

            return isInRange;
        }
    }
}
