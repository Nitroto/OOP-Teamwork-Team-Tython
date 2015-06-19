namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack, IKillable
    {
        string Name { get; }
        int Health { get; }
        int Damage { get; }
        int Mana { get; }
    }
}
