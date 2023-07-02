using Bank.Domain.Login;
using Exam.Domain.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Irepository.IMeeting
{
   public interface IMeeting
    {
        LoginEntity CheckLogin(LoginEntity n);//

        Task<List<Meeting>> bindmettinghall();
        Task<List<Meeting>> Bind_Slot(int id,DateTime dat);

        Task<int> Save_schedulemeeting(Meeting p);//

        Task<LoginEntity> BindScheduleAsSlotid(int id, DateTime dat);//

        Task<List<LoginEntity>> DisplaysedulebyDate(DateTime dat);//
    }
}
