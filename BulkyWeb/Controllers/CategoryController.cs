﻿using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created succesfully";
                return RedirectToAction("Index","Category");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category edited succesfully";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _db.Categories.Find(id);

            if (category == null)
                return NotFound();

            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
