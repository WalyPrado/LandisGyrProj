using LandisGyrProj.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace LandisGyrProj.Classes
{
    public class LogsSystem : ILogSystem
    {
        public List<string> logsSaved { get; set; }

        public LogsSystem()
        {
            logsSaved = new List<string>();
        }

        public void SaveLog(string message)
        {
            logsSaved.Add(string.Format("Date {0}: ", DateTime.Now) + message);
        }

        public void ShowLog()
        {
            if (logsSaved.Count > 0)
            {
                logsSaved.ForEach(log =>
                {
                    Console.WriteLine(log);
                });
            }
            else
            {
                Console.WriteLine(string.Format("Date {0}: Logs not found!", DateTime.Now));
            }
        }
    }
}
