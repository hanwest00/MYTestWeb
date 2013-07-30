using System;
using MYORM.Attributes;

namespace DataModels
{
    public class User : MYORM.Interfaces.MYItemBase, IModels
    {
        [PrimaryKey]
        [Identity(1,1)]
        [ValueNotNull]
        public int id
        { 
            get; 
            set;
        }

        [ValueNotNull]
        public int gId
        {
            get;
            set;
        }

        [ValueNotNull]
        public string loginName
        {
            get;
            set;
        }

        [ValueNotNull]
        public string password
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string avatar
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }

        public string tel
        {
            get;
            set;
        }

        public string fox
        {
            get;
            set;
        }

        [DBValueType("text")]
        public string description
        { 
            get; 
            set;
        }

        public int order
        {
            get;
            set;
        }

        public DateTime createDate
        {
            get;
            set;
        }
    }
}
