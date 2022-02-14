using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {

        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }



        //public ViewResult List()
        //{

        //    //ViewBag.Message = "Test Message";
        //    PiesListViewModel piesListViewModel = new()
        //    {
        //        Pies = _pieRepository.AllPies,
        //        CurrentCategory = "Cheese Cake"
        //    };

        //    return View(piesListViewModel);
        //}


        public IActionResult Details(int Id)
        {
            var pie = _pieRepository.GetById(Id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }




        public ViewResult List(string category)
        {
            List<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId).ToList();
                currentCategory = "All Pies";

            }
            else
            {
                pies = _pieRepository.AllPies
                     .Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId).ToList();

                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category).ToString();
            }


            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });




        }

    }
}
