namespace Contracts.Objects
{
    class SelectDateView
    {
        
        private int id;
        private string name;
        private int number;
        private string signWork;
        private string address;
        private string LegalAddress;
        private string checkingAccount;
        private string unp;
        private string okpo;
        private string dateStart;
        private string nameBank;
        private string addressBank;
        private string nameExecutor;
        private string positionExecutor;
        private string nameNameCustomer;
        private string positionNameCustomer;

        public SelectDateView(int id, int number, string signWork, string name, string address,
           string LegalAddress,string checkingAccount, string unp,string okpo,string dateStart,string nameBank,string addressBank,string nameExecutor,
            string positionExecutor, string nameNameCustomer, string positionNameCustomer)
        {
            this.id = id;
            this.name = name;
            this.signWork = signWork;
            this.number = number;
            this.address = address;
            this.LegalAddress = LegalAddress;
            this.checkingAccount = checkingAccount;
            this.unp = unp;
            this.okpo = okpo;
            this.dateStart = dateStart;
            this.nameBank = nameBank;
            this.addressBank = addressBank;
            this.nameExecutor = nameExecutor;
            this.positionExecutor = positionExecutor;
            this.nameNameCustomer = nameNameCustomer;
            this.positionNameCustomer = positionNameCustomer;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string SignWork
        {
            get { return signWork; }
            set { signWork = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string LLegalAddress
        {
            get { return LegalAddress; }
            set { LegalAddress = value; }
        }
        public string CheckingAccount
        {
            get { return checkingAccount; }
            set { checkingAccount = value; }
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
        public string DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }
        public string NameBank
        {
            get { return nameBank; }
            set { nameBank = value; }
        }
        public string AddressBank
        {
            get { return addressBank; }
            set { addressBank = value; }
        }
        public string NameExecutor
        {
            get { return nameExecutor; }
            set { nameExecutor = value; }
        }
        public string PositionExecutor
        {
            get { return positionExecutor; }
            set { positionExecutor = value; }
        }
        public string NameNameCustomer
        {
            get { return nameNameCustomer; }
            set { nameNameCustomer = value; }
        }
        public string PositionNameCustomer
        {
            get { return positionNameCustomer; }
            set { positionNameCustomer = value; }
        }
    }
}
