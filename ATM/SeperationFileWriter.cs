using System;
using System.IO;
using System.Text;

namespace ATM
{
    public class SeperationFileWriter : ISeperationHandler
    {
        private FileStream _output;

        public SeperationFileWriter()
        {
            _output = new FileStream("LogMessages.txt", FileMode.OpenOrCreate, FileAccess.Write);
        }

        public void HandleSeperation(string message)
        {
            using (var fileWriter = new StreamWriter(_output))
            {
                fileWriter.Write(message);
            }
        }
    }
}