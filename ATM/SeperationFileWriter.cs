using System;
using System.IO;
using System.Text;

namespace ATM
{
    public class SeperationFileWriter : ISeperationHandler
    {
        public void HandleSeperation(string message)
        {
            FileStream output = new FileStream("LogMessages.txt", FileMode.Append, FileAccess.Write);

            StreamWriter fileWriter = new StreamWriter(output);

            fileWriter.Write(message);

            fileWriter.Close();
            output.Close();
        }
    }
}