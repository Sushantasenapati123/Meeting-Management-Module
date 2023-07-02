

using Bank.Domain.Login;
using Exam.Domain.Meeting;
using Exam.Domain.Sports;
using Exam.Irepository.IMeeting;
using Exam.Irepository.ISport;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Web.Controllers
{//Sport_Registration
   
    public class SportController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly SpotInterface log;
        private readonly IMeeting _IMeeting;


        public SportController(SpotInterface _log, IWebHostEnvironment environment, IMeeting IMeeting)
        {
            _environment = environment;
            log = _log;
            _IMeeting = IMeeting;
        }
       
        public async Task<IActionResult> Sport_Registration()
        {
            try
            {
                //Log.Information("Sport_Registration Started");
                List<Spot> pc1 = new List<Spot>();
                // DesignationName ds = new DesignationName();//////for search
                pc1 = await log.BindClub();
                pc1.Insert(0, new Spot { club_id = 0, club_name = "Select" });
                ViewBag.UnitName = pc1;
                ViewBag.Result = await log.GetAll(new Spot());

                return View();
            }
            catch (Exception ex)
            {
               // Log.Error(ex.Message + "\n" + ex.StackTrace);
                return Json(0);
            }

        }
        public async Task<IActionResult> View_SportRegistration()
        {

            ViewBag.Result = await log.GetAll(new Spot());
            return View();
        }
        public async Task<IActionResult> LoginPage()
        {

           // ViewBag.Result = await _IMeeting.GetAll(new Spot());
            return View();
        }
        public async Task<IActionResult> AfterLoginPage()
        {
            ViewBag.Photo = HttpContext.Session.GetString("EmpPhoto"); ;
            ViewBag.Name = HttpContext.Session.GetString("EmpName"); ;
            return View();
        }

        public async Task<IActionResult> ScheduleMeeting()
        {
            ViewBag.Photo = HttpContext.Session.GetString("EmpPhoto"); ;
            ViewBag.Name = HttpContext.Session.GetString("EmpName"); ;

            List<Meeting> pc1 = new List<Meeting>();
            // DesignationName ds = new DesignationName();//////for search
            pc1 = await _IMeeting.bindmettinghall();
            pc1.Insert(0, new Meeting { MeetingHallID = 0, MeetingHallName = "Select" });
            ViewBag.Hall = pc1;

            List<Meeting> pc2 = new List<Meeting>();
           

            

            return View();
        }
        public async Task<JsonResult> SlotDetailBind(LoginEntity objslot)
        {
            LoginEntity lstapplicant = await _IMeeting.BindScheduleAsSlotid(objslot.MeetingHallID, objslot.DateOfBooking_date);
            var jsonres = JsonConvert.SerializeObject(lstapplicant);
            return Json(jsonres);
        }
       
        public async Task<JsonResult> SlotDetailBindView(LoginEntity objslot)
        {
            //String s = "";
            List<LoginEntity> pd = await _IMeeting.DisplaysedulebyDate(objslot.DateOfBooking_date);
            var jsonres = JsonConvert.SerializeObject(pd);
            return Json(jsonres);
        }



        public async Task<IActionResult> ViewMeeting()
        {
            ViewBag.Photo = HttpContext.Session.GetString("EmpPhoto"); ;
            ViewBag.Name = HttpContext.Session.GetString("EmpName"); ;

            List<Meeting> pc1 = new List<Meeting>();
            pc1 = await _IMeeting.bindmettinghall();
            pc1.Insert(0, new Meeting { MeetingHallID = 0, MeetingHallName = "Select" });
            ViewBag.Hall = pc1;

            List<Meeting> pc2 = new List<Meeting>();
           


            return View();
        }

        [HttpPost]
        public JsonResult loginpage(LoginEntity obj)
        {
             var result = _IMeeting.CheckLogin(obj);

            if (result.EmpName!=null)
            {
                    HttpContext.Session.SetString("EmpPhoto", result.EmpPhoto);
                    HttpContext.Session.SetString("EmpUserID", result.EmpUserID);
                    HttpContext.Session.SetInt32("EmpID", result.EmpID);
                    HttpContext.Session.SetString("EmpName", result.EmpName);
                    return Json(3);
                   


            }
            else
            {
                ViewBag.msg = "User Id And Password !!!!!";
                return Json(4);
               
            }

        }
        [HttpPost]
        public async Task<JsonResult> Add(Meeting entity)
        {

          entity.EmpID = HttpContext.Session.GetInt32("EmpID");

            int retMsg = await _IMeeting.Save_schedulemeeting(entity);

                if (retMsg == 1)
                {
                    return Json("Record Saved Successfully");
                }
                else if (retMsg == 2)
                {
                    return Json("Record Updated Successfully");
                }
                
               else
                {
                    return Json("Record Already Exist");
                }

            
          
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "prodimage");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }

        [HttpGet]
        public async Task<IActionResult> BindSlot(int MeetingHallID,DateTime DateOfBooking)
        {
          
            var Slots = _IMeeting.Bind_Slot(MeetingHallID, DateOfBooking).Result;
            return Ok(JsonConvert.SerializeObject(Slots));
        }


        [HttpGet]
        public IActionResult MedicineGetById(int id)
        {
            var Doctors = log.GetById(Convert.ToInt32(id)).Result;



            return Ok(JsonConvert.SerializeObject(Doctors));
        }


      
       

    }
}
