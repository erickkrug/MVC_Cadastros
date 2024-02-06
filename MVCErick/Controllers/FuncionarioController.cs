using MVCErick.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCErick.Controllers
{
    public class FuncionarioController : Controller
    {

        readonly private ApplicationDBContext _dbContext;

        public FuncionarioController(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }


    }
}