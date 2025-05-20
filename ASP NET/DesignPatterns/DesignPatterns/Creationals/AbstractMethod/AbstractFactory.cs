namespace DesignPatterns.Creationals.AbstractMethod
{
    public abstract class AbstractFactory
    {


        public abstract Product CreateProduct(string type);
        
        public static AbstractFactory CreateFactory(string type)
        {
            switch (type) 
            {
                case "C":
                    return new CakeAbstractFactory();

                default:
                    return new PizzaAbstractFactory();

            }
        }

    }
}
