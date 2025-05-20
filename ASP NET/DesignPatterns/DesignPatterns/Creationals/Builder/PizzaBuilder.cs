namespace DesignPatterns.Creationals.Builder
{
    public abstract class PizzaBuilder
    {


        public virtual Pizza Pizza { get; set; }

        public abstract void Reset();

        public abstract void SetFlavor();

        public abstract void SetSauce();

        public abstract void SetCookTime();

        public Pizza GetResult()
        {
            this.Reset();
            return this.Pizza;
        }

    }
}
