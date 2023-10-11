// See https://aka.ms/new-console-template for more information
using System;

namespace DelegateStaticMethod;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoggingDel logDel1 = new LoggingDel(LogToScreen);
            LoggingDel logDel2 = new LoggingDel(LogToFile);
            LoggingDel logDelMulti = logDel1+ logDel2;
            //logDel += new LoggingDel(LogToFile);
            //logDel("Hey logging happening here");
            logDelMulti("Hey logging happening here");
            //This call both the LogToFile and LogToScreen methods
            // Here these methods are static, but they can also belong to a class
            // In that case, create an object of the class Log l = new Log(); and the add l.method() to delegate

            


        }
    
        // Delegates can also be passed as arguments to a function
        static void LogToNowhere(LoggingDel del, string msg)
        {}



delegate void LoggingDel(string msg);

static void LogToScreen(string msg)
{
    Console.WriteLine($"Logging : {msg} \t{DateTime.Now}");
}

static void LogToFile(string msg)
{
    using(StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"MyLog.txt"), true))
    {
        sw.WriteLine($"Logging : {msg} \t{DateTime.Now}");
    }
}

}