using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WSP.ABSTRACTION.LOGGER;

namespace Api.App.WspAdministration.Controllers
{
    public class webhooks : Controller
    {
        private readonly ILoggerInfo _logger;
        public webhooks(ILoggerInfo logger)
        {
            this._logger = logger;
        }
        // GET: webhooks
        public ActionResult Index(string mode, int challenge, string verify_token)
        {
            this._logger.Debug(string.Format(" REQUEST: {0} , {1} , {2}", mode, challenge, verify_token));
            return View();
        }

        // GET: webhooks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: webhooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: webhooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: webhooks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: webhooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: webhooks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: webhooks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
