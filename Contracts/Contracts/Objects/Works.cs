

namespace Contracts.Objects
{
    public class Works
    {
        private int idWorks;
        private string worksType;

        public Works(int idWorks, string worksType)
        {
            this.idWorks = idWorks;
            this.worksType = worksType;
        }

        public int IdWorks
        {
            get { return idWorks; }
            set { idWorks = value; }
        }

        public string WorksType
        {
            get { return worksType; }
            set { worksType = value; }
        }
    }
}
