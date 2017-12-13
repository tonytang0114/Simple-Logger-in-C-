using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger.IService;
namespace SimpleLogger
{
    public class Singleton
    {
        public IConfigParam Cf;
        public ILogWriter logwriter;

        public static Singleton instance = new Singleton();

        public Singleton()
        {
            Cf = new ConfigParameters();
            Cf.GetConfigSettings();
            logwriter = new LogWriter(Cf.Log_path, Cf.Log_folder, Cf.Log_filename, Cf.Archive_path);
        }

        public static Singleton getInstace()
        {
            return instance;
        }
    }
}
