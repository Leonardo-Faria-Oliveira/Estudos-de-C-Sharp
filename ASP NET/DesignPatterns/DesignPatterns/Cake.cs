namespace DesignPatterns
{
    public abstract class Cake : Product
    {

        public virtual string Name { get; set; } = string.Empty;

        public override abstract void Make();

    }
}
