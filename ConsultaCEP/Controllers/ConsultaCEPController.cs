using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsultaCEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//Aluno: Emerson Richter Samsonowski
namespace ConsultaCEP.Controllers
{
    public class ConsultaCEPController : Controller
    {
        private readonly Context _context;
        public ConsultaCEPController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (TempData["ConsultaCEP"] != null)
            {
                string jsonCEP = TempData["ConsultaCEP"].ToString();
                Cep cep = JsonConvert.DeserializeObject<Cep>(jsonCEP);

                _context.Ceps.Add(cep);
                _context.SaveChanges();

                return View(_context.Ceps.ToList());
            }
            return View(_context.Ceps.ToList());
        }

        [HttpPost]
        public IActionResult ConsultarCEP(string txtCep)
        {
            string url =
                $@"https://viacep.com.br/ws/{txtCep}/json/";
            WebClient cliente = new WebClient();
            TempData["ConsultaCEP"] = cliente.DownloadString(url);
            return RedirectToAction("Index");
        }
    }
}
