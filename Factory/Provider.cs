using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Provider
    {
        public  string Name { get; set; }
        public Provider(string name)
        {
            Name = name;
        }
        abstract public Material GetConcrete();
        abstract public Material GetBrick();
        abstract public Material GetReinforcedConcreteSlabs();

    }
}
