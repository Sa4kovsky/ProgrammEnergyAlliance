

namespace Contracts.Objects
{
   public class Score
    {
        private int idScore;
        private string idContrects;
        private string address;
        private int oneFlow;
        private int twoFlow;
        private int threeFlow;
        private int manometer;

        public Score(int idScore, string idContrects, string address, int oneFlow, int twoFlow, int threeFlow,
            int manometer)
        {
            this.idScore = idScore;
            this.idContrects = idContrects;
            this.address = address;
            this.oneFlow = oneFlow;
            this.twoFlow = twoFlow;
            this.threeFlow = threeFlow;
            this.manometer = manometer;
        }

        public int IdScore
        {
            get { return idScore; }
            set { idScore = value; }
        }
        public string IdContrects
        {
            get { return idContrects; }
            set { idContrects = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int OneFlow
        {
            get { return oneFlow; }
            set { oneFlow = value; }
        }
        public int TwoFlow
        {
            get { return twoFlow; }
            set { twoFlow = value; }
        }
        public int ThreeFlow
        {
            get { return threeFlow; }
            set { threeFlow = value; }
        }
        public int Manometer
        {
            get { return manometer; }
            set { manometer = value; }
        }
    }
}
