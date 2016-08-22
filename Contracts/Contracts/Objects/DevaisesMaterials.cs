

namespace Contracts.Objects
{
    public class DevaisesMaterials
    {
        private int idMaterials;
        private string customer;
        private string address;
        private string typeCounter;
        private string typeAccount;
        private string brandEnergyMeter;
        private string du;
        private string tb;
        private string ipp;
        private string ppr;
        private string tsp;
        private string note;
        private string date;

        public DevaisesMaterials( int idMaterials,string customer,string address,string typeCounter,string typeAccount,string brandEnergyMeter,
        string du,string tb,string ipp,string ppr,string tsp,string note,string date)
        {
            this.idMaterials = idMaterials;
            this.customer = customer;
            this.address = address;
            this.typeCounter = typeCounter;
            this.typeAccount = typeAccount;
            this.brandEnergyMeter = brandEnergyMeter;
            this.du = du;
            this.tb = tb;
            this.ipp = ipp;
            this.ppr = ppr;
            this.tsp = tsp;
            this.note = note;
            this.date = date;
        }

        public int IdMaterials
        {
            get { return idMaterials; }
            set { idMaterials = value; }
        }

        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string TypeCounter
        {
            get { return typeCounter; }
            set { typeCounter = value; }
        }

        public string TypeAccount
        {
            get { return typeAccount; }
            set { typeAccount = value; }
        }

        public string BrandEnergyMeter
        {
            get { return brandEnergyMeter; }
            set { brandEnergyMeter = value; }
        }

        public string Du
        {
            get { return du; }
            set { du = value; }
        }

        public string Tb
        {
            get { return tb; }
            set { tb = value; }
        }

        public string Ipp
        {
            get { return ipp; }
            set { ipp = value; }
        }

        public string Ppr
        {
            get { return ppr; }
            set { ppr = value; }
        }

        public string Tsp
        {
            get { return tsp; }
            set { tsp = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}
