using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Utils
{
    public class FileUploader
    {
        public string SaveFile(string fileName, string savePath)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
            }
            return "";
        }
    }
}
