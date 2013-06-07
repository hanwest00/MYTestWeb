using MYORM.Attributes;

namespace Data.Tables
{
    public class Logs : MYORM.MYItemBase
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int Id
        {
            get;
            set;
        }

        [ValueNotNull]
        public string LogType
        {
            get;
            set;
        }

        [DBValueType("text")]
        public string Content
        {
            get;
            set;
        }

        public System.DateTime LogDate
        {
            get;
            set;
        }
    }
}
