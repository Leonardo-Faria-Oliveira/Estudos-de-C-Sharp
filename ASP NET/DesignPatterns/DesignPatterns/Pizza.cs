using DesignPatterns.Flavors;
using DesignPatterns.Sauces;

namespace DesignPatterns
{
    public abstract class Pizza : Product
    {

        public virtual string Name { get; set; } = string.Empty;

        public virtual Flavor Flavor {  get; set; }

        public virtual CookTime CookTime { get; set; }

        public virtual Sauce Sauce { get; set; }

        public abstract void Prepare();

        public abstract void Cook(int time);

        public abstract void Delivery();

        public override void Make()
        {
            Prepare();
            Cook(10);
            Delivery();
        }

    }
}
