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

        

        public ViewResult List()
        {

            //ViewBag.Message = "Test Message";
            PiesListViewModel piesListViewModel = new()
            { 
                Pies = _pieRepository.AllPies,CurrentCategory="Cheese Cake"
            };

            return View(piesListViewModel);
        }
    }
}
