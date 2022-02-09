using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using Task = Mission6.Models.Task;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext taskContext { get; set; }

        public HomeController(TaskContext someTask)
        {
            taskContext = someTask;
        }

        public IActionResult Index()
        {
            var tasks = taskContext.Tasks
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(task);
                taskContext.SaveChanges();

                return View("Index");
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();

                return View();
            }
        }

        //public IActionResult Quadrants()
        //{
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Edit(int taskID)
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            var task = taskContext.Tasks.Single(x => x.TaskID == taskID);

            return RedirectToAction("AddTask", task);
        }

        [HttpPost]
        public IActionResult Edit(Task info)
        {
            taskContext.Update(info);
            taskContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int taskID)
        {
            var task = taskContext.tasks.Single(x => x.TaskID == taskID);

            taskContext.Tasks.Remove(task);
            taskContext.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Delete()
        //{
        //    return RedirectToAction("Index");
        //}


    }
}
