using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.Logic.Characters.Heroes
{
    public class HealthChangedEventArgs : EventArgs
    {
        public HealthChangedEventArgs(int newHealth, int initialHealth)
        {
            this.NewHealth = newHealth;
            this.InitialHealth = initialHealth;
        }
        public int NewHealth { get; set; }
        public int InitialHealth { get; set; }
    }
}
