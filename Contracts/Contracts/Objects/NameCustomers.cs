

namespace Contracts.Objects
{
    public class NameCustomers
    {
        private int idNameCustomers;
        private string nameInstitution;
        private string nameCustomer;
        private string nameCustomers;
        private string positionCustomer;
        private string positionCustomers;
        private string actingOnTheBasis;
        private string number;
        private string date;

        public NameCustomers(int idNameCustomers, string nameInstitution, string nameCustomer, string nameCustomers, string positionCustomer, string positionCustomers, string actingOnTheBasis, string number, string date)
        {
            this.idNameCustomers = idNameCustomers;
            this.nameInstitution = nameInstitution;
            this.nameCustomer = nameCustomer;
            this.nameCustomers = nameCustomers;
            this.positionCustomer = positionCustomer;
            this.positionCustomers = positionCustomers;
            this.actingOnTheBasis = actingOnTheBasis;
            this.number = number;
            this.date = date;
        }

        public int IdCustomer
        {
            get { return idNameCustomers; }
            set { idNameCustomers = value; }
        }


        public string NameInstitution
        {
            get { return nameInstitution; }
            set { nameInstitution = value; }
        }


        public string NameCustomer
        {
            get { return nameCustomer; }
            set { nameCustomer = value; }
        }

        public string NameCustomerss
        {
            get { return nameCustomers; }
            set { nameCustomers = value; }
        }

        public string PositionCustomer
        {
            get { return positionCustomer; }
            set { positionCustomer = value; }
        }

        public string PositionCustomers
        {
            get { return positionCustomers; }
            set { positionCustomers = value; }
        }

        public string ActingOnTheBasis
        {
            get { return actingOnTheBasis; }
            set { actingOnTheBasis = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
