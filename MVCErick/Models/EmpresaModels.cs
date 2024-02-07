using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCErick.Models
{
    public class EmpresaModels
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string NomeEmpresa { get; set; }
        public string DescricaoEmpresa{ get; set; }
        [MaxLength(100)]
        public string Localidade { get; set; }
        public string CNPJ { get; set; } 
        public DateTime DataCriacao { get; set; }



        //Muitos pra um
        public List<UsuarioModels> Usuarios { get; set; }


    }
}