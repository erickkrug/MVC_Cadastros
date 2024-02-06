using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCErick.Models
{
    public class EmpresaModels
    {

        public int ID { get; set; }
        public string NomeEmpresa { get; set; }
        public string DescricaoEmpresa{ get; set; }
        public string Localidade { get; set; }
        public int CNPJ { get; set; }
        public DateTime DataCriacao { get; set; }


    }
}