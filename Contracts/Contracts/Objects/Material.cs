using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Objects
{
    public class Material
    {
        private string material;
        private string units;
        private double count;
        private double price;

        public Material(string material, string units, double price, double count)
        {
            this.material = material;
            this.units = units;
            this.count = count;
            this.price = price;
        }

        public string Materials
        {
            get { return material; }
            set { material = value; }
        }
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
        public double Count
        {
            get { return count; }
            set { count = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}
