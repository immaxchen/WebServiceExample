using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FileUploadServer
{
    [WebService(Namespace = "http://example.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // [System.Web.Script.Services.ScriptService]
    public class FileUploadService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool UploadFile(string filepath, byte[] buffer, long offset)
        {
            if (offset == 0) File.Create(filepath).Close();
            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Write(buffer, 0, buffer.Length);
            }
            return true;
        }
    }
}
