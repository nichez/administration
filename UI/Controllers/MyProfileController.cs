using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.Common.ViewModels;
using Type = Itc.Am.Common.Models.Type;

namespace Itc.Am.UI.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly IWorktimeService worktimeService;
        private readonly IUserService userService;
        private readonly IVacationService vacationService;

        public MyProfileController(IWorktimeService worktimeService, IUserService userService, IVacationService vacationService)
        {
            this.worktimeService = worktimeService;
            this.userService = userService;
            this.vacationService = vacationService;
        }

        // GET: MyProfile
        [Authorize]
        public ActionResult MyProfile(int id)
        {
            UserModel user = new UserModel();
            var model = new UserVm();

            user = userService.GetUser(id);
            model.UserId = user.UserId;

            return View(model);
        }

        // GET: Worktime
        [Authorize]
        public ActionResult Worktime(int id)
        {
            UserModel user = new UserModel();
            var model = new WorktimeRecordVm();

            user = userService.GetUser(id);
            model.UserId = user.UserId;

            return View(model);
        }

        // POST: Worktime
        [HttpPost]
        public ActionResult Worktime(WorktimeRecordVm vm)
        {
            //if (!ModelState.IsValid)
            //{
                var model = new WorktimeRecord
                {
                    UserId = vm.UserId,
                    Date = vm.Date,
                    Time = vm.Time,
                    Info = vm.Info,
                    Type = vm.Type
                };

                worktimeService.Add(model);

                return RedirectToAction("MyProfile/" + vm.UserId);
          
        }

        //POST: Departure
        [HttpPost]
        public ActionResult Departure(WorktimeRecordVm vm)
        {
            //if (ModelState.IsValid)
            //{
                var model = new WorktimeRecord
                {
                    UserId = vm.UserId,
                    Date = vm.Date,
                    Time = vm.Time,
                    Info = vm.Info,
                    Type = vm.Type
                };

                worktimeService.Add(model);

                return RedirectToAction("MyProfile/"+ vm.UserId);
            
        }

        // GET: MyReport
        [Authorize]
        public ActionResult MyReport(int id)
        {
            UserModel user = new UserModel();
            user = userService.GetUser(id);

            var record = worktimeService.GetAllRecords().Where(u => u.UserId == id);
            var recordlist = new List<WorktimeRecord>();
           

            recordlist.AddRange(record.Distinct());
            ViewBag.record = new SelectList(recordlist);
            //

            //
            WorktimeRecord rec = new WorktimeRecord();
            WorktimeRecord model = new WorktimeRecord();

            rec = worktimeService.GetRecord(id);
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime();

            double result = 0;
            int starthours = 0;
            int startminutes = 0;
            int endhours = 0;
            int endminutes = 0;
            double subtract = 0;
            double submin = 0;

            foreach (var item in recordlist)
            {

                if (item.Type == Type.Arrival)
                    {
                        startTime = item.Time;
                        starthours = startTime.Hour;
                        startminutes = startTime.Minute;
                }
                    else
                    {
                        endTime = item.Time;
                        endhours = endTime.Hour;
                        endminutes = endTime.Minute;
                        subtract = endhours - starthours;
                        result = result + subtract;
                }

                //submin = endminutes - startminutes;
                //subtract = subtract + submin;
                
            }
            

            ViewBag.workHours = result;

            MyReportVm vm = new MyReportVm() {
                MyReports = recordlist,
                UserId = id
            };
            return View(vm);
        }

        // GET: Vacation
        [Authorize]
        public ActionResult Vacation(int id)
        {
            UserModel user = new UserModel();
            var model = new VacationVm();

            user = userService.GetUser(id);
            model.UserId = user.UserId;
            model.Username = user.Username;

            Vacation vm = new Vacation();
            vm = vacationService.GetVacationByUserId(model.UserId);

            var vacations = vacationService.GetAllVacations().Where(m => m.UserId == id);

            foreach (var item in vacations)
            {
                if (item?.Status == Status.Accepted)
                {
                    ViewBag.Approved = "Your vacation request from " + item.StartDate + " to " + item.EndDate + " was approved!";
                }
                else if (item?.Status == Status.Rejected)
                {
                    ViewBag.Rejected = "Your vacation request from " + item.StartDate + " to " + item.EndDate + " was rejected!";
                }
                else if (item?.Status == Status.Pending)
                {
                    ViewBag.Pending = "Your request is pending!";
                }
                else
                {
                    ViewBag.NoValue = " ";
                }
            }

            return View(model);
        }

        // POST: Vacation
        [HttpPost]
        public ActionResult Vacation(VacationVm vm)
        {
            if (ModelState.IsValid)
            {
                Vacation model = new Vacation()
                {
                    UserId = vm.UserId,
                    Username = vm.Username,
                    StartDate = vm.StartDate,
                    EndDate = vm.EndDate,
                    Status = Status.Pending
                };
                vacationService.Add(model);

                ViewBag.Success = "Your request was successfully sent!";
            }

            return View(vm);
        }
        
        
        
    }
}