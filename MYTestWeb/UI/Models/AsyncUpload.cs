using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Util;
using System.IO;
using System.Web.Hosting;

namespace UI.Models
{
    /// <summary>
    /// 异步上传类(确保post的数据中只有1个 file 没有其他的字段)
    /// </summary>
    public class AsyncUpload
    {
        private byte[] wrapBytes = new byte[] { 13, 10, 13, 10 };//\r\n\r\n
        private byte[] headerBytes;//Content-Type header
        private byte[] fileNameHeader = new byte[] { 102, 105, 108, 101, 110, 97, 109, 101, 61, 34 };//filename="的ascii码
        private byte[] contentEnd;
        private byte[] perBodyBytes;
        private int preLen;
        private int totLen;
        private HttpWorkerRequest workerRequest;
        private int fPosition;
        private int fEndPosition;

        public delegate void UploadProcess(float per);
        public event UploadProcess uploadProcess;

        public string FileSaveDir
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            private set;
        }

        public int FileLength
        {
            get;
            private set;
        }

        public AsyncUpload(HttpWorkerRequest wRquest, string saveDir)
            : this(wRquest)
        {
            this.FileSaveDir = saveDir;
        }

        public AsyncUpload(HttpWorkerRequest wRquest)
        {
            if (wRquest == null) throw new ArgumentNullException("wRquest");
            this.uploadProcess = new UploadProcess(delegate(float f) { });
            workerRequest = wRquest;

            //当前读到的流长度
            this.preLen = workerRequest.GetPreloadedEntityBodyLength();
            //请求流的总长度
            this.totLen = workerRequest.GetTotalEntityBodyLength();
            //内容分隔符 如: -----------------------------152733254716788
            if (preLen == 0 && workerRequest.IsClientConnected() && workerRequest.HasEntityBody())
            {
                byte[] buffer = new byte[8192];
                preLen = workerRequest.ReadEntityBody(buffer, buffer.Length);
                byte[] buf = new byte[preLen];
                for (int i = 0; i < buf.Length; i++) buf[i] = buffer[i];
                this.perBodyBytes = buf;
            }
            else
                this.perBodyBytes = workerRequest.GetPreloadedEntityBody();

            this.headerBytes = this.GetBoundaryBytes(Encoding.UTF8.GetBytes(workerRequest.GetKnownRequestHeader(HttpWorkerRequest.HeaderContentType)));
            //请求流尾部分隔符 如: -----------------------------152733254716788--
            this.contentEnd = new byte[this.headerBytes.Length + 2];
            this.headerBytes.CopyTo(this.contentEnd, 0);
            this.contentEnd[this.headerBytes.Length] = 45;
            this.contentEnd[this.headerBytes.Length + 1] = 45;


            //当前流中第一个文件分隔符的位置
            int fHeaderPosition = perBodyBytes.Indexof(fileNameHeader);
            //尝试在已读取到的流中找文件尾位置
            this.fEndPosition = perBodyBytes.Indexof(contentEnd);
            if (fHeaderPosition > -1)
            {
                //先找到文件名
                IList<byte> bufList = new List<byte>();
                int i = fHeaderPosition + fileNameHeader.Length;
                while (i < perBodyBytes.Length)
                {
                    if (perBodyBytes[i] == 34) break;
                    bufList.Add(perBodyBytes[i]);
                    i++;
                }

                this.FileName = Encoding.UTF8.GetString(bufList.ToArray());//file name
                this.fPosition = perBodyBytes.Indexof(wrapBytes, i) + 4;//当前流中此文件的开始位置
                this.FileLength = this.totLen - this.fPosition;
            }
        }

        public void SaveFiles()
        {
            if (this.fPosition > 0)
            {
                FileStream fs = new FileStream(string.IsNullOrEmpty(this.FileSaveDir) ? string.Format("{0}UploadFiles\\{1}", Util.WebPathManager.DataUrl, this.FileName) : string.Format("{0}{1}\\{2}", Util.WebPathManager.DataUrl, this.FileSaveDir, this.FileName), FileMode.Create, FileAccess.Write);

                int rl = perBodyBytes.Length - this.fPosition;
                fs.Write(perBodyBytes, this.fPosition, perBodyBytes.Length - this.fPosition - (this.fEndPosition > 0 ? this.contentEnd.Length + 6 : 0));//把当前读取到的字节写入文件
                this.uploadProcess(((float)preLen / (float)totLen) * 100f);
                //HttpContext.Current.Session[sId] = rl;
                //还有未读取完的流
                while (workerRequest.IsClientConnected() && preLen < totLen)
                {
                    if (workerRequest.IsEntireEntityBodyIsPreloaded()) break;
                    byte[] buffer = new byte[8192];

                    int readLen = workerRequest.ReadEntityBody(buffer, 0, buffer.Length);
                    preLen += readLen;
                    if (preLen >= totLen)
                    {
                        this.uploadProcess(100f);
                        fs.Write(buffer, 0, readLen - this.contentEnd.Length);
                    }
                    else
                    {
                        this.uploadProcess(((float)preLen / (float)totLen) * 100f);
                        fs.Write(buffer, 0, readLen);
                    }
                    //HttpContext.Current.Session[sId] = rl + readLen;
                }

                fs.Close();
            }
        }

        private byte[] GetBoundaryBytes(byte[] buf)
        {
            int s = -1;

            for (int i = 0; i < buf.Length; i++)
                if (buf[i] == 61)
                {
                    s = i + 1;
                    break;
                }

            byte[] ret = new byte[buf.Length - s];
            if (s > 0)
            {
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = buf[s + i];
                }
            }

            return ret;
        }
    }
}