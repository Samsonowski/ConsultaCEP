using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaCEP.DAL;
using ConsultaCEP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCEP.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class ConsultaCepAPIController : ControllerBase
    {
        private readonly CepDAO _cepDAO;
        public ConsultaCepAPIController(CepDAO cepDAO)
        {
            _cepDAO = cepDAO;
        }

        //GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult List()
        {
            return Ok(_cepDAO.List());
        }

        //GET: /api/Endereco/ListarEnderecos/{cep}
        [HttpGet]
        [Route("ListarEnderecos/{cep}")]
        public IActionResult List(string cep)
        {
            return Ok(_cepDAO.List(cep));
        }

        //POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Create(Cep cep)
        {
            _cepDAO.Create(cep);
            return Created("", cep);
        }

        //PUT: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult Update(Cep cep)
        {
            return Ok(_cepDAO.Update(cep));
        }

        //DELETE: /api/Endereco/DeletarEndereco/{cepID}
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_cepDAO.Delete(id));
        }

    }
}
