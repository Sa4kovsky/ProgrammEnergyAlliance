

namespace Contracts.Objects
{
    public class Manometr
    {
        private int manometr;
        public Manometr(int manometr)
        {
            this.manometr = manometr;
        }

        public int TypeCounter
        {
            get { return manometr; }
            set { manometr = value; }
        }
    }
}
