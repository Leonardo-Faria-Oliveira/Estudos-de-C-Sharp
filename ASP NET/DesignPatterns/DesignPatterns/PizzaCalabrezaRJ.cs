namespace DesignPatterns
{
    public class PizzaCalabrezaRJ : Pizza
    {

        public override string Name { get; set; } = "Calabreza RJ";

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
    }
}
