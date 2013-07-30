using MYORM.Attributes;

namespace DataModels
{
    public class Privilege : MYORM.Interfaces.MYItemBase, IModels
    {
        public int cId
        {
            get;
            set;
        }

        public int gId
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int select
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int insert
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int delete
        {
            get;
            set;
        }

        [ValueNotNull]
        [Default(0)]
        public int update
        {
            get;
            set;
        }
    }
}
