using System;
using System.Collections.Generic;
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

namespace Itc.Am.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}