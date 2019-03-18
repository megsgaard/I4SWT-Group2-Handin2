using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    class SeperationFileWriterUnitTests
    {
        private SeperationFileWriter _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new SeperationFileWriter();
        }

        //[Test]
        //public void HandleSeperation_TestMessageIsWrittenInLog_LogMessagesContainsTestMessage()
        //{
        //    string testMessage = "testMessage";
        //    string loadedMessage;

        //    _uut.HandleSeperation(testMessage);

        //    using (var sr = new StreamReader("LogMessages.txt"))
        //    {
        //        loadedMessage = sr.ReadLine();
        //    }

        //    Assert.That(loadedMessage, Is.EqualTo(testMessage));
        //}

    }
}
