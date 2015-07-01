﻿namespace Diablo.Logic.Characters.Enemies
{
    public class GreyTroll : BaseEnemy
    {
        private new const int Damage = 1;
        private new const int Health = 25;

        public GreyTroll() : base(Damage, Health)
        {
        }
    }
}
