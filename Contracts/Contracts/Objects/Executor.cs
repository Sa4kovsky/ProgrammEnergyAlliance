
namespace Contracts.Objects
{
    public class Executor
    {
        private int idExecutor;
        private string nameExecutor;
        private string nameExecutors;
        private string positionExecutor;
        private string positionExecutors;
        private string actingOnTheBasis;
        private string number;
        private string date;

        public Executor(int idExecutor, string nameExecutor, string nameExecutors, string positionExecutor, string positionExecutors, string actingOnTheBasis, string number, string date)
        {
            this.idExecutor = idExecutor;
            this.nameExecutor = nameExecutor;
            this.nameExecutors = nameExecutors;
            this.positionExecutor = positionExecutor;
            this.positionExecutors = positionExecutors;
            this.actingOnTheBasis = actingOnTheBasis;
            this.number = number;
            this.date = date;
        }

        public int IdExecutor
        {
            get { return idExecutor; }
            set { idExecutor = value; }
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
    }
}
