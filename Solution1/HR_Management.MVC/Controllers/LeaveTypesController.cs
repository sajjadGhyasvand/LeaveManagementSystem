﻿using HR_Management.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
