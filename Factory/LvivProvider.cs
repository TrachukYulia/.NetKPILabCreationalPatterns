using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class LvivProvider: Provider
    {
        public LvivProvider(string n) : base(n)
        { }

        public override Material GetConcrete()
        {
            Concrete concrete = new Concrete("Beton B");
            concrete.Type = "Normal";
            concrete.Price = 8;
            concrete.MaxAmount = 60;
            return concrete;
        }

        public override Material GetBrick()
        {
            Brick brick = new Brick("Brick B");
            brick.Type = "Economy";
            brick.Price = 7;
            brick.MaxAmount = 70;
            return brick;
        }
        public override Material GetReinforcedConcreteSlabs()
        {
            ReinforcedConcreteSlabs slabs = new ReinforcedConcreteSlabs("ReinforcedConcreteSlabs B");
            slabs.Type = "Middle";
            slabs.Price = 9;
            slabs.MaxAmount = 45;
            return slabs;
        }

    }
}
