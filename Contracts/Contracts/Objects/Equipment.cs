

namespace Contracts.Objects
{
    public class Equipment
    {
        private int idEquipment;
        private string idCustomer;
        private string address;
        private string typeEquipment;
        private string typeAccount;
        private string brandEquipment;
        private string du;
        private string brandValves;
        private string note;

        public Equipment(int idEquipment, string idCustomer, string address, string typeEquipment, string typeAccount,
               string brandEquipment, string du, string brandValves, string note)
        {
            this.idEquipment = idEquipment;
            this.idCustomer = idCustomer;
            this.address = address;
            this.typeEquipment = typeEquipment;
            this.typeAccount = typeAccount;
            this.brandEquipment = brandEquipment;
            this.du = du;
            this.brandValves = brandValves;
            this.note = note;
        }

        public int IdEquipment
        {
            get { return idEquipment; }
            set { idEquipment = value; }
        }

        public string IdCustomer 
        {
            get { return idCustomer; }
            set { idCustomer = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string TypeEquipment
        {
            get { return typeEquipment; }
            set { typeEquipment = value; }
        }
        public string TypeAccount
        {
            get { return typeAccount; }
            set { typeAccount = value; }
        }
        public string BrandEquipment
        {
            get { return brandEquipment; }
            set { brandEquipment = value; }
        }
        public string Du
        {
            get { return du; }
            set { du = value; }
        }
        public string BrandValves
        {
            get { return brandValves; }
            set { brandValves = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    
    }
}
