using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MVCErick.Models
{
    public class UsuarioModels
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

    }
}