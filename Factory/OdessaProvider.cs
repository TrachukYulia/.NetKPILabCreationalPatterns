using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class OdessaProvider: Provider
    {
        public OdessaProvider(string n) : base(n)
        { }

        public override Material GetConcrete()
        {
            Concrete concrete = new Concrete("Beton C");
            concrete.Type = "Economy";
            concrete.Price = 4;
            concrete.MaxAmount = 55;
            return concrete;
        }

        public override Material GetBrick()
        {
            Brick brick = new Brick("Brick B");
            brick.Type = "Handmade";
            brick.Price = 9;
            brick.MaxAmount = 20;
            return brick;
        }
        public override Material GetReinforcedConcreteSlabs()
        {
            ReinforcedConcreteSlabs slabs = new ReinforcedConcreteSlabs("ReinforcedConcreteSlabs B");
            slabs.Type = "King";
            slabs.Price = 20;
            slabs.MaxAmount = 25;
            return slabs;
        }

    }
}
