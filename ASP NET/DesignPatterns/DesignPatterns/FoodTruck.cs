using DesignPatterns.Creationals.Builder;
using DesignPatterns.Creationals.FactoryMethod;
using DesignPatterns.Creationals.Singleton;

namespace DesignPatterns
{
    public class FoodTruck
    {

        private static FactoryMethod ChoosePizzaPlace(string local)
        {
            switch (local)
            {
                case "RJ":
                    return new PizzaRJFactory();
                default :
                    return new PizzaSPFactory();
            }
        }



        public static void OrderPizza()
        {

            // Simple Factory
            //      var pizza = SimpleFactory.Factory("C");
            //      pizza.Prepare();
            //      pizza.Cook(10);
            //      pizza.Delivery();


            //Factory Method
            //var pizzaPlace = ChoosePizzaPlace("SP");

            //pizzaPlace.OrderPizza("C");



            //var foodTruck = AbstractFactory.CreateFactory("Pizza");

            //var food = foodTruck.CreateProduct("C");

            //food.Make();


            //Builder 
            //var director = new Director<PizzaBuilder>();

            //var builder = new PizzaCalabrezaSPBuilder();
            //director.Build(builder);
            //var pizza = builder.GetResult();


            //Prototype
            //var pizzaSP = new PizzaCalabrezaSP();

            //var pizza = pizzaSP.Clone();


            //Singleton
            //var delivery = PizzaCalabrezaSPDelivery.GetDeliveredPizza();

        }
    }
}
