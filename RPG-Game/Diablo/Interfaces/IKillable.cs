using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.Interfaces
{
    public interface IKillable
    {
        bool IsAlive { get; set; }

        void IsDead(ICharacter enemy);
    }
}
