using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamQuocHuy_Template.Data;
using PhamQuocHuy_Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhamQuocHuy_Template.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _applicationDbContext;
		public UserController(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public IActionResult Index()
		{
            List<Users> users = _applicationDbContext.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
		{
            var DB1 = _applicationDbContext; 

            var items = DB1.Industries
                .Select(x => new SelectListItem
                {
                    Value = x.IdIndustries.ToString(),
                    Text = x.NameIndust, 
                                         
                })
                .ToList();

            ViewBag.ItemList = items;
            return View();
		}
		[HttpPost]
		public IActionResult Create(string UserName, DateTime Birth, string Email, string Gender,string Phone, string[] IndustSelect)
		{
            if (ModelState.IsValid && IndustSelect.Length > 0)
            {
                var user = new Users
                {
                   UserName = UserName,
                   Birth = Birth,
                   Email = Email,
                   Gender = Gender,
                   Phone = Phone,
                   Status = 0
                };
                _applicationDbContext.Add(user);
                _applicationDbContext.SaveChanges();
                foreach (var item in IndustSelect)
                {
                    var details = new IndustriesDetails
                    {
                        IdUser = user.IdUser, 
                        IdIndustries = int.Parse(item) 
                    };
                   
                    _applicationDbContext.IndustriesDetails.Add(details);
                }
                _applicationDbContext.SaveChanges();
                TempData["SuccessMessage"] = "Bạn đã nộp CV thành công. Vui lòng chờ thông tin gửi đến Email hoặc Số điện thoại!";
                return RedirectToAction("Create");

            }
            else
            {
               
                    TempData["ErrorMessage"] = "Đã có lỗi trong lúc nhập hoặc chọn.";
             
            }
            return RedirectToAction("Create", "User");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _applicationDbContext.Users.FirstOrDefault(u => u.IdUser == id);

            if (user == null)
            {
                return NotFound();
            }         
            user.IndustriesDetails = _applicationDbContext.IndustriesDetails
                .Include(i => i.Industries)
                .Where(i => i.IdUser == id)
                .ToList();

            return View(user);
        }
        public IActionResult Approve(int id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u => u.IdUser == id);
            if (user != null)
            {
                user.Status = 2;
               _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Pending(int id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u => u.IdUser == id);
            if (user != null)
            {
                user.Status = 1;
                _applicationDbContext.SaveChanges();
            }     
            return RedirectToAction("Details", new { id = id });
        }
        public IActionResult Delete(int id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u => u.IdUser == id);
            if (user != null)
            {

                _applicationDbContext.Users.Remove(user);
                TempData["SuccessMessage"] = "Đã xóa thành công.";
                _applicationDbContext.SaveChanges();
            }

           
            return RedirectToAction("Index");
        }
    }
}
