using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
   public class Order
    {
        private List<Material> _listOfOrdersMaterials;
        private decimal _totalSum;
        private int _dayRequirment;
        public int NumberOfPieces;
        public List<Material> ListOfOrdersMaterials => _listOfOrdersMaterials;
        public decimal TotalSum => _totalSum;
        public int DayRequirment => _dayRequirment;
        public Order()
        {
            _listOfOrdersMaterials = new List<Material>();
            _totalSum = 0;
        }


       public List<Material>  GetListMaterial(Provider provider)
        {
            var brick = provider.GetBrick();
            var concrete = provider.GetConcrete();
            var slabs = provider.GetReinforcedConcreteSlabs();
            List<Material> materials = new List<Material> {brick, concrete, slabs };
            return materials;
        }
       
        public List<Material>  GetInfo (Provider provider)
        {
            var list = GetListMaterial(provider);
            return list;
        }

        public void SetOrder(Material material, int number)
        {

            if (number < material.MaxAmount && number > 0)
            {
                _listOfOrdersMaterials.Add(material);
                _totalSum += material.Price * number;
                _dayRequirment = material.DayRequirement - number;
                NumberOfPieces = number;
                material.NumberNow = number;
            }
            else throw new Exception("Exceeded the maximum delivery rate");
        }
    }
}
