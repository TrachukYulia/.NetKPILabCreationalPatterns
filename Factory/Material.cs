using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Material
    {
        public int NumberNow { get; internal set; }
        public abstract int DayRequirement { get; internal set; }
        public abstract string Name { get; internal set; }
        public string Type { get; internal set; }
        public decimal Price { get; internal set; }
        public int MaxAmount { get; internal set; }
        public Material(string name) { }
        public Material() { }
        public abstract void SetDayRequirement(int dayRequirement);

    }
}
