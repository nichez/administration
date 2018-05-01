using System;
using System.Collections.Generic;
using System.Linq;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.Common.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebMatrix.WebData;

namespace Itc.Am.UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;
        private readonly IUserAddressService userAddressService;
        private readonly IUserService userService;

        public AddressController(IAddressService addressService, IUserAddressService userAddressService, IUserService userService)
        {
            this.addressService = addressService;
            this.userAddressService = userAddressService;
            this.userService = userService;
        }

        // GET: Loggedin
        [Authorize]
        public ActionResult Loggedin(UserVm vm)
        {
            UserVm model = new UserVm
            {
                UserId = vm.UserId
            };
            userService.GetUser(model.UserId);
            return View(vm);
        }

        // GET: MyProfile
        //[Authorize]
        //public ActionResult MyProfile(WorktimeRecordVm vm)
        //{
        //    return View();
        //}

        // POST: MyProfile
        //[HttpPost]
        //public ActionResult MyProfile(AddressVm vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Address model = new Address();

        //        model.AddressFirst = vm.AddressFirst;
        //        model.AddressSecond = vm.AddressSecond;
        //        model.PostalCode = vm.PostalCode;
        //        model.City = vm.City;
        //        model.Country = vm.Country;

        //        addressService.Add(model);

        //        //var model = new Address()
        //        //{
        //        //    AddressFirst = vm.AddressFirst,
        //        //    AddressSecond = vm.AddressSecond,
        //        //    PostalCode = vm.PostalCode,
        //        //    City = vm.City,
        //        //    Country = vm.Country
        //        //};


        //        UserAddress uAddress = new UserAddress();

        //        uAddress.AddressId = vm.AddressId;
        //        uAddress.UserId = vm.UserId;

        //        userAddressService.Add(uAddress);


        //        //var userAddressModel = new UserAddress()
        //        //{
        //        //    AddressId = model.AddressId,
        //        //    UserId = id
        //        //};
        //        //userAddressService.Add(userAddressModel);

        //        return View(vm);
        //    }

        //    ModelState.AddModelError("", "Address failed to save.");
        //    return View();

        //}

        // GET: AllUsers
        [Authorize]
        public ActionResult AllAddresses(String address)
        {
            var vm = new AllAddressVm();
            var addresslist = new List<AllAddressVm>();
            var addresses = addressService.GetAll();
            var usrAddress = userAddressService.GetAllAdd();
            vm.Addresses = addresses;
            vm.UserAddresses = usrAddress;
            //addresslist.AddRange(addresses.Distinct());
            ViewBag.usrs = new SelectList(addresslist);

            return View(vm);
        }


        // GET: AddAddress
        [Authorize]
        public ActionResult AddAddress(int id)
        {
            UserModel user = new UserModel();
            var model = new AddressVm();
            
            user = userService.GetUser(id);
            model.UserId = user.UserId;
            
            return View(model);
        }

        //POST: AddAddress
        [HttpPost]
        public ActionResult AddAddress(AddressVm vm)
        {
            if (ModelState.IsValid)
            {
                var model = new Address();
                model.AddressFirst = vm.AddressFirst;
                model.AddressSecond = vm.AddressSecond;
                model.PostalCode = vm.PostalCode;
                model.City = vm.City;
                model.Country = vm.Country;

                addressService.Add(model);

                var uAddress = new UserAddress();
                uAddress.UserId = vm.UserId;
                uAddress.AddressId = model.AddressId;

                userAddressService.Add(uAddress);

                return RedirectToAction("Loggedin", "Address");
            }
            else
            {
                ModelState.AddModelError("", "You have to fill all required fields.");
                return View();
            }
        }


        // GET: Edit
        public ActionResult EditAddress(int id, int q)
        {
            Address address = new Address();
            var vm = new EditAddressVm();

            address.AddressId = id;

            address = addressService.GetById(address.AddressId);

            vm.AddressId = address.AddressId;
            vm.AddressFirst = address.AddressFirst;
            vm.AddressSecond = address.AddressSecond;
            vm.City = address.City;
            vm.PostalCode = address.PostalCode;
            vm.Country = address.Country;
            vm.UserId = q;

            return View(vm);
        }

        // POST: EditAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(Address vm)
        {
            if (ModelState.IsValid)
            {
                EditAddressVm editAddress = new EditAddressVm();

                editAddress.AddressId = vm.AddressId;
                editAddress.AddressFirst = vm.AddressFirst;
                editAddress.AddressSecond = vm.AddressSecond;
                editAddress.City = vm.City;
                editAddress.PostalCode = vm.PostalCode;
                editAddress.Country = vm.Country;

                addressService.Update(vm);
                
                TempData["Success"] = "Address was successfully updated!";
                return RedirectToAction("AllAddresses", "Address");
            }
            else
            {
                return HttpNotFound();
            }
        }



    }
}