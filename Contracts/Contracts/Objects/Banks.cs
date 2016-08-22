

namespace Contracts.Objects
{
    public class Banks
    {
          private int idBank;
        private string nameBank;
        private string address;

        public Banks(int idBank, string nameBank, string address)
        {
            this.idBank = idBank;
            this.nameBank = nameBank;
            this.address = address;
        }

        public int IdBank
        {
            get { return idBank; }
            set { idBank = value; }
        }

        public string NameBank 
        {
            get { return nameBank; }
            set { nameBank = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    
    }
}
