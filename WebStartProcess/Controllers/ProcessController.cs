using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStartProcess.Controllers

{
  [Route("process/[action]/{id?}")]
  public class ProcessController : Controller
  {
    [HttpPost]
    public void StartProcessId(int id)
    {
      switch (id)
      {
        case 1:
          Process.Start("Notepad");
          break;
        case 2:
          Process.Start("Notepad++");
          break;
        case 3:
          Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
          break;
      }
    }

    [HttpPost]
    public void StartProcessName(string id)
    {
      Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");

    }

    //// GET: Process
    //public ActionResult Index()
    //{
    //  return View();
    //}

    //// GET: Process/Details/5
    //public ActionResult Details(int id)
    //{
    //  return View();
    //}

    //// GET: Process/Create
    //public ActionResult Create()
    //{
    //  return View();
    //}

    //// POST: Process/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //  try
    //  {
    //    // TODO: Add insert logic here

    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}

    //// GET: Process/Edit/5
    //public ActionResult Edit(int id)
    //{
    //  return View();
    //}

    //// POST: Process/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //  try
    //  {
    //    // TODO: Add update logic here

    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}

    //// GET: Process/Delete/5
    //public ActionResult Delete(int id)
    //{
    //  return View();
    //}

    //// POST: Process/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //  try
    //  {
    //    // TODO: Add delete logic here

    //    return RedirectToAction(nameof(Index));
    //  }
    //  catch
    //  {
    //    return View();
    //  }
    //}
  }
}