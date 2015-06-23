﻿using Diablo.GUI;

namespace Diablo.Characters.Heroes
{
    public class Sorcerer : BaseCharacter
    {
        private new const int Health = 120;
        private new const int Damage = 8;
        private new const int Mana = 400;

        public Sorcerer(string name) : base(name, Health, Damage, Mana)
        {
        }
    }
}