namespace Diablo.Interfaces
{
    public interface IKillable
    {
        bool IsAlive { get; set; }

        void IsDead(ICharacter enemy);
    }
}
