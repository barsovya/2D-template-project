namespace Utilities.Interfaces
{
    public interface IBootstrapComponent
    {
        public bool BootstrapPriority { get; }
        public void Initialization();
    }
}