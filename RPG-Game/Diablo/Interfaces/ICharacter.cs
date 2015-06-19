namespace Diablo.Interfaces
{
    public interface ICharacter : IAttack
    {
        int Mana { get; set; }
        int Damage { get; set; }
        int Health { get; set; }
    }
}
