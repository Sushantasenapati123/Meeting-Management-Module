using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Meeting
{
   public class Meeting
    {
        public int? EmpID { get; set; }
        public int SlotID { get; set; }
        public int MeetingHallID { get; set; }

        public string MeetingHallName { get; set; }
        public string SlotName { get; set; }
        public string SlotTime { get; set; }

        public string EmpPhoto { get; set; }

        public DateTime DateOfBooking_date { get; set; }
    }
}
