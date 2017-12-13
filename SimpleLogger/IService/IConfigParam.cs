using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.IService
{
    public interface IConfigParam
    {
        string Log_path { get; }
        string Archive_path { get; }
        string Log_filename { get; }
        string Log_folder { get;  }
        void GetConfigSettings();
    }
}
