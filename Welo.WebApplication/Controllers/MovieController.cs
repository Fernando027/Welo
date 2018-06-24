using System.Linq;
using System.Net;
using System.Web.Mvc;
using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Services;
using Welo.WebApplication.Models;

namespace Welo.WebApplication.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var viewModels = _service.GetAll().Select(m => new MovieViewModel
            {
                Id = m.Id,
                Genre = m.Genre,
                Name = m.Name,
                Year = m.Year
            }
                );
            return View(viewModels);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _service.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Name = movie.Name,
                Year = movie.Year
            };

            return View(movieViewModel);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Year,Genre")] MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = movieViewModel.Id,
                    Genre = movieViewModel.Genre,
                    Name = movieViewModel.Name,
                    Year = movieViewModel.Year
                };

                _service.Add(movie);
                return RedirectToAction("Index");
            }

            return View(movieViewModel);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _service.Get(id.Value);
            var movieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Name = movie.Name,
                Year = movie.Year
            };

            if (movieViewModel == null)
            {
                return HttpNotFound();
            }
            return View(movieViewModel);
        }

        // POST: Movie/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Genre")] MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = movieViewModel.Id,
                    Genre = movieViewModel.Genre,
                    Name = movieViewModel.Name,
                    Year = movieViewModel.Year
                };

                _service.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movieViewModel);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _service.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModel = new MovieViewModel
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Name = movie.Name,
                Year = movie.Year
            };

            return View(movieViewModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var movie = _service.Get(id);
            _service.Remove(movie);
            return RedirectToAction("Index");
        }
    }
}