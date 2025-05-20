namespace DesignPatterns.Creationals.Singleton
{
    public class PizzaCalabrezaSPDelivery
    {

        private static PizzaCalabrezaSPDelivery Delivery { get; set; }

        private PizzaCalabrezaSPDelivery()
        {

            Console.WriteLine("Instance");

        }

        public static PizzaCalabrezaSPDelivery GetDeliveredPizza()
        {
            if (PizzaCalabrezaSPDelivery.Delivery == null)
            {
                PizzaCalabrezaSPDelivery.Delivery = new PizzaCalabrezaSPDelivery();
            }

            return PizzaCalabrezaSPDelivery.Delivery;
        }
    }
}
