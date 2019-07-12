using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileUploadClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Upload(@"C:\Users\user\Desktop\demo.txt", @"C:\Users\user\Desktop\copy.txt");
        }

        static void Upload(string localFilePath, string remoteFilePath)
        {
            int chunksize = 1024 * 1024 * 2;
            var buffer = new byte[chunksize];
            var filesize = new FileInfo(localFilePath).Length;
            var stream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);
            var client = new FileUploadSvcRef.FileUploadServiceSoapClient();
            try
            {
                long offset = 0;
                while (offset != filesize)
                {
                    int bytesRead = stream.Read(buffer, 0, chunksize);
                    if (bytesRead != buffer.Length)
                    {
                        byte[] trimBuffer = new byte[bytesRead];
                        Array.Copy(buffer, trimBuffer, bytesRead);
                        buffer = trimBuffer;
                    }
                    bool success = client.UploadFile(remoteFilePath, buffer, offset);
                    if (!success) break;
                    offset += bytesRead;
                }
            }
            catch { }
            finally { stream.Close(); }
        }
    }
}
