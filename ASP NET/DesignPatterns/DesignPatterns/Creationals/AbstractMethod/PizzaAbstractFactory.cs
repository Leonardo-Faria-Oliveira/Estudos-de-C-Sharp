namespace DesignPatterns.Creationals.AbstractMethod
{
    public class PizzaAbstractFactory : AbstractFactory
    {
        public override Product CreateProduct(string type)
        {
            switch (type)
            {
                case "C":
                    return new PizzaCalabrezaSP();

                default:
                    return new PizzaMusserelaSP();
            }
        }
    }
}
