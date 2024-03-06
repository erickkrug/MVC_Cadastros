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
            List<UsuarioModels> usuarios = _dbContext.Usuarios.ToList();

            if (usuarios != null && usuarios.Any())
                ViewBag.UsuariosArray = usuarios.ToArray();
            else
                Console.WriteLine(" Houve um problema, procure se vire ;3");// ou qualquer outro tratamento desejado
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = " Ãprenda um pouco sobre nós ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = " Precisando de Ajuda ?";

            return View();
        }

        public ActionResult Formulary()
        {
            ViewBag.Message = " Alguns Formulários";
            return View();
        }

        public ActionResult RegisterUsers()
        {
            ViewBag.Message = " Pagina de Registros ;3";
            return View();
        }

        public ActionResult Exibir(UsuarioRequest objRequest)
        {
            var usuarios = _dbContext.Usuarios.Include(w => w.Empresa).ToList();

            List<UsuarioResponse> usuariomodel = usuarios.Where(model =>
                string.IsNullOrEmpty(objRequest.Nome) || model.Nome.IndexOf(objRequest.Nome, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(item => new UsuarioResponse()
                {
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

            ViewBag.Usuarios = usuariomodel; // Armazena a lista de usuários na ViewBag

            return View();
        }

    }
}