using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creationals.Builder
{
    public class Director<Builder> where Builder : PizzaBuilder
    {

        public void Build(Builder builder)
        {
            builder.SetFlavor();
            builder.SetSauce();
            builder.SetCookTime();
        }

    }
}
