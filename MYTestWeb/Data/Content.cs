using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Tables;
using MYORM.SqlServer;
using MYORM;
using MYORM.Interfaces;
using MYORM.Conditions;
using DataModels;

namespace Data
{
    public class Content
    {
        private static ITable<Category> cate = SqlServerTable<Category>.GetInstance();
        private static ITable<Models> cate = SqlServerTable<Models>.GetInstance();
        private static ITable<ShortTextInfo> cate = SqlServerTable<ShortTextInfo>.GetInstance();
        private static ITable<ShortTextInfo> cate = SqlServerTable<ShortTextInfo>.GetInstance();
        private static ITable<TextInfo> cate = SqlServerTable<TextInfo>.GetInstance();
        private static ITable<ImageInfo> cate = SqlServerTable<ImageInfo>.GetInstance();
        private static ITable<FileInfo> cate = SqlServerTable<FileInfo>.GetInstance();
        private static ITable<DateInfo> cate = SqlServerTable<DateInfo>.GetInstance();

    }
}
