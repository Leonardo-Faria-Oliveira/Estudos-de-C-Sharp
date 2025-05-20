using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creationals.FactoryMethod
{
    public class PizzaSPFactory : FactoryMethod
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
