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
        private static object lockCategoryObj = new object();
        private static IDataGeneric<Category> categoryInstance;
        public static IDataGeneric<Category> CategoryInstance
        {
            get
            {
                lock (lockCategoryObj)
                {
                    if (categoryInstance == null) categoryInstance = new DataGeneric<Category>();
                }
                return categoryInstance;
            }
        }

        private static object lockCategoryFliterObj = new object();
        private static IDataGeneric<CategoryFliter> categoryFliterInstance;
        public static IDataGeneric<CategoryFliter> CategoryFliterInstance
        {
            get
            {
                lock (lockCategoryFliterObj)
                {
                    if (categoryFliterInstance == null) categoryFliterInstance = new DataGeneric<CategoryFliter>();
                }
                return categoryFliterInstance;
            }
        }

        private static object lockCategoryInfoObj = new object();
        private static IDataGeneric<CategoryInfo> categoryInfoInstance;
        public static IDataGeneric<CategoryInfo> CategoryInfoInstance
        {
            get
            {
                lock (lockCategoryInfoObj)
                {
                    if (categoryInfoInstance == null) categoryInfoInstance = new DataGeneric<CategoryInfo>();
                }
                return categoryInfoInstance;
            }
        }

        private static object lockCategoryInfoFliterObj = new object();
        private static IDataGeneric<CategoryInfoFliter> categoryInfoFliterInstance;
        public static IDataGeneric<CategoryInfoFliter> CategoryInfoFliterInstance
        {
            get
            {
                lock (lockCategoryInfoFliterObj)
                {
                    if (categoryInfoFliterInstance == null) categoryInfoFliterInstance = new DataGeneric<CategoryInfoFliter>();
                }
                return categoryInfoFliterInstance;
            }
        }

        private static object lockCategoryModelObj = new object();
        private static IDataGeneric<CategoryModel> categoryModelInstance;
        public static IDataGeneric<CategoryModel> CategoryModelInstance
        {
            get
            {
                lock (lockCategoryModelObj)
                {
                    if (categoryModelInstance == null) categoryModelInstance = new DataGeneric<CategoryModel>();
                }
                return categoryModelInstance;
            }
        }

        private static object lockUserObj = new object();
        private static IDataGeneric<User> userInstance;
        public static IDataGeneric<User> UserInstance
        {
            get
            {
                lock (lockUserObj)
                {
                    if (userInstance == null) userInstance = new DataGeneric<User>();
                }
                return userInstance;
            }
        }

        private static object lockDateInfoObj = new object();
        private static IDataGeneric<DateInfo> dateInfoInstance;
        public static IDataGeneric<DateInfo> DateInfoInstance
        {
            get
            {
                lock (lockDateInfoObj)
                {
                    if (dateInfoInstance == null) dateInfoInstance = new DataGeneric<DateInfo>();
                }
                return dateInfoInstance;
            }
        }

        private static object lockFileInfoObj = new object();
        private static IDataGeneric<FileInfo> fileInfoInstance;
        public static IDataGeneric<FileInfo> FileInfoInstance
        {
            get
            {
                lock (lockFileInfoObj)
                {
                    if (fileInfoInstance == null) fileInfoInstance = new DataGeneric<FileInfo>();
                }
                return fileInfoInstance;
            }
        }

        private static object lockFliterObj = new object();
        private static IDataGeneric<Fliter> fliterInstance;
        public static IDataGeneric<Fliter> FliterInstance
        {
            get
            {
                lock (lockFliterObj)
                {
                    if (fliterInstance == null) fliterInstance = new DataGeneric<Fliter>();
                }
                return fliterInstance;
            }
        }

        private static object lockGroupObj = new object();
        private static IDataGeneric<Group> groupInstance;
        public static IDataGeneric<Group> GroupInstance
        {
            get
            {
                lock (lockGroupObj)
                {
                    if (groupInstance == null) groupInstance = new DataGeneric<Group>();
                }
                return groupInstance;
            }
        }

        private static object lockImageInfoObj = new object();
        private static IDataGeneric<ImageInfo> imageInfoInstance;
        public static IDataGeneric<ImageInfo> ImageInfoInstance
        {
            get
            {
                lock (lockImageInfoObj)
                {
                    if (imageInfoInstance == null) imageInfoInstance = new DataGeneric<ImageInfo>();
                }
                return imageInfoInstance;
            }
        }

        private static object lockLogsObj = new object();
        private static IDataGeneric<Logs> logsInstance;
        public static IDataGeneric<Logs> LogsInstance
        {
            get
            {
                lock (lockLogsObj)
                {
                    if (logsInstance == null) logsInstance = new DataGeneric<Logs>();
                }
                return logsInstance;
            }
        }

        private static object lockModelsObj = new object();
        private static IDataGeneric<Models> modelsInstance;
        public static IDataGeneric<Models> ModelsInstance
        {
            get
            {
                lock (lockModelsObj)
                {
                    if (modelsInstance == null) modelsInstance = new DataGeneric<Models>();
                }
                return modelsInstance;
            }
        }

        private static object lockPrivilegeObj = new object();
        private static IDataGeneric<Privilege> privilegeInstance;
        public static IDataGeneric<Privilege> PrivilegeInstance
        {
            get
            {
                lock (lockPrivilegeObj)
                {
                    if (privilegeInstance == null) privilegeInstance = new DataGeneric<Privilege>();
                }
                return privilegeInstance;
            }
        }

        private static object lockShortTextInfoObj = new object();
        private static IDataGeneric<ShortTextInfo> shortTextInfoInstance;
        public static IDataGeneric<ShortTextInfo> ShortTextInfoInstance
        {
            get
            {
                lock (lockShortTextInfoObj)
                {
                    if (shortTextInfoInstance == null) shortTextInfoInstance = new DataGeneric<ShortTextInfo>();
                }
                return shortTextInfoInstance;
            }
        }

        private static object lockTextInfoObj = new object();
        private static IDataGeneric<TextInfo> textInfoInstance;
        public static IDataGeneric<TextInfo> TextInfoInstance
        {
            get
            {
                lock (lockTextInfoObj)
                {
                    if (textInfoInstance == null) textInfoInstance = new DataGeneric<TextInfo>();
                }
                return textInfoInstance;
            }
        }
    }
}
