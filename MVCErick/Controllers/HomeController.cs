using MVCErick.Data;
using MVCErick.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCErick.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDBContext _dbContext = new ApplicationDBContext();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(_dbContext.Usuarios.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Formulary()
        {
            ViewBag.Message = "Your Formulary page.";
            return View();
        }

        public ActionResult RegisterUsers()
        {
            ViewBag.Message = "Your user registration page ;3";
            return View();
        }

        public ActionResult Exibir()
        {
            return View();
        }

        public ActionResult ExibirFiltrados(UsuarioRequest objRequest)
        {
            var usuarios = _dbContext.Usuarios.Include(w => w.Empresa).ToList();

            //List<UsuarioResponse> exemploDeModelo = usuarios
            //    .Where(model => model.CPF == objRequest.CPF)
            //    .Select(item => new UsuarioResponse()
            //    {
            //        //Preencher objeto para retorno
            //        CNPJ = item.CPF,

            //    }).ToList();


            List<UsuarioResponse> usuariomodel = usuarios
            .Where(model =>
            (string.IsNullOrEmpty(objRequest.CPF) || model.CPF == objRequest.CPF) && // Verifica se o CPF é vazio ou corresponde ao filtro
            (string.IsNullOrEmpty(objRequest.Nome) || model.Nome == objRequest.Nome) && // Verifica se o Nome é vazio ou corresponde ao filtro
            (string.IsNullOrEmpty(objRequest.Telefone) || model.Telefone == objRequest.Telefone)) // Verifica se o Telefone é vazio ou corresponde ao filtro
            .Select(item => new UsuarioResponse()
    {
            // Preencher objeto para retorno
            NomeUsuario = item.Nome,
            CPF = item.CPF,
            TelefoneUsuario = item.Telefone,
            DescricaoUsuario = item.Descricao,
            NomeEmpresarial = item.Empresa.NomeEmpresa,
            EnderecoEmpresa = item.Empresa.EnderecoEmpresa,
            CNPJEmpresa = item.Empresa.CNPJ,
            CriacaoEmpresa = item.Empresa.DataCriacao,
            DescricaoEmpresarial = item.Empresa.DescricaoEmpresa
            }).ToList();

            var json = JsonConvert.SerializeObject(usuariomodel); // Serializa os dados para JSON

            return Content(json, "application/json"); // Retorna os dados serializados
        }


    }
}