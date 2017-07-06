using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLog
{
    public class LogManager
    {
        private ObservableCollection<WorkLog> myWorkLogCollection = new ObservableCollection<WorkLog>();

        public LogManager()
        {
            this.MyWorkLogCollection = ReadLog();
            WriteLog(this.MyWorkLogCollection);
        }

        public ObservableCollection<WorkLog> MyWorkLogCollection { get => myWorkLogCollection; set => myWorkLogCollection = value; }

        private ObservableCollection<WorkLog> ReadLog()
        {
            var streamReader = new StreamReader(@"log.txt");

            var myLineLogData = new List<string>();
            while (!streamReader.EndOfStream)
            {
                myLineLogData.Add(streamReader.ReadLine());
            }

            var workLogCollection = new ObservableCollection<WorkLog>();
            foreach (var line in myLineLogData)
            {
                var eachData = line.Split(',');
                workLogCollection.Add(new WorkLog(
                    eachData[0],
                    eachData[1],
                    DateTime.ParseExact(eachData[2], "yyyy/MM/dd HH:mm:ss", null),
                    DateTime.ParseExact(eachData[3], "yyyy/MM/dd HH:mm:ss", null)
                    ));
            }

            streamReader.Close();
            return workLogCollection;
        }

        private void WriteLog(ObservableCollection<WorkLog> workLog)
        {
            var myStreamWriter = new StreamWriter(@"log.txt", true);
            foreach (var line in workLog)
            {
                myStreamWriter.WriteLine(line.WorkLogString);
            }
            myStreamWriter.Close();
        }
    }
}
