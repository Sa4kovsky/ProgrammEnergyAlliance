
namespace Contracts.Objects
{
    public class ViewContracts
    {
        private int idContrects;
        private string numberContrects;
        private string signWork;
        private string nameExecutor;
        private string nameExecutors;
        private string positionExecutor;
        private string positionExecutors;
        private string actingOnTheBasis;
        private string number;
        private string date;
        private string financing;
        private string worksType;
        private string dateStart;
        private string dateFinish;
        private string costServices;
        private string prepayment;
        private string sumPrepayment;
        private string nameInstitution;
        private string nameNameCustomer;
        private string nameNameCustomers;
        private string positionNameCustomer;
        private string positionNameCustomers;
        private string actingOnTheBasisCustomer;
        private string numberCustomer;
        private string dateCustomer;
        private string legalAddress;
        private string addressWork;
        private string checkingAccount;
        private string nameBank;
        private string mfo;
        private string unp;
        private string okpo;
        private int idExecutor;
        private int idCustom;
        private int idNameCustom;
        private int idWork;

        public ViewContracts(int idContrects,string numberContrects,string signWork,string nameExecutor,
         string nameExecutors,string positionExecutor,string positionExecutors,string actingOnTheBasis,string number,
         string date,string financing,string worksType,string dateStart,string dateFinish,string costServices,
         string prepayment,string sumPrepayment,string nameInstitution,string nameNameCustomer,string nameNameCustomers,
         string positionNameCustomer,string positionNameCustomers,string actingOnTheBasisCustomer,string numberCustomer,
         string dateCustomer,string legalAddress,string addressWork,string checkingAccount,string nameBank,string mfo,
         string unp, string okpo, int idExecutor, int idCustom, int idNameCustom, int idWork)
        {
            this.idContrects = idContrects;
            this.numberContrects = numberContrects;
            this.signWork = signWork;
            this.nameExecutor = nameExecutor;
            this.nameExecutors = nameExecutors;
            this.positionExecutor = positionExecutor;
            this.positionExecutors = positionExecutors;
            this.actingOnTheBasis = actingOnTheBasis;
            this.number = number;
            this.date = date;
            this.financing = financing;
            this.worksType = worksType;
            this.dateStart = dateStart;
            this.dateFinish = dateFinish;
            this.costServices = costServices;
            this.prepayment = prepayment;
            this.sumPrepayment = sumPrepayment;
            this.nameInstitution = nameInstitution;
            this.nameNameCustomer = nameNameCustomer;
            this.nameNameCustomers = nameNameCustomers;
            this.positionNameCustomer = positionNameCustomer;
            this.positionNameCustomers = positionNameCustomers;
            this.actingOnTheBasisCustomer = actingOnTheBasisCustomer;
            this.numberCustomer = numberCustomer;
            this.dateCustomer = dateCustomer;
            this.legalAddress = legalAddress;
            this.addressWork = addressWork;
            this.checkingAccount = checkingAccount;
            this.nameBank = nameBank;
            this.mfo = mfo;
            this.unp = unp;
            this.okpo = okpo;
            this.idExecutor = idExecutor;
            this.idCustom = idCustom;
            this.idNameCustom = idNameCustom;
            this.idWork = idWork;
        }

        public int IdExecutor
        {
            get { return idExecutor; }
            set { idExecutor = value; }
        }

        public int IdCustom
        {
            get { return idCustom; }
            set { idCustom = value; }
        }
        public int IdNameCustom
        {
            get { return idNameCustom; }
            set { idNameCustom = value; }
        }
        public int IdWork
        {
            get { return idWork; }
            set { idWork = value; }
        }

        public int IdContrects
        {
            get { return idContrects; }
            set { idContrects = value; }
        }

        public string NumberContrects
        {
            get { return numberContrects; }
            set { numberContrects = value; }
        }

        public string SignWork
        {
            get { return signWork; }
            set { signWork = value; }
        }

        public string NameExecutor
        {
            get { return nameExecutor; }
            set { nameExecutor = value; }
        }

        public string NameExecutors
        {
            get { return nameExecutors; }
            set { nameExecutors = value; }
        }

        public string PositionExecutor
        {
            get { return positionExecutor; }
            set { positionExecutor = value; }
        }

        public string PositionExecutors
        {
            get { return positionExecutors; }
            set { positionExecutors = value; }
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

        public string Financing
        {
            get { return financing; }
            set { financing = value; }
        }

        public string WorksType
        {
            get { return worksType; }
            set { worksType = value; }
        }

        public string DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        public string DateFinish
        {
            get { return dateFinish; }
            set { dateFinish = value; }
        }

        public string CostServices
        {
            get { return costServices; }
            set { costServices = value; }
        }

        public string Prepayment
        {
            get { return prepayment; }
            set { prepayment = value; }
        }

        public string SumPrepayment
        {
            get { return sumPrepayment; }
            set { sumPrepayment = value; }
        }

        public string NameInstitution
        {
            get { return nameInstitution; }
            set { nameInstitution = value; }
        }

        public string NameNameCustomer
        {
            get { return nameNameCustomer; }
            set { nameNameCustomer = value; }
        }

        public string NameNameCustomers
        {
            get { return nameNameCustomers; }
            set { nameNameCustomers = value; }
        }

        public string PositionNameCustomer
        {
            get { return positionNameCustomer; }
            set { positionNameCustomer = value; }
        }

        public string PositionNameCustomers
        {
            get { return positionNameCustomers; }
            set { positionNameCustomers = value; }
        }

        public string ActingOnTheBasisCustomer
        {
            get { return actingOnTheBasisCustomer; }
            set { actingOnTheBasisCustomer = value; }
        }

        public string NumberCustomer
        {
            get { return numberCustomer; }
            set { numberCustomer = value; }
        }

        public string DateCustomer
        {
            get { return dateCustomer; }
            set { dateCustomer = value; }
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
        public string Mfo
        {
            get { return mfo; }
            set { mfo = value; }
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
