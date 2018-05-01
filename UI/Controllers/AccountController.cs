using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Itc.Am.BL;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.Common.ViewModels;
using Itc.Am.DL;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Migrations;
using Itc.Am.DL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebMatrix.WebData;
using Vacation = Itc.Am.Common.Models.Vacation;

namespace Itc.Am.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IWorktimeService worktimeService;
        private readonly IVacationService vacationService;
        private string sortOrder;

        public AccountController(IUserService userService, IRoleService roleService, IWorktimeService worktimeService, IVacationService vacationService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.worktimeService = worktimeService;
            this.vacationService = vacationService;
        }

      
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(UserVm vm)
        {
            UserModel user = new UserModel() { Email = vm.Email, Password = vm.Password, RoleName = "User" };
            UserModel userName = new UserModel() { Username = vm.Username, RoleName = "User" };

            user = userService.GetEmail(user.Email);
            userName = userService.GetUsername(userName.Username);

            if (ModelState.IsValid && user == null && userName == null)
            {
                vm.VCode = CreateSalt();
                vm.Password = CreatePasswordHash(vm.Password, vm.VCode);

                var model = new UserModel();
                model.Username = vm.Username;
                model.Email = vm.Email;
                model.Password = vm.Password;
                model.ConfirmPassword = vm.Password;
                model.FirstName = vm.FirstName;
                model.LastName = vm.LastName;
                model.VCode = vm.VCode;
                model.RoleName = "User";

                WebSecurity.CreateUserAndAccount(vm.Email, vm.Password);
                WebSecurity.Login(vm.Email, vm.Password);

                userService.CreateUser(model);

                var role = new Role();
                role.UserId = model.UserId;
                role.RoleName = model.RoleName;

                roleService.RoleAdd(role);

                FormsAuthentication.SetAuthCookie(vm.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, model.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Loggedin", "Address", vm);
            }
            else
            {
                ModelState.AddModelError("", "User already exists.");
                return View();
            }
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(UserLoginVm vm)
        {
            UserModel user = new UserModel() { Email = vm.Email, Password = vm.Password };

            user = userService.GetEmail(user.Email);
            vm.RoleName = user.RoleName;
            vm.UserId = user.UserId;

            if (ModelState.IsValid && vm.Email == user.Email && CreatePasswordHash(vm.Password, user.VCode) == user.Password)
            {
                FormsAuthentication.SetAuthCookie(vm.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                if (vm.RoleName == "Admin")
                {
                    return RedirectToAction("Admin", "Account", vm);
                }
                else
                {
                    return RedirectToAction("Loggedin", "Address", vm);
                }
            }
            else
            {
                ModelState.AddModelError("", @"Invalid login attempt.");
                return RedirectToAction("Register", "Account", vm);
            }
        }

        // POST: Logout
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Register", "Account");
        }

        // GET: Admin
        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        // GET: AllUsers
        [Authorize]
        public ActionResult AllUsers(String usrs)
        {
            var userlist = new List<UserModel>();
            var users = userService.Getusers();
            userlist.AddRange(users.Distinct());
            ViewBag.usrs = new SelectList(userlist);

            return View(users);
        }

        // GET: AllReports
        [Authorize]
        public ActionResult AllReports(String reports)
        {
            var vm = new AllReportsVm();
            var reportList = new List<AllReportsVm>();
            var allRecords = worktimeService.GetAllRecords();
            vm.Records = allRecords;
            
            ViewBag.reports = new SelectList(reportList);

            //ViewBag.UserId = from x in vm.Records select new SelectListItem() { Text = x.UserId.ToString(), Value = x.UserId.ToString() };


            //
            //var getUsers = allRecords.ToList();
            //SelectList list = new SelectList(getUsers, "UserId", "UserId");

            //ViewBag.getUsersId = list;


            return View(vm);
        }


        // GET: VacationRequests
        [Authorize]
        public ActionResult VacationRequests(String requests)
        {
            var vm = new VacsVm();
            var vacList = new List<VacsVm>();
            var allVacations = vacationService.GetAllVacations();
            vm.Vacations = allVacations;

            ViewBag.requests = new SelectList(vacList);

            return View(vm);
        }

        // POST: VacationRequests
        [Authorize]
        public void EditVac([Bind(Include = "Id, UserId, Status")] VacationVm request)
        {
                Vacation model = new Vacation();
                model = vacationService.GetVacationById(request.Id);

                model.Id = request.Id;
                model.UserId = request.UserId;
                model.Status = request.Status;

                vacationService.Update(model);
        }

        // POST: Delete
        [Authorize]
        public ActionResult DeleteVacation(int id)
        {
            vacationService.Delete(id);
            return RedirectToAction("VacationRequests");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            UserModel user = new UserModel();
            var vm = new EditVm();

            user.UserId = id;
           
            user = userService.GetUser(user.UserId);

            vm.UserId = user.UserId;
            vm.Email = user.Email;
            vm.Username = user.Username;
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.RoleName = user.RoleName;
            vm.Password = user.Password;
            vm.ConfirmPassword = user.ConfirmPassword;
            vm.VCode = user.VCode;
            
            return View(vm);
        }
        
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel vm)
        {
            if (ModelState.IsValid)
            {
                EditVm editUser = new EditVm();

                editUser.UserId = vm.UserId;
                editUser.Email = vm.Email;
                editUser.Username = vm.Username;
                editUser.FirstName = vm.FirstName;
                editUser.LastName = vm.LastName;
                editUser.RoleName = vm.RoleName;
                editUser.Password = vm.Password;
                editUser.ConfirmPassword = vm.ConfirmPassword;

                userService.Update(vm);


                TempData["Success"] = "User was successfully updated!";
                return RedirectToAction("AllUsers");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: AddUser
        [Authorize]
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: AddUser
        [HttpPost]
        public ActionResult AddUser(UserVm vm)
        {
            UserModel user = new UserModel() { Email = vm.Email, Password = vm.Password, RoleName = vm.RoleName };
            UserModel userName = new UserModel() { Username = vm.Username, RoleName = vm.RoleName };

            user = userService.GetEmail(user.Email);
            userName = userService.GetUsername(userName.Username);

            if (ModelState.IsValid && user == null && userName == null)
            {
                vm.VCode = CreateSalt();
                vm.Password = CreatePasswordHash(vm.Password, vm.VCode);

                var model = new UserModel();
                model.Username = vm.Username;
                model.Email = vm.Email;
                model.Password = vm.Password;
                model.ConfirmPassword = vm.Password;
                model.FirstName = vm.FirstName;
                model.LastName = vm.LastName;
                model.VCode = vm.VCode;
                model.RoleName = vm.RoleName;

                WebSecurity.CreateUserAndAccount(vm.Email, vm.Password, new { Email = vm.Email });
                WebSecurity.Login(vm.Email, vm.Password);

                userService.CreateUser(model);

                var role = new Role();
                role.UserId = model.UserId;
                role.RoleName = model.RoleName;

                roleService.RoleAdd(role);
                
                return RedirectToAction("Admin", "Account");
            }
            else
            {
                ModelState.AddModelError("", "User already exists.");
                return View();
            }
        }

        // GET: ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassVm vm)
        {
            UserModel user = new UserModel() { Email = vm.Email };
            user = userService.GetEmail(user.Email);

            if (user == null)
            {
                TempData["Message"] = "User does not exist.";
            }
            else
            {
                var token = WebSecurity.GeneratePasswordResetToken(user.Email);

                var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { un = vm.Email, rt = token }, "http") + "'>Reset Password</a>";

                string subject = "Password Reset Token";
                string body = "<b>Please find the Password Reset Token</b><br/>" + resetLink;

                try
                {
                    SendEMail(user.Email, subject, body);
                    TempData["Message"] = "Mail Sent.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error occured while sending email." + ex.Message;
                }
                //only for testing
                TempData["Message"] = resetLink;
            }

            return View();
        }


        // ResetPassword
        public ActionResult ResetPassword(string un, string rt)
        {
            UserModel user = new UserModel();
            user = userService.GetEmail(un);


            string newPassword = GenerateRandomPassword(6);
            bool response = WebSecurity.ResetPassword(rt, newPassword);

            user.Password = newPassword;

            user.VCode = CreateSalt();
            user.Password = CreatePasswordHash(user.Password, user.VCode);

            if (response)
            {
                userService.Update(user);

                FormsAuthentication.SetAuthCookie(user.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                //send email
                string subject = "New Password";
                string body = "<b>Please find the New Password</b><br/>" + newPassword;
                try
                {
                    SendEMail(user.Email, subject, body);
                    TempData["Message"] = "Mail Sent.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error occured while sending email." + ex.Message;
                }


                //display message
                TempData["Message"] = "Success! Check email we sent. Your New Password Is " + newPassword;
            }
            
            return View();
        }


        // Generate Random Password
        private string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }


        // Send Email
        private void SendEMail(string email, string subject, string body)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;


            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("xxxxx@gmail.com", "password");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("xxxxx@gmail.com");
            msg.To.Add(new MailAddress(email));

            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            client.Send(msg);
        }


        // Creating Salt
        private static string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] byteArr = new byte[32];
            rng.GetBytes(byteArr);

            return Convert.ToBase64String(byteArr);
        }

        // Hashing password
        private static string CreatePasswordHash(string password, string salt)
        {
            string passwordSalt = String.Concat(password, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordSalt, "sha1");
            return hashedPwd;
        }

    }
}