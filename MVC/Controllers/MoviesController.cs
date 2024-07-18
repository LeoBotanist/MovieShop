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
        var items = service.GetAllMovieCards().Take(12);
        List<MovieCardViewModel> result = new List<MovieCardViewModel>();
        foreach (var item in items)
        {
            MovieCardViewModel model = new MovieCardViewModel();
            model.Id = item.Id;
            model.PosterUrl = item.PosterUrl;
            model.Title = item.Title;
            result.Add(model);
        }

        return View(result);
    }

    public IActionResult Details(int id)
    {
        var model = service.GetMovieDetailsById(id);
        
        MovieDetailPageModel entity = new MovieDetailPageModel();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.Tagline = model.Tagline;
        entity.Price = model.Price;
        entity.Revenue = model.Revenue;
        entity.Title = model.Title;
        entity.CreatedBy = model.CreatedBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.Overview = model.Overview;
        entity.OriginalLanguage = model.OriginalLanguage;
        entity.PosterUrl = model.PosterUrl;
        entity.ReleaseDate = model.ReleaseDate;
        entity.RunTime = model.RunTime;
        entity.TmdbUrl = model.TmdbUrl;
        entity.UpdatedDate = model.UpdatedDate;
        entity.UpdatedBy = model.UpdatedBy;
        entity.Casts = model.Casts;
        entity.Genres = model.Genres;
        entity.Reviews = model.Reviews;
        entity.Purchases = model.Purchases;
        Console.WriteLine($"Casts length: {entity.Casts.Count()}");
        Console.WriteLine($"NULL ??????????????? {entity.BackdropUrl}");
        return View(entity);
    }
    
    public IActionResult Create()
    {
        return View();
    }
}