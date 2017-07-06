using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLog
{
    public class WorkLog
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTime StartTime { get; set; }
        public string StartTimeString
        {
            get
            {
                return StartTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
        public DateTime EndTime { get; set; }
        public string EndTimeString
        {
            get
            {
                return EndTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
        public TimeSpan WorkSpan
        {
            get
            {
                return EndTime - StartTime;
            }
        }
        public string WorkSpanString
        {
            get
            {
                return WorkSpan.ToString(@"hh\:mm\:ss");
            }
        }

        public string WorkLogString
        {
            get
            {
                return Category + "," + SubCategory + "," + 
                    StartTimeString + "," + 
                    EndTimeString + "," + 
                    WorkSpanString;
            }
        }

        private WorkLog() { }
        public WorkLog(string category, string subCategory, DateTime startTime, DateTime endTime)
        {
            this.Category = category;
            this.SubCategory = subCategory;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
