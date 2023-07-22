namespace SinglePlayer.Scripts.Weapon.Interfaces
{
    public interface IAttacker
    {
        public bool CanAttack { get; }
        public void TryToAttack();
    }
}