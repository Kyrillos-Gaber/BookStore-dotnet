using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository.IRepository;

namespace BookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Cover> covers = _unitOfWork.Cover.GetAll();
            return View(covers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cover cover)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cover.Add(cover);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(cover);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cover cover)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cover.Update(cover);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(cover);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var cover = _unitOfWork.Cover.GetFirstOrDefault(x => x.Id == id);
            return View(cover);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            _unitOfWork.Cover.Remove(_unitOfWork.Cover.GetFirstOrDefault(x => x.Id == id));
            _unitOfWork.Commit();
            return RedirectToAction("Index");

        }
    }
}
