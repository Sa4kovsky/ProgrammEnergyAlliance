

namespace Contracts.Objects
{
    public class Customers
    {
        private int idCustomer;
        private string nameInstitution;
        private string legalAddress;
        private string addressWork;
        private string checkingAccount;
        private string nameBank;
        private string unp;
        private string okpo;

        public Customers(int idCustomer, string nameInstitution,  string legalAddress, string addressWork, string checkingAccount, string nameBank, string unp, string okpo)
        {
            this.idCustomer = idCustomer;
            this.nameInstitution = nameInstitution;
            this.legalAddress = legalAddress;
            this.addressWork = addressWork;
            this.checkingAccount = checkingAccount;
            this.nameBank = nameBank;
            this.unp = unp;
            this.okpo = okpo;
        }

        public int IdCustomer
        {
            get { return idCustomer; }
            set { idCustomer = value; }
        }
        public string NameInstitution
        {
            get { return nameInstitution; }
            set { nameInstitution = value; }
        }

        public string LegalAddress
        {
            get { return legalAddress; }
            set { legalAddress = value; }
        }
        public string AddressWork
        {
            get { return addressWork; }
            set { addressWork = value; }
        }
        public string CheckingAccount
        {
            get { return checkingAccount; }
            set { checkingAccount = value; }
        }
        public string NameBank
        {
            get { return nameBank; }
            set { nameBank = value; }
        }
        public string Unp
        {
            get { return unp; }
            set { unp = value; }
        }
        public string Okpo
        {
            get { return okpo; }
            set { okpo = value; }
        }

    }
}
