using MYORM.Attributes;

namespace DataModels
{
    public class Privilege : MYORM.MYItemBase, IModels
    {
        public int uId
        {
            get;
            set;
        }

        public int cId
        {
            get;
            set;
        }
    }
}
