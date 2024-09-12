﻿using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();

            return View(objDiaryEntryList);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            _db.DiaryEntries.Add(obj); // Add the new diary entry to the database
            _db.SaveChanges(); //save changes to the database
            return RedirectToAction("Index");
        }
    }
}
