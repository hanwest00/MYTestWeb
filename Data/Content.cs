using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Interfaces;
using MYORM.Conditions;
using DataModels;

namespace Data
{
    public class Content
    {
        private ITable<Category> cate = DataIoc<Category>.GetData();
        private ITable<Models> cate = DataIoc<Models>.GetData();
        private ITable<ShortTextInfo> cate = DataIoc<ShortTextInfo>.GetData();
        private ITable<ShortTextInfo> cate = DataIoc<ShortTextInfo>.GetData();
        private ITable<TextInfo> cate = DataIoc<TextInfo>.GetData();
        private ITable<ImageInfo> cate = DataIoc<ImageInfo>.GetData();
        private ITable<FileInfo> cate = DataIoc<FileInfo>.GetData();
        private ITable<DateInfo> cate = DataIoc<DateInfo>.GetData();

    }
}
