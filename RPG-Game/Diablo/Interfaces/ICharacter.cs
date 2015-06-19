namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack
    {
        int Mana { get; }
        int Damage { get; }
        int Health { get; }
    }
}
