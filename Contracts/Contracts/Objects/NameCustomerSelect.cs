

namespace Contracts.Objects
{
    public class NameCustomerSelect
    {

        private int id;
        private string name;
        private string positionNameCustomer;


        public NameCustomerSelect(int id, string name, string positionNameCustomer)
        {
            this.id = id;
            this.name = name;
            this.positionNameCustomer = positionNameCustomer;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string PositionNameCustomer
        {
            get { return positionNameCustomer; }
            set { positionNameCustomer = value; }
        }
    }
}
