namespace DesignPatterns.Creationals.FactoryMethod
{
    public class PizzaRJFactory : FactoryMethod
    {
        protected override Pizza Factory(string type)
        {
            switch (type)
            {
                case "C":
                    return new PizzaCalabrezaRJ();

                default:
                    return new PizzaMussarelaRJ();
            }
        }
    }
}
