using MYORM.Attributes;

namespace DataModels
{
    public class Models : MYORM.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1, 1)]
        [ValueNotNull]
        public int id
        {
            get;
            set;
        }

        [ValueNotNull]
        public int iId
        {
            get;
            set;
        }

        [DBValueType("nvarchar(127)")]
        public string mName
        {
            get;
            set;
        }

        /// <summary>
        /// 0:ShortText
        /// 1:Text
        /// 2:Image
        /// 3:File
        /// 4:date
        /// </summary>
        [Default(0)]
        public int mType
        {
            get;
            set;
        }

        public int order
        {
            get; set;
        }
    }
}
