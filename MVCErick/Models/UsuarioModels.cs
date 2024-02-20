using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MVCErick.Models
{
    public class UsuarioModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        [MaxLength(20)]
        public string Telefone { get; set; }
        public int EmpresaId { get; set; }




        //Um para muitos
        public EmpresaModels Empresa { get; set; }


    }
}