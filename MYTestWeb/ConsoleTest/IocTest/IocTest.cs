using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class IocTest : IIocTest
    {
        private Util.Log.ILog log;
        private string message;
        private Util.Log.ILog mlog;

        public Util.Log.ILog Log
        {
            get;
            set;
        }

        public IocTest(Util.Log.ILog log, string msg)
        {
            this.log = log;
            message = msg;
        }

        public void TestMethodIoc(Util.Log.ILog log)
        {
            mlog = log;
        }

        public bool DoMethodIoc()
        {
            return mlog.Action("这是方法注入");
        }

        public bool TestConstrIoc()
        {
            return log.Action(message);
        }

        public bool TestParamIoc()
        {
            return this.Log.Action("这是属性注入");
        }
    }
}
