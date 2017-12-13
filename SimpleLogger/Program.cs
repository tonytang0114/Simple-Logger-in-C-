using System;
using SimpleLogger.IService;

namespace SimpleLogger
{
    public class Program
    {

        static void Main(string[] args)
        {
            Singleton Log1 = Singleton.getInstace();
            //keep track
            Log1.logwriter.WriteLine("");//call like this in every function
        }
    }
}
