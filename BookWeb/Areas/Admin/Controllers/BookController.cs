using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Book> book = _unitOfWork.Book.GetAll();
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Update(book);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

            IEnumerable<SelectListItem> covers = _unitOfWork.Cover.GetAll().Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });


            if (id == null || id == 0)
            {
                // create book
                ViewBag.categories = categories;
                ViewBag.covers = categories;
                
            }
            // update book
            var book = _unitOfWork.Book.GetFirstOrDefault(x => x.Id == id);
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            _unitOfWork.Book.Remove(_unitOfWork.Book.GetFirstOrDefault(x => x.Id == id));
            _unitOfWork.Commit();
            return RedirectToAction("Index");

        }
    }
}
