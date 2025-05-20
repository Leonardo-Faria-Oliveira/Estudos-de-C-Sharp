namespace DesignPatterns.Creationals.AbstractMethod
{
    public class CakeAbstractFactory : AbstractFactory
    {
        public override Product CreateProduct(string type)
        {
            switch (type) 
            {
                case "S":
                    return new PizzaCalabrezaSP();

                default:
                    return new ChocolateCake();
            }
        }
    }
}
