using System;

namespace Factory
{
    public class KievProvider: Provider
    {
        public KievProvider(string n) : base(n)
        { }

        public override Material GetConcrete()
        {
            Concrete concrete = new Concrete("Beton A");
            concrete.Type = "Lux";
            concrete.Price = 5;
            concrete.MaxAmount = 100;
            return concrete;
        }
        public override Material GetBrick()
        {
            Brick brick = new Brick("Brick A");
            brick.Type = "Standart";
            brick.Price = 10;
            brick.MaxAmount = 90;
            return brick;
        }

        public override Material GetReinforcedConcreteSlabs()
        {
            ReinforcedConcreteSlabs slabs = new ReinforcedConcreteSlabs("ReinforcedConcreteSlabs A");
            slabs.Type = "King";
            slabs.Price = 15;
            slabs.MaxAmount = 45;
            return slabs;
        }
    }
}
