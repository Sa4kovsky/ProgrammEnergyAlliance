
namespace Contracts.Objects
{
    public class TypeCounterTwo
    {
        private int typeCounterTwo;
        public TypeCounterTwo(int typeCounterTwo)
        {
            this.typeCounterTwo = typeCounterTwo;
        }

        public int TypeCounter
        {
            get { return typeCounterTwo; }
            set { typeCounterTwo = value; }
        }
    }
}
