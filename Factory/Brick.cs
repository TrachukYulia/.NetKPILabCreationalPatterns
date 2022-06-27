using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
   public class Brick: Material
    {
        public override int DayRequirement { get; internal set; }

        public override string Name { get; internal set; }
        public Brick(string name) : base(name)
        {
            Name = name;
        }
        public Brick() { }
        public override void SetDayRequirement(int dayRequirement)
        {
            DayRequirement = dayRequirement;
        }
    }
}
