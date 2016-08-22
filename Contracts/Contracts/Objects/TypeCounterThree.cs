

namespace Contracts.Objects
{
    public class TypeCounterThree
    {
        private int typeCounterThree;
        public TypeCounterThree(int typeCounterThree)
        {
            this.typeCounterThree = typeCounterThree;
        }

        public int TypeCounter
        {
            get { return typeCounterThree; }
            set { typeCounterThree = value; }
        }
    }
}
