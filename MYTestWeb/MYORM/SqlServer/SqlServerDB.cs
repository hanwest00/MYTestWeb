using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYORM.Exceptions;
using MYORM.Attributes;
using System.Data.SqlClient;
using System.Configuration;

namespace MYORM.SqlServer
{
    public class SqlServerDB : MYDBBase
    {
        #region Singleton
        private static SqlServerDB instance = null;

        /// <summary>
        /// 单件模式返回SqlServerDB实例
        /// </summary>
        /// <param name="connectStr">链接字符串<remarks>确保sqlserver链接字符串中database=master</remarks></param>
        /// <param name="databaseName">数据库名</param>
        /// <param name="dBType">数据库类型</param>
        /// <returns>SqlServerDB 实例</returns>
        public static SqlServerDB GetInstance()
        {

            object lockObj = new object();

            System.Threading.Monitor.Enter(lockObj);
            if (instance == null)
                instance = new SqlServerDB();
            System.Threading.Monitor.Exit(lockObj);

            return instance;

        }
        #endregion

        protected SqlServerDB()
        {
            AppSettingsReader settingReader = new AppSettingsReader();
            dbMasterConnectString = settingReader.GetValue("MYORMConnectionString", typeof(string)) as string;
            dbExe = SqlDBEXE.GetInstance(dbMasterConnectString);
            DatabaseName = settingReader.GetValue("DatabaseName", typeof(string)) as string;
            
            DbFileDir = settingReader.GetValue("DatabaseDir", typeof(string)) as string;
            if (!DbFileDir.EndsWith("\\"))
                DbFileDir += "\\";
            if (!DBContians())
                this.CreateDatebase();
            dbExe.ConnectString = dbMasterConnectString.Replace("master", DatabaseName);
        }

        protected override bool DBContians()
        {
            if (!dbMasterConnectString.ToLower().Contains("master"))
                throw new CreateDBException("DBConnectString is wrong!");

            try
            {
                return dbExe.ExeScalar(dbMasterConnectString, string.Format("select 1 from master.dbo.sysdatabases where name='{0}'", DatabaseName), null) != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override int CreateDatebase()
        {
            if (!dbMasterConnectString.ToLower().Contains("master"))
                throw new CreateDBException("DBConnectString is wrong!");

            try
            {
                return dbExe.ExeNonQuery(dbMasterConnectString, string.Format("CREATE DATABASE {0} ON PRIMARY (NAME = MyDatabase_Data, FILENAME = '{1}{0}.mdf', SIZE = 3MB) LOG ON (NAME = MyDatabase_Log, FILENAME = '{1}{0}.ldf', SIZE = 1MB)", DatabaseName, DbFileDir), null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override bool TableContians(Type table, string tableName)
        {
            try
            {
                return dbExe.ExeScalar(null, string.Format("select 1 from sysobjects where name='{0}' and type='U'", tableName), null) != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int CreateTable(Type table, string tableName)
        {
            if (TableContians(table, tableName))
                return 0;

            try
            {
                StringBuilder sb = new StringBuilder("create table [");
                sb.Append(tableName);
                sb.Append("] (");
                bool firstItem = true;
                table.GetProperties().ToList().ForEach(s =>
                {
                    if (!firstItem)
                        sb.Append(" , ");
                    firstItem = false;
                    sb.Append(" [");
                    sb.Append(s.Name);
                    sb.Append("] ");
                    DBValueType valueType = Attribute.GetCustomAttribute(s, typeof(DBValueType)) as DBValueType;
                    if (valueType != null)
                    {
                        sb.Append(valueType.ValueType);
                    }
                    else
                    {
                        string propType = s.PropertyType.Name.ToLower();
                        switch (propType)
                        {
                            case "int32":
                                sb.Append("int");
                                break;
                            case "float":
                            case "float?":
                                sb.Append("float");
                                break;
                            case "string":
                                sb.Append("nvarchar(1000)");
                                break;
                            case "datetime":
                                sb.Append("datetime");
                                break;
                            case "byte []":
                                sb.Append("binary(65535)");
                                break;
                            default :
                                sb.Append(propType);
                                break;
                        }
                    }
                    PrimaryKey attrPrimaryKey = Attribute.GetCustomAttribute(s, typeof(PrimaryKey)) as PrimaryKey;
                    if (attrPrimaryKey != null)
                        sb.Append(" primary key");
                    Identity attrIdentity = Attribute.GetCustomAttribute(s, typeof(Identity)) as Identity;
                    if (attrIdentity != null)
                    {
                        sb.Append(" identity(");
                        sb.Append(attrIdentity.Seed);
                        sb.Append(",");
                        sb.Append(attrIdentity.Value);
                        sb.Append(")");
                    }
                    if (Attribute.GetCustomAttribute(s, typeof(Unique)) != null)
                        sb.Append(" unique");
                    if (Attribute.GetCustomAttribute(s, typeof(ValueNotNull)) != null)
                        sb.Append(" not null");
                    if (attrPrimaryKey == null)
                    {
                        ForeignKey attrForeignKey = Attribute.GetCustomAttribute(s, typeof(ForeignKey)) as ForeignKey;
                        if (attrForeignKey != null)
                        {
                            sb.Append(" FOREIGN KEY REFERENCES ");
                            sb.Append(attrForeignKey.TableName);
                            sb.Append("(");
                            sb.Append(attrForeignKey.Id);
                            sb.Append(")");
                        }
                    }
                    Default attrDefault = Attribute.GetCustomAttribute(s, typeof(Default)) as Default;
                    if (attrDefault != null)
                    {
                        sb.Append(" default(");
                        sb.Append(attrDefault.Value);
                        sb.Append(")");
                    }
                });
                sb.Append(")");

                return dbExe.ExeNonQuery(null, sb.ToString(), null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int DropTable(Type table, string tableName)
        {
            if (TableContians(table, tableName))
                return 0;

            try
            {
                return dbExe.ExeNonQuery(dbMasterConnectString, string.Format("drop table [{0}]", tableName), null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
