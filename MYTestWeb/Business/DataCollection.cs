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
        private static DataGeneric<Category> categoryInstance;
        public static DataGeneric<Category> CategoryInstance
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

        private static DataGeneric<User> userInstance;
        public static DataGeneric<User> UserInstance
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

        private static DataGeneric<DateInfo> dateInfoInstance;
        public static DataGeneric<DateInfo> DateInfoInstance
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

        private static DataGeneric<FileInfo> fileInfoInstance;
        public static DataGeneric<FileInfo> FileInfoInstance
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

        private static DataGeneric<Group> groupInstance;
        public static DataGeneric<Group> GroupInstance
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

        private static DataGeneric<ImageInfo> imageInfoInstance;
        public static DataGeneric<ImageInfo> ImageInfoInstance
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

        private static DataGeneric<Logs> logsInstance;
        public static DataGeneric<Logs> LogsInstance
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

        private static DataGeneric<Models> modelsInstance;
        public static DataGeneric<Models> ModelsInstance
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

        private static DataGeneric<Privilege> privilegeInstance;
        public static DataGeneric<Privilege> PrivilegeInstance
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

        private static DataGeneric<ShortTextInfo> shortTextInfoInstance;
        public static DataGeneric<ShortTextInfo> ShortTextInfoInstance
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

        private static DataGeneric<TextInfo> textInfoInstance;
        public static DataGeneric<TextInfo> TextInfoInstance
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
