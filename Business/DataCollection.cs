using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataModels;

namespace Business
{
    public static class DataCollection
    {
        private static IDataGeneric<Category> categoryInstance;
        public static IDataGeneric<Category> CategoryInstance
        {
            get
            {
                lock (new object())
                {
                    if (categoryInstance == null) categoryInstance = new DataGeneric<Category>();
                }
                return categoryInstance;
            }
        }

        private static IDataGeneric<CategoryFliter> categoryFliterInstance;
        public static IDataGeneric<CategoryFliter> CategoryFliterInstance
        {
            get
            {
                lock (new object())
                {
                    if (categoryFliterInstance == null) categoryFliterInstance = new DataGeneric<CategoryFliter>();
                }
                return categoryFliterInstance;
            }
        }

        private static IDataGeneric<CategoryInfo> categoryInfoInstance;
        public static IDataGeneric<CategoryInfo> CategoryInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (categoryInfoInstance == null) categoryInfoInstance = new DataGeneric<CategoryInfo>();
                }
                return categoryInfoInstance;
            }
        }

        private static IDataGeneric<CategoryInfoFliter> categoryInfoFliterInstance;
        public static IDataGeneric<CategoryInfoFliter> CategoryInfoFliterInstance
        {
            get
            {
                lock (new object())
                {
                    if (categoryInfoFliterInstance == null) categoryInfoFliterInstance = new DataGeneric<CategoryInfoFliter>();
                }
                return categoryInfoFliterInstance;
            }
        }

        private static IDataGeneric<CategoryModel> categoryModelInstance;
        public static IDataGeneric<CategoryModel> CategoryModelInstance
        {
            get
            {
                lock (new object())
                {
                    if (categoryModelInstance == null) categoryModelInstance = new DataGeneric<CategoryModel>();
                }
                return categoryModelInstance;
            }
        }

        private static IDataGeneric<User> userInstance;
        public static IDataGeneric<User> UserInstance
        {
            get
            {
                lock (new object())
                {
                    if (userInstance == null) userInstance = new DataGeneric<User>();
                }
                return userInstance;
            }
        }

        private static IDataGeneric<DateInfo> dateInfoInstance;
        public static IDataGeneric<DateInfo> DateInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (dateInfoInstance == null) dateInfoInstance = new DataGeneric<DateInfo>();
                }
                return dateInfoInstance;
            }
        }

        private static IDataGeneric<FileInfo> fileInfoInstance;
        public static IDataGeneric<FileInfo> FileInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (fileInfoInstance == null) fileInfoInstance = new DataGeneric<FileInfo>();
                }
                return fileInfoInstance;
            }
        }

        private static IDataGeneric<Fliter> fliterInstance;
        public static IDataGeneric<Fliter> FliterInstance
        {
            get
            {
                lock (new object())
                {
                    if (fliterInstance == null) fliterInstance = new DataGeneric<Fliter>();
                }
                return fliterInstance;
            }
        }

        private static IDataGeneric<Group> groupInstance;
        public static IDataGeneric<Group> GroupInstance
        {
            get
            {
                lock (new object())
                {
                    if (groupInstance == null) groupInstance = new DataGeneric<Group>();
                }
                return groupInstance;
            }
        }

        private static IDataGeneric<ImageInfo> imageInfoInstance;
        public static IDataGeneric<ImageInfo> ImageInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (imageInfoInstance == null) imageInfoInstance = new DataGeneric<ImageInfo>();
                }
                return imageInfoInstance;
            }
        }

        private static IDataGeneric<Logs> logsInstance;
        public static IDataGeneric<Logs> LogsInstance
        {
            get
            {
                lock (new object())
                {
                    if (logsInstance == null) logsInstance = new DataGeneric<Logs>();
                }
                return logsInstance;
            }
        }

        private static IDataGeneric<Models> modelsInstance;
        public static IDataGeneric<Models> ModelsInstance
        {
            get
            {
                lock (new object())
                {
                    if (modelsInstance == null) modelsInstance = new DataGeneric<Models>();
                }
                return modelsInstance;
            }
        }

        private static IDataGeneric<Privilege> privilegeInstance;
        public static IDataGeneric<Privilege> PrivilegeInstance
        {
            get
            {
                lock (new object())
                {
                    if (privilegeInstance == null) privilegeInstance = new DataGeneric<Privilege>();
                }
                return privilegeInstance;
            }
        }

        private static IDataGeneric<ShortTextInfo> shortTextInfoInstance;
        public static IDataGeneric<ShortTextInfo> ShortTextInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (shortTextInfoInstance == null) shortTextInfoInstance = new DataGeneric<ShortTextInfo>();
                }
                return shortTextInfoInstance;
            }
        }

        private static IDataGeneric<TextInfo> textInfoInstance;
        public static IDataGeneric<TextInfo> TextInfoInstance
        {
            get
            {
                lock (new object())
                {
                    if (textInfoInstance == null) textInfoInstance = new DataGeneric<TextInfo>();
                }
                return textInfoInstance;
            }
        }
    }
}
