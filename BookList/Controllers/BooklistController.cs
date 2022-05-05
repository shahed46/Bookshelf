using BookList.Data;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookList.Controllers
{
    public class BooklistController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BooklistController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Bookname> objBooklist = _db.Bookes;
            return View(objBooklist);
        }
       //GET
        public IActionResult Add()
        {
           
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Bookname obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bookes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Booklist"); //action name=Index, Controller name=Booklist
            }
             return View(obj);
        }


        //EDIT
        //GET
        public IActionResult Edit(int? id)
            
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
             var bookFromDb = _db.Bookes.Find(id);
            if(bookFromDb == null)
            {
                return NotFound();
            }

            return View(bookFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bookname obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bookes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Booklist"); //action name=Index, Controller name=Booklist
            }
            return View(obj);
        }



        //DELETE
        //GET
        public IActionResult Delete(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _db.Bookes.Find(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }

            return View(bookFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Bookname obj)
        {
            
                _db.Bookes.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Booklist"); //action name=Index, Controller name=Booklist
            
           
        }

    }
}
