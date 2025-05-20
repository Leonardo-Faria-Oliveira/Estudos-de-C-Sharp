using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creationals.Prototype
{
    public interface IClonable<Entity> where Entity : Product
    {

        public Entity Clone();

    }
}
