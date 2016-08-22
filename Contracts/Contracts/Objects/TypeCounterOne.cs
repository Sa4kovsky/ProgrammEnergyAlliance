

namespace Contracts.Objects
{
    public class TypeCounterOne
    {
        private int typeCounterOne;
        public TypeCounterOne(int typeCounterOne)
        {
            this.typeCounterOne = typeCounterOne;
        }

        public int TypeCounter
        {
            get { return typeCounterOne; }
            set { typeCounterOne = value; }
        }
    }
}
