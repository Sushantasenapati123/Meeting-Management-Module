using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Login
{
    public class LoginEntity
    {
        public int EmpID { get; set; }
       
        public string EmpName { get; set; }
        public string EmpUserID { get; set; }
        public string EmpPassword { get; set; }

        public string EmpPhoto { get; set; }

        //public int? EmpID { get; set; }
        public int SlotID { get; set; }
        public int MeetingHallID { get; set; }

        public string MeetingHallName { get; set; }
        public string SlotName { get; set; }
        public string SlotTime { get; set; }

       /// public string EmpPhoto { get; set; }

        public DateTime DateOfBooking_date { get; set; }



        public string Slot1 { get; set; }
        public string Slot2 { get; set; }
        public string Slot3 { get; set; }
        public string Slot4 { get; set; }
        public string Slot5 { get; set; }
        public string Slot6 { get; set; }
        public string Slot7 { get; set; }
        public string Slot8 { get; set; }


    }
    public class SlotDetailModel
    {
        public string Slot1 { get; set; }
        public string Slot2 { get; set; }
        public string Slot3 { get; set; }
        public string Slot4 { get; set; }
        public string Slot5 { get; set; }
        public string Slot6 { get; set; }
        public string Slot7 { get; set; }
        public string Slot8 { get; set; }
        public string MeetingHallName { get; set; }
    }

}
