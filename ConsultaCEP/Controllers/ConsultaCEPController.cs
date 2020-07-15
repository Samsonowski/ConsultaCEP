using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsultaCEP.DAL;
using ConsultaCEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//Aluno: Emerson Richter Samsonowski
namespace ConsultaCEP.Controllers
{
    public class ConsultaCEPController : Controller
    {
        private readonly CepDAO _cepDAO;
        public ConsultaCEPController(CepDAO cepDAO)
        {
            _cepDAO = cepDAO;
        }
        public IActionResult Index()
        {
            if (TempData["ConsultaCEP"] != null)
            {
                string jsonCEP = TempData["ConsultaCEP"].ToString();
                Cep cep = JsonConvert.DeserializeObject<Cep>(jsonCEP);

                _cepDAO.Create(cep);

                return View(_cepDAO.List());
            }
            return View(_cepDAO.List());
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
