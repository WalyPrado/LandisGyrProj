using LandisGyrProj.Interfaces;

namespace LandisGyrProj.Classes
{
    public class LogsSystem : ILogSystem
    {
        private List<string> logsSaved { get; set; }

        public LogsSystem()
        {
            logsSaved = new List<string>();
        }

        public void SaveLog(string message)
        {
            logsSaved.Add(string.Format("Date {0}: ", DateTime.Now) + message);
        }

        public void ShowLogs()
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
