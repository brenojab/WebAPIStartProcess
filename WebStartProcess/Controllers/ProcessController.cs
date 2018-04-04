using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStartProcess.Controllers
{
  [Route("process/[action]/{id?}")]
  public class ProcessController : Controller
  {
    private string _hostPath = string.Empty;

    [HttpPost]
    public string StartHostVersion(string id)
    {
      bool versaoAtual = string.Compare(id.ToUpper(), "ATUAL") == 0;
      
      if (!ExistsHostVersion(id, versaoAtual))
        return "Não existe o host desta versão, ou a versão está digitada incorretamente!";

      if (string.Compare(id.ToUpper(), "ATUAL") == 0)
        _hostPath = @"C:\RM\Atual\Release\bin\RM.Host.exe";
      else
        _hostPath = $@"C:\RM\legado\{id}\bin\RM.Host.exe";

      

      Process.Start(_hostPath);

      //return ReturnProcessPort();

      return "Iniciando host...";
    }

    private bool IsProcessAlreadyRunning(string checkPath)
    {
      foreach (var process in Process.GetProcesses())
      {
        if (string.Compare(process.ProcessName.ToUpper(), "RM.Host") == 0)
        {
          return string.Compare(process.MainModule.FileName, checkPath) == 0;
        }
      }

      // O processo não está em execução.
      return false;
    }

    private bool ExistsHostVersion(string version, bool versaoAtual)
    {
      if (!versaoAtual)
        return System.IO.File.Exists($@"C:\RM\legado\{version}\bin\RM.Host.exe");
      else
        return System.IO.File.Exists($@"C:\RM\Atual\Release\bin\RM.Host.exe");
    }

    private string ReturnProcessPort()
    {
      //Create the XmlDocument.
      XmlDocument doc = loadConfigDocument($@"{_hostPath}.config");


      XmlNode node = doc.SelectSingleNode("//Port");

      ////Display all the book titles.
      //XmlNodeList elemList = doc.GetElementsByTagName("Port");

      return "Host iniciado na porta 0";
    }

    private static XmlDocument loadConfigDocument(string hostPath)
    {
      XmlDocument doc = null;
      try
      {
        doc = new XmlDocument();
        doc.Load(hostPath);
        return doc;
      }
      catch (System.IO.FileNotFoundException e)
      {
        throw new Exception("No configuration file found.", e);
      }
      catch (Exception ex)
      {
        return null;
      }
    }




    //[HttpPost]
    //public void StartProcessId(int id)
    //{
    //  switch (id)
    //  {
    //    case 1:
    //      Process.Start("CALC");
    //      break;
    //    case 2:
    //      Process.Start("Notepad++");
    //      break;
    //    case 3:
    //      Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
    //      break;
    //    case 4:
    //      Process.Start(@"C:\Users\breno\AppData\Roaming\.minecraft\minecraft launcher\Minecraft Launcher.exe");
    //      break;
    //  }
    //}

    //[HttpPost]
    //public void StartProcessName(string id)
    //{
    //  Process.Start($@"{id}");
    //}




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