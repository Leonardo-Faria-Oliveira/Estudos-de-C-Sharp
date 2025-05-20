using DesignPatterns.Flavors;
using DesignPatterns.Sauces;

namespace DesignPatterns.Creationals.Builder
{
    public class PizzaCalabrezaSPBuilder : PizzaBuilder
    {
        public override Pizza Pizza { get; set; }

        public override void Reset()
        {
           this.Pizza = new PizzaCalabrezaSP();
        }

        public override void SetCookTime()
        {
            this.Pizza.CookTime = new CookTime(5);
        }

        public override void SetFlavor()
        {
            this.Pizza.Flavor = new Calabreza();
        }

        public override void SetSauce()
        {
            this.Pizza.Sauce = new ItalianSauce();
        }
    }
}
