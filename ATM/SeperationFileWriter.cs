using System.IO;
using System.Text;

namespace ATM
{
    public class SeperationFileWriter : ISeperationHandler
    {
        public void HandleSeperation(string message)
        {
            File.AppendAllText("Log\\LogMessage.txt", message);
        }
    }
}