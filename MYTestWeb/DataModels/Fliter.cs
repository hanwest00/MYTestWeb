using MYORM.Attributes;

namespace DataModels
{
    public class Fliter : MYORM.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [DBValueType("nvarchar(127)")]
        public string fName
        {
            get;
            set;
        }
    }
}
