using Bank.Domain.Login;
using Dapper;
using Exam.Domain.Meeting;
using Exam.Irepository.IMeeting;
using FstMonthExam.IRepository.Factory;
using PathoLab.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository.MeetingRepo
{
   public class MeetingRepo: RepositoryBase, IMeeting
    {
        public MeetingRepo(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
       
        public async Task<LoginEntity> BindScheduleAsSlotid(int id, DateTime dat)
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "BindScheduleAsSlotid");
                ObjParm.Add("@MeetingHallID", id);
                ObjParm.Add("@DateOfBooking", dat);
                var query = "Meeting";
                ObjParm.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<LoginEntity>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById[0];


            }
            catch (Exception ex)
            {
                return null;

            }
        }
     
        public async Task<List<LoginEntity>> DisplaysedulebyDate(DateTime dat)
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "DisplaysedulebyDate"); 
                      ObjParm.Add("@DateOfBooking", dat);
                var query = "Meeting";
                ObjParm.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<LoginEntity>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }
        
              public async Task<List<Meeting>> Bind_Slot(int id,DateTime dat)
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@MeetingHallID", id);
                ObjParm.Add("@DateOfBooking", dat);
                ObjParm.Add("@ACTION", "Bind_Slot");
                var query = "Meeting";
                ObjParm.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Meeting>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<List<Meeting>> bindmettinghall()
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "bindmettinghall");
                var query = "Meeting";
                ObjParm.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Meeting>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }
       
        public LoginEntity CheckLogin(LoginEntity p)
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@EmpUserID", p.EmpUserID);
                ObjParm.Add("@EmpPassword", p.EmpPassword);
                ObjParm.Add("@ACTION", "login");
                ObjParm.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var query = "Meeting";
                var GetAppById = Connection.Query<LoginEntity>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById[0];

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<int> Save_schedulemeeting(Meeting om)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@DateOfBooking", om.DateOfBooking_date);
                param.Add("@MeetingHallID", om.MeetingHallID);
                param.Add("@SlotID", om.SlotID);
                param.Add("@EmpID", om.EmpID);
               
                param.Add("@ACTION", "Save_schedulemeeting");
                param.Add("@PMSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                Connection.Execute("[Meeting]", param, commandType: CommandType.StoredProcedure);
                int x = Convert.ToInt32(param.Get<string>("@PMSGOUT"));

                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

      
    }
}
