using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class MoviesController: Controller
{
    private readonly IMovieService service;
    public MoviesController(IMovieService service)
    {
        this.service = service;
    }
    
    public IActionResult Index()
    {
        // service.PrintCasts();
        var items = service.GetAllMovies().Take(12);
        List<MovieCardViewModel> result = new List<MovieCardViewModel>();
        foreach (var item in items)
        {
            MovieCardViewModel model = new MovieCardViewModel();
            model.PosterUrl = item.PosterUrl;
            model.Title = item.Title;
            result.Add(model);
        }

        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }
}