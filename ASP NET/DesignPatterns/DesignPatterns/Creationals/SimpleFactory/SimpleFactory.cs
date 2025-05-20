namespace DesignPatterns.Creationals.SimpleFactory
{
    public sealed class SimpleFactory
    {

        public static Pizza Factory(string type)
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
