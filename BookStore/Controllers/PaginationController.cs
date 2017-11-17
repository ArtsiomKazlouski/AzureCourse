using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStore.Models.Pagination;

namespace BookStore.Controllers
{
    public class PaginationController : Controller
    {
        // GET: Pagination
        public ActionResult Index()
        {
            return View();
        }
    }
}