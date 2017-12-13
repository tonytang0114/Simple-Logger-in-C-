using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.IService
{
    public interface ILogWriter
    {
        void CheckFolderIfExist();
        void CreateStreamForLog();
        string Generate_File_with_a_standard();
        string Generate_Log_Path(string filename);
        void WriteLine(string text);
        void Move_To_Archive_Folder();
    }
}
