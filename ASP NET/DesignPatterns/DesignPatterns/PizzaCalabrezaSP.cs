using DesignPatterns.Creationals.Prototype;
using DesignPatterns.Creationals.Singleton;

namespace DesignPatterns
{
    public class PizzaCalabrezaSP : Pizza, IClonable<PizzaCalabrezaSP>, IPizzariaSP
    {

        public PizzaCalabrezaSP()
        {
            
        }

        public PizzaCalabrezaSP(PizzaCalabrezaSP source)
        {
            this.Name = source.Name;
            this.Flavor = source.Flavor;
            this.CookTime = source.CookTime;
            this.Sauce = source.Sauce;
        }

        public override string Name { get; set; }


        public override void Cook(int time)
        {
            Console.WriteLine("Assando");
        }

        public override void Delivery()
        {
            Console.WriteLine("Entregando");
        }

        public override void Prepare()
        {
            Console.WriteLine("Montando");
        }

        public PizzaCalabrezaSP Clone()
        {
            return new PizzaCalabrezaSP(this);
        }
    }
}
