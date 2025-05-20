namespace DesignPatterns.Creationals.FactoryMethod
{
    public abstract class FactoryMethod
    {

        public Pizza OrderPizza(string type)
        {
            return Factory(type);
        }

        protected abstract Pizza Factory(string type);

    }
}
