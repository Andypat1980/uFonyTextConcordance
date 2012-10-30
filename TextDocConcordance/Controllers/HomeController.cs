using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextDocConcordance.IApplicationService;
using TextDocConcordanceDTO;

namespace TextDocConcordance.Controllers
{
    public class HomeController : Controller
    {
        ITextConcordanceAppService appService;
        public HomeController(ITextConcordanceAppService appService)
        {
            this.appService = appService;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtArea)
        {
            string textToconcordance = txtArea;

            ConcordanceDTO concordanceDTO = new ConcordanceDTO();
            concordanceDTO.Words = appService.GetConcordanceWordsFrom(txtArea);
            concordanceDTO.DocText = txtArea;

            return View("Concordance",concordanceDTO);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
