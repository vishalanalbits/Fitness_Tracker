// Controllers/ActivityController.cs

using Microsoft.AspNetCore.Mvc;
using FitnessTracker.ViewModels;
using FitnessTracker.Models;
using System;
using FitnessTracker.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FitnessTracker.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Activity/Log
        public IActionResult Log()
        {
            return View("Log");
        }

        // POST: /Activity/Log
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Log(ActivityLogViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map view model data to activity record
                var activityRecord = new ActivityRecord
                {
                    ActivityType = model.ActivityType,
                    DurationInMinutes = model.DurationInMinutes,
                    Distance = model.Distance,
                    Intensity = model.Intensity,
                    CaloriesBurned = model.CaloriesBurned,
                    DateLogged = DateTime.Now // Assuming the current date/time is logged
                };

                // Save activity record to database
                _context.ActivityRecords.Add(activityRecord);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Activity logged successfully."; // Set success message

                return RedirectToAction("ViewActivities"); // Redirect to view activities page after logging activity
            }

            // If model state is not valid, return the view with validation errors
            return View(model);
        }

        // GET: /Activity/ViewActivities
        public IActionResult ViewActivities()
        {
            // Retrieve logged activities from the database
            var loggedActivities = _context.ActivityRecords.ToList(); // Get all activity records

            // Map activity records to view model if necessary

            return View(loggedActivities);
        }
    }
}
