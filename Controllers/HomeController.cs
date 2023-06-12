using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Controllers;

public class HomeController : Controller
{
    private readonly IPieRepository _pieRepository;
    private readonly IProductoRepositorio _productoRepositorio;
    private readonly ICategoriaRepositorio _categoryRepository;

    public HomeController(IPieRepository pieRepository, IProductoRepositorio productoRepositorio, ICategoriaRepositorio categoryRepository)
    {
        _pieRepository = pieRepository;
        _productoRepositorio = productoRepositorio;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        //var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        //var homeViewModel = new HomeViewModel(piesOfTheWeek);
        //return View(homeViewModel);
        ProductoListViewModel productos = new ProductoListViewModel(_categoryRepository.Categorias, _productoRepositorio.filtroDelete);
        //return View(_productoRepository.AllProductos);
        return View(productos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult About()
    {
        return View();
    }
}
